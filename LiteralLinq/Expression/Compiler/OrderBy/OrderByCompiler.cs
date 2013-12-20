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
        //Since in some situation test whether the source implement the IOrderedQueryable interface always return true,
        //no better idea to distinguish ThenBy operation from OrderBy.
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
            builtExpression = Util.BuildAccessExpression(sourceExpression, token.PathTokens);

            builtExpression = Exp.Expression.Call(
                typeof(Queryable),
                orderMethodName,
                new[] { sourceType, builtExpression.Type },
                source.Expression,
                Exp.Expression.Lambda(builtExpression, sourceExpression));
            return builtExpression;
        }

        private Exp.Expression BuildOrderExpression(Exp.ParameterExpression targetExpression, Exp.Expression builtExpression)
        {
            builtExpression = Exp.Expression.Lambda(builtExpression, targetExpression);

            return builtExpression;
        }
    }
}