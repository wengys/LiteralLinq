using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exp = System.Linq.Expressions;

namespace LiteralLinq.Expression.Compiler.Where
{
    public class WhereCompiler
    {
        private Dictionary<Type, ILiteralConverter> _valueConverters;

        public WhereCompiler(Dictionary<Type, ILiteralConverter> valueConverters)
        {
            _valueConverters = valueConverters;
        }

        public Exp.Expression Compile<T>(IQueryable<T> source, IEnumerable<WhereToken> tokens)
        {
            Type sourceType = typeof(T);
            var sourceExpression = Exp.Expression.Parameter(sourceType, "QableSource");
            Stack<Exp.Expression> buffer = new Stack<Exp.Expression>();

            var tokensCount = tokens.Count();
            for (int i = 0; i < tokensCount; i++)
            {
                var token = tokens.ElementAt(i);
                if (token.Type == WhereTokenType.MemberAccess)
                {
                    DispMemberAccess(sourceExpression, buffer, token);
                }
                else if (token.Type == WhereTokenType.Value || token.Type == WhereTokenType.ValueArray)
                {
                    string formatter = null;
                    if (tokens.ElementAt(i + 1).Type == WhereTokenType.Formatter)
                    {
                        formatter = tokens.ElementAt(++i).Tokens.Peek().TokenText;
                    }

                    DispValue(buffer, token, formatter);
                    if (i + 1 < tokensCount && tokens.ElementAt(i + 1).Type != WhereTokenType.Operator)
                    {
                        throw new SyntaxException(tokens.ElementAt(i + 1).Tokens.Peek().StartOffset, "Mission operator. Offset:{0}, near \"{1}\"", tokens.ElementAt(i + 1).Tokens.Peek().StartOffset, tokens.ElementAt(i + 1).Tokens.Peek().TokenText);
                    }
                }
                else if (token.Type == WhereTokenType.Operator)
                {
                    DispOper(buffer, token);
                }
            }
            return Exp.Expression.Call(typeof(Queryable),
                "Where",
                new[] { typeof(T) },
                source.Expression,
                Exp.Expression.Lambda(buffer.Peek(), sourceExpression));
        }

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
                        Exp.Expression eqExpression = Exp.Expression.Equal(leftValue, rightValue);
                        buffer.Push(eqExpression);
                        break;
                    }
                case "NE":
                    {
                        var rightValue = buffer.Pop();
                        var leftValue = buffer.Pop();
                        Exp.Expression neExpression = Exp.Expression.NotEqual(leftValue, rightValue);
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

        private void DispValue(Stack<Exp.Expression> buffer, WhereToken token, string formatter)
        {
            var valueType = buffer.Peek().Type;
            var actualType = valueType;
            var isNullable = false;
            GetActualType(ref actualType, ref isNullable);
            GuardIsNullValueAvailable(token, isNullable);
            Exp.Expression value;

            if (token.Type == WhereTokenType.ValueArray)
            {
                var valueExpressions = token.Tokens.Select(t => ConvertLiteralToValue(t, formatter, actualType));
                if (isNullable && actualType.IsValueType)
                {
                    valueExpressions = valueExpressions.Select(ve => Exp.Expression.Convert(ve, valueType));
                }
                value = Exp.Expression.NewArrayInit(valueType, valueExpressions);
            }
            else
            {
                value = ConvertLiteralToValue(token.Tokens.Peek(), formatter, actualType);
                if (isNullable && actualType.IsValueType)
                {
                    value = Exp.Expression.Convert(value, valueType);
                }
            }
            buffer.Push(value);
        }

        private static void DispMemberAccess(Exp.ParameterExpression sourceExpression, Stack<Exp.Expression> buffer, WhereToken token)
        {
            buffer.Push(Util.BuildAccessExpression(sourceExpression, token.Tokens));
        }

        private Exp.Expression ConvertLiteralToValue(Token token, string formatter, Type valueType)
        {
            if (token.TokenType == TokenType.Null)
            {
                return Exp.Expression.Constant(null);
            }
            else
            {
                if (!_valueConverters.ContainsKey(valueType))
                {
                    throw new SyntaxException(token.StartOffset, "No converter for type {0} registered", valueType);
                }
                return Exp.Expression.Constant(_valueConverters[valueType].Convert(token.TokenText, formatter));
            }
        }

        private static void GuardIsNullValueAvailable(WhereToken token, bool isNullable)
        {
            var firstNullValueToken = token.Tokens.FirstOrDefault(t => t.TokenType == TokenType.Null);
            if (!isNullable && firstNullValueToken.TokenType != TokenType.Undefined)
            {
                throw new SyntaxException(firstNullValueToken.StartOffset, "Value type can not be null. Offset:{0}", firstNullValueToken.StartOffset);
            }
        }

        private static void GetActualType(ref Type valueType, ref bool isNullable)
        {
            if (valueType.IsClass)
            {
                isNullable = true;
            }
            else if (valueType.IsGenericType && valueType.GetGenericTypeDefinition().FullName == "System.Nullable`1")
            {
                valueType = valueType.GetGenericArguments()[0];
                isNullable = true;
            }
        }
    }
}