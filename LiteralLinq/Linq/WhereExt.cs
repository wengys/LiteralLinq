using LiteralLinq.Expression;
using LiteralLinq.Expression.Compiler;
using LiteralLinq.Expression.Compiler.PredefinedConverter;
using LiteralLinq.Expression.Compiler.Where;
using LiteralLinq.Expression.Design;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiteralLinq.Linq
{
    public static class WhereExt
    {
        private static ValueConverterCollection _converters = ValueConverterCollection.Instance;

        //public static void RegistConverter<T>(ILiteralConverter converter)
        //{
        //    _converters.RegistConverter(typeof(T), converter);
        //}

        //public static void RegistConverter(ILiteralGeneralConverter converter)
        //{
        //    _converters.RegistConverter(converter);
        //}

        static WhereExt()
        {
        }

        public static IQueryable<T> Where<T>(this IQueryable<T> source, string exp)
        {
            if (string.IsNullOrWhiteSpace(exp))
            {
                throw new SyntaxException(-1, "Syntax empty.");
            }
            WhereCompiler wc = new WhereCompiler(_converters);
            var whereExpression = wc.Compile(source, exp);
            return (IQueryable<T>)source.Provider.CreateQuery<T>(whereExpression);
        }
    }
}