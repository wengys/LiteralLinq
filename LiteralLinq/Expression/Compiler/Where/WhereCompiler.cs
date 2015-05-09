using LiteralLinq.Expression.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Exp = System.Linq.Expressions;

namespace LiteralLinq.Expression.Compiler.Where
{
    /// <summary>
    /// Contains methods to complie string token to where expression
    /// </summary>
    internal class WhereCompiler
    {
        private ValueConverterCollection _valueConverters;
        private static readonly Type _nullableType = typeof(Nullable<>);

        public WhereCompiler(ValueConverterCollection valueConverters)
        {
            _valueConverters = valueConverters;
        }

        public Exp.Expression Compile<T>(IQueryable<T> source, string exp)
        {
            var lambdaExp = CompileToLambdaExpression<T>(exp);
            return Exp.Expression.Call(typeof(Queryable),
                "Where",
                new[] { typeof(T) },
                source.Expression,
                lambdaExp);
        }

        public Exp.Expression Compile<T>(string exp)
        {
            return CompileToLambdaExpression<T>(exp);
        }

        private Exp.LambdaExpression CompileToLambdaExpression<T>(string exp)
        {
            WhereTokenParser wtp = new WhereTokenParser();
            var tokens = wtp.Parse(exp).ToArray();
            Type sourceType = typeof(T);
            var sourceExpression = Exp.Expression.Parameter(sourceType, "QableSource");
            Stack<Exp.Expression> buffer = new Stack<Exp.Expression>();
            MemberInfo targetPathInfo = sourceType;
            var tokensCount = tokens.Count();
            for (int i = 0; i < tokensCount; i++)
            {
                var token = tokens[i];
                if (token.Type == WhereTokenType.MemberAccess)
                {
                    DispMemberAccess(sourceExpression, buffer, token, ref targetPathInfo);
                }
                else if (token.Type == WhereTokenType.Value || token.Type == WhereTokenType.ValueArray)
                {
                    string formatter = null;
                    if (tokens[i + 1].Type == WhereTokenType.Formatter)//If has formatter, take it out
                    {
                        formatter = tokens[++i].Tokens.Peek().TokenText;
                    }

                    DispValue(buffer, token, formatter, buffer.Peek(), targetPathInfo);
                    if (i + 1 < tokensCount && tokens[i + 1].Type != WhereTokenType.Operator)
                    {
                        throw new SyntaxException(tokens[i + 1].Tokens.Peek().StartOffset, "Mission operator. Offset:{0}, near \"{1}\"", tokens[i + 1].Tokens.Peek().StartOffset, tokens[i + 1].Tokens.Peek().TokenText);
                    }
                }
                else if (token.Type == WhereTokenType.Operator)
                {
                    DispOper(buffer, token);
                }
            }
            var lambdaExp = Exp.Expression.Lambda(buffer.Peek(), sourceExpression);
            return lambdaExp;
        }

        /// <summary>
        /// Handle value tokens
        /// </summary>
        private void DispValue(Stack<Exp.Expression> buffer, WhereToken token, string formatter, Exp.Expression path, MemberInfo targetPathInfo)
        {
            var valueType = buffer.Peek().Type;
            var actualType = valueType;
            var isNullable = false;
            GetActualType(ref actualType, ref isNullable);
            GuardSetNullValueToNotNullableType(token, isNullable);
            Exp.Expression value;

            if (token.Type == WhereTokenType.ValueArray)
            {
                var valueExpressions = token.Tokens.Select(t => ConvertLiteralToValue(t, formatter, actualType, targetPathInfo));
                if (isNullable && actualType.IsValueType)
                {
                    valueExpressions = valueExpressions.Select(ve => Exp.Expression.Convert(ve, valueType));
                }
                value = Exp.Expression.NewArrayInit(valueType, valueExpressions);
            }
            else
            {
                value = ConvertLiteralToValue(token.Tokens.Peek(), formatter, actualType, targetPathInfo);
                if (isNullable && actualType.IsValueType)
                {
                    value = Exp.Expression.Convert(value, valueType);
                }
            }
            buffer.Push(value);
        }

        /// <summary>
        /// Handle path tokens
        /// </summary>
        private static void DispMemberAccess(Exp.ParameterExpression sourceExpression, Stack<Exp.Expression> buffer, WhereToken token, ref MemberInfo targetPathInfo)
        {
            buffer.Push(Util.BuildAccessExpression(sourceExpression, token.Tokens, ref targetPathInfo));
        }

        /// <summary>
        /// Handle operator token
        /// </summary>
        private void DispOper(Stack<Exp.Expression> buffer, WhereToken token)
        {
            switch (token.Tokens.Peek().TokenText.ToUpper())
            {
                //TODO：Refactor. Since the number of operators is limited, now one single switch is just fine.
                case "LIKE":
                    {
                        var rightValue = buffer.Pop();
                        var leftValue = buffer.Pop();
                        if (!(rightValue is Exp.ConstantExpression))
                        {
                            throw new SyntaxException(token.Tokens.Peek().StartOffset, "Like operation can only applied in string comparison");
                        }
                        var value = (rightValue as Exp.ConstantExpression).Value;
                        if (leftValue.Type != typeof(string))
                        {
                            throw new SyntaxException(token.Tokens.Peek().StartOffset, "Like operation can only applied in string comparison");
                        }
                        if (value == null)
                        {
                            throw new SyntaxException(token.Tokens.Peek().StartOffset, "Like operation can not applied to null value");
                        }
                        Exp.Expression likeExpression;
                        var valueStr = value.ToString();
                        if (valueStr.StartsWith("%") && valueStr.EndsWith("%"))
                        {
                            likeExpression =
                              Exp.Expression.Call(
                                   leftValue,
                                   typeof(string).GetMethod("Contains", new Type[] { typeof(string) }),
                                  Exp.Expression.Constant(valueStr.Substring(1, valueStr.Length - 2), typeof(string)));
                        }
                        else if (valueStr.StartsWith("%"))
                        {
                            likeExpression =
                              Exp.Expression.Call(
                                    leftValue,
                                    typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) }),
                                   Exp.Expression.Constant(valueStr.Substring(1, valueStr.Length - 1), typeof(string)));
                        }
                        else if (value.ToString().EndsWith("%"))
                        {
                            likeExpression = Exp.Expression.Call(
                                 leftValue,
                                 typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) }),
                                Exp.Expression.Constant(valueStr.Substring(0, valueStr.Length - 1), typeof(string)));
                        }
                        else
                        {
                            likeExpression = Exp.Expression.Equal(leftValue, rightValue);
                        }
                        buffer.Push(likeExpression);
                        break;
                    }
                case "EQ":
                    {
                        var rightValue = buffer.Pop();
                        var leftValue = buffer.Pop();
                        Exp.Expression eqExpression;
                        //The following lines must be removed as Nullable equality compare on EntityFramework will throw an error.
                        //Anyway, just rare case we need to compare two struct directly.
                        //if (leftValue.Type.IsValueType && leftValue.Type.GetMethod("op_Equality") == null)//If value type don't have == method, use Equals instead
                        //{
                        //    eqExpression = Exp.Expression.Call(
                        //        leftValue,
                        //        "Equals",
                        //        null,
                        //        Exp.Expression.Convert(rightValue, typeof(object))
                        //        );
                        //}
                        //else
                        //{
                        eqExpression = Exp.Expression.Equal(leftValue, rightValue);
                        //}
                        buffer.Push(eqExpression);
                        break;
                    }
                case "NE":
                    {
                        var rightValue = buffer.Pop();
                        var leftValue = buffer.Pop();
                        Exp.Expression neExpression;
                        //if (leftValue.Type.IsValueType && leftValue.Type.GetMethod("op_Inequality") == null)//If value type don't have != method, use Equals instead
                        //{
                        //    neExpression = Exp.Expression.Not(Exp.Expression.Call(
                        //        leftValue,
                        //        "Equals",
                        //        null,
                        //        Exp.Expression.Convert(rightValue, typeof(object))
                        //        ));
                        //}
                        //else
                        //{
                        neExpression = Exp.Expression.NotEqual(leftValue, rightValue);
                        // }
                        buffer.Push(neExpression);
                        break;
                    }
                case "GT":
                    {
                        var rightValue = buffer.Pop();
                        var leftValue = buffer.Pop();
                        Exp.Expression gtExpression = Exp.Expression.GreaterThan(leftValue, rightValue);
                        buffer.Push(gtExpression);
                        break;
                    }

                case "LT":
                    {
                        var rightValue = buffer.Pop();
                        var leftValue = buffer.Pop();
                        Exp.Expression ltExpression = Exp.Expression.LessThan(leftValue, rightValue);
                        buffer.Push(ltExpression);
                        break;
                    }
                case "GE":
                    {
                        var rightValue = buffer.Pop();
                        var leftValue = buffer.Pop();
                        Exp.Expression geExpression = Exp.Expression.GreaterThanOrEqual(leftValue, rightValue);
                        buffer.Push(geExpression);
                        break;
                    }
                case "LE":
                    {
                        var rightValue = buffer.Pop();
                        var leftValue = buffer.Pop();
                        Exp.Expression leExpression = Exp.Expression.LessThanOrEqual(leftValue, rightValue);
                        buffer.Push(leExpression);
                        break;
                    }
                case "IN":
                    {
                        var rightValue = buffer.Pop();
                        var leftValue = buffer.Pop();
                        Exp.Expression inExpression = Exp.Expression.Call(typeof(Enumerable), "Contains", new[] { leftValue.Type }, rightValue, leftValue);
                        buffer.Push(inExpression);
                        break;
                    }
                case "NOT IN":
                    {
                        var rightValue = buffer.Pop();
                        var leftValue = buffer.Pop();
                        Exp.Expression notinExpression = Exp.Expression.Not(Exp.Expression.Call(typeof(Enumerable), "Contains", new[] { leftValue.Type }, rightValue, leftValue));
                        buffer.Push(notinExpression);
                        break;
                    }
                case "OR":
                    {
                        if (buffer.Count < 2)
                        {
                            throw new SyntaxException(token.Tokens.Peek().StartOffset, "Redudant operator. Offset:{0}, near \"{1}\"", token.Tokens.Peek().StartOffset, token.Tokens.Peek().TokenText);
                        }
                        var rightValue = buffer.Pop();
                        var leftValue = buffer.Pop();
                        Exp.Expression orExpression = Exp.Expression.OrElse(leftValue, rightValue);
                        buffer.Push(orExpression);
                        break;
                    }
                case "AND":
                    {
                        if (buffer.Count < 2)
                        {
                            throw new SyntaxException(token.Tokens.Peek().StartOffset, "Redudant operator. Offset:{0}, near \"{1}\"", token.Tokens.Peek().StartOffset, token.Tokens.Peek().TokenText);
                        }
                        var rightValue = buffer.Pop();
                        var leftValue = buffer.Pop();
                        Exp.Expression andExpression = Exp.Expression.AndAlso(leftValue, rightValue);
                        buffer.Push(andExpression);
                        break;
                    }
                default:
                    throw new SyntaxException(token.Tokens.Peek().StartOffset, "Unsupported operator: \"{0}\". Offset:{1}", token.Tokens.Peek().TokenText, token.Tokens.Peek().StartOffset);
            }
        }

        /// <summary>
        /// Convert token to actual value
        /// </summary>
        private Exp.Expression ConvertLiteralToValue(Token token, string formatter, Type valueType, MemberInfo targetPathInfo)
        {
            if (token.TokenType == TokenType.Null)
            {
                return Exp.Expression.Constant(null);
            }
            else
            {
                LiteralConverterAttribute converterAttr = null;
                if (targetPathInfo != null)
                {
                    converterAttr = targetPathInfo.GetCustomAttributes(typeof(LiteralConverterAttribute), true).FirstOrDefault() as LiteralConverterAttribute;//Converter attribute set in property/method
                }
                if (converterAttr == null)
                {
                    converterAttr = valueType.GetCustomAttributes(typeof(LiteralConverterAttribute), true).FirstOrDefault() as LiteralConverterAttribute;//Converter attribute set in elementy type
                }
                if (converterAttr != null)
                {
                    return Exp.Expression.Constant(converterAttr.Converter.Convert(token.TokenText, formatter));
                }
                object result;
                if (!_valueConverters.Convert(valueType, token.TokenText, formatter, out result))//Check global converters
                {
                    throw new SyntaxException(token.StartOffset, "No converter for type {0} registered", valueType);
                }
                return Exp.Expression.Constant(result);
            }
        }

        /// <summary>
        /// Guard situations like following: int i=null
        /// </summary>
        private static void GuardSetNullValueToNotNullableType(WhereToken token, bool isNullable)
        {
            var firstNullValueToken = token.Tokens.FirstOrDefault(t => t.TokenType == TokenType.Null);
            if (!isNullable && firstNullValueToken.TokenType != TokenType.Undefined)
            {
                throw new SyntaxException(firstNullValueToken.StartOffset, "Value type can not be null. Offset:{0}", firstNullValueToken.StartOffset);
            }
        }

        /// <summary>
        /// Get value's actual type (basically for Nullable type)
        /// </summary>
        private static void GetActualType(ref Type valueType, ref bool isNullable)
        {
            if (valueType.IsClass)
            {
                isNullable = true;
            }
            else if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == _nullableType)
            {
                valueType = valueType.GetGenericArguments()[0];
                isNullable = true;
            }
        }
    }
}