using LiteralLinq.Expression;
using LiteralLinq.Expression.Compiler;
using LiteralLinq.Expression.Compiler.PredefinedConverter;
using LiteralLinq.Expression.Compiler.Where;
using LiteralLinq.Expression.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using Exp = System.Linq.Expressions;

namespace LiteralLinq.Linq
{
    public static class WhereExt
    {
        private static ValueConverterCollection _converters = ValueConverterCollection.Instance;

        public static IQueryable<T> Where<T>(this IQueryable<T> source, string exp)
        {
            var filter = WhereExt.CreateFilter<T>(exp);
            return source.Where(filter);
        }

        public static Exp.Expression<Func<T, bool>> CreateFilter<T>(string exp)
        {
            if (string.IsNullOrWhiteSpace(exp))
            {
                throw new SyntaxException(-1, "Syntax empty.");
            }
            WhereCompiler wc = new WhereCompiler(_converters);
            var whereExpression = wc.Compile<T>(exp);
            return whereExpression;
        }
    }
}