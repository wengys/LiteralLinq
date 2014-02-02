using System;
using System.Linq;

using Exp = System.Linq.Expressions;

namespace LiteralLinq.Expression.Compiler.OrderBy
{
    /// <summary>
    /// Contains methods to complie string token to orderby expression
    /// </summary>
    internal class OrderByCompiler
    {
        /// <summary>
        /// Create order expression
        /// </summary>
        public Exp.Expression Compile<T>(IQueryable<T> source, OrderToken token)
        {
            var orderDirectionSuffix =
                string.Equals(token.DirectionToken.TokenText, "asc", StringComparison.OrdinalIgnoreCase)
                ? "" : "Descending";
            var orderMethodName = "OrderBy" + orderDirectionSuffix;

            Exp.Expression builtExpression = CompileByOrderMethodName<T>(source, token, orderMethodName);

            return builtExpression;
        }

        /// <summary>
        /// Create order expression
        /// </summary>
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

        /// <summary>
        /// Create order expression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="token">Path to perform ordering</param>
        /// <param name="orderMethodName">Ascending/Descending</param>
        /// <returns></returns>
        private static Exp.Expression CompileByOrderMethodName<T>(IQueryable<T> source, OrderToken token, string orderMethodName)
        {
            Type sourceType = typeof(T);
            var sourceExpression = Exp.Expression.Parameter(sourceType, "QableSource");
            var pathExpression = Util.BuildAccessExpression(sourceExpression, token.PathTokens);
            var builtExpression = Exp.Expression.Call(
                 typeof(Queryable),
                 orderMethodName,
                 new[] { sourceType, pathExpression.Type },
                 source.Expression,
                 Exp.Expression.Lambda(pathExpression, sourceExpression));
            return builtExpression;
        }
    }
}