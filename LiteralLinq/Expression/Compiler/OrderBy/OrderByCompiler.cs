using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

using Exp = System.Linq.Expressions;

namespace LiteralLinq.Expression.Compiler.OrderBy
{
    public class OrderByCompiler
    {
        public Exp.Expression Compile<T>(IQueryable<T> source, OrderToken token)
        {
            var orderDirectionSuffix =
                string.Equals(token.DirectionToken.TokenText, "asc", StringComparison.OrdinalIgnoreCase)
                ? "" : "Descending";
            var orderMethodName = "OrderBy" + orderDirectionSuffix;

            Exp.Expression builtExpression = CompileByOrderMethodName<T>(source, token, orderMethodName);

            return builtExpression;
        }

        public Exp.Expression Compile<T>(IOrderedQueryable<T> source, OrderToken token)
        {
            var orderDirectionSuffix =
                string.Equals(token.DirectionToken.TokenText, "asc", StringComparison.OrdinalIgnoreCase)
                ? "" : "Descending";
            var orderMethodName = "ThenBy" + orderDirectionSuffix;

            Exp.Expression builtExpression = CompileByOrderMethodName<T>(source, token, orderMethodName);

            return builtExpression;
        }

        private static Exp.Expression CompileByOrderMethodName<T>(IQueryable<T> source, OrderToken token, string orderMethodName)
        {
            Type sourceType = typeof(T);
            var sourceExpression = Exp.Expression.Parameter(sourceType, "QableSource");

            Exp.Expression builtExpression = null;
            builtExpression = BuildAccessExpression(sourceExpression, token, builtExpression);

            builtExpression = Exp.Expression.Call(
                typeof(Queryable),
                orderMethodName,
                new[] { sourceType, builtExpression.Type },
                Exp.Expression.Constant(source), Exp.Expression.Lambda(builtExpression, sourceExpression));
            return builtExpression;
        }

        private Exp.Expression BuildOrderExpression(Exp.ParameterExpression targetExpression, Exp.Expression builtExpression)
        {
            builtExpression = Exp.Expression.Lambda(builtExpression, targetExpression);

            return builtExpression;
        }

        private static Exp.Expression BuildAccessExpression(Exp.ParameterExpression targetExpression, OrderToken token, Exp.Expression builtExpression)
        {
            var pathTokens = token.PathTokens.Count;
            for (int i = 1; i <= pathTokens; i++)
            {
                var curTarget = builtExpression ?? targetExpression;
                var pathToken = token.PathTokens.Dequeue();
                if (pathToken.TokenType == TokenType.PropertyOrField)
                {
                    if (string.IsNullOrEmpty(pathToken.TokenText))
                    {
                        return targetExpression;
                    }
                    try
                    {
                        var path = Exp.Expression.PropertyOrField(curTarget, pathToken.TokenText);
                        builtExpression = Exp.Expression.MakeMemberAccess(curTarget, path.Member);
                    }
                    catch (ArgumentException)
                    {
                        throw new SyntexException(pathToken.StartOffset, "Type \"{0}\" does not have property \"{1}\"", targetExpression.Type.Name, pathToken.TokenText);
                    }
                }
                else if (pathToken.TokenType == TokenType.Method)
                {
                    try
                    {
                        var methodToCall = curTarget.Type.GetMethod(pathToken.TokenText);
                        builtExpression = Exp.Expression.Call(curTarget, methodToCall);
                    }
                    catch (ArgumentException)
                    {
                        throw new SyntexException(pathToken.StartOffset, "Type \"{0}\" does not have method \"{1}()\"", targetExpression.Type.FullName, pathToken.TokenText);
                    }
                }
            }
            return builtExpression;
        }
    }
}