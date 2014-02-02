using LiteralLinq.Expression;
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
        private static Dictionary<Type, ILiteralConverter> _converters = new Dictionary<Type, ILiteralConverter>();

        public static void RegistConverter<T>(ILiteralConverter converter)
        {
            _converters[typeof(T)] = converter;
        }

        static WhereExt()
        {
            _converters.Add(typeof(Int16), new Int16Converter());
            _converters.Add(typeof(Int32), new Int32Converter());
            _converters.Add(typeof(Int64), new Int64Converter());
            _converters.Add(typeof(UInt16), new UInt16Converter());
            _converters.Add(typeof(UInt32), new UInt32Converter());
            _converters.Add(typeof(UInt64), new UInt64Converter());
            _converters.Add(typeof(float), new FloatConverter());
            _converters.Add(typeof(double), new DoubleConverter());
            _converters.Add(typeof(decimal), new DecimalConverter());
            _converters.Add(typeof(string), new StringConverter());
            _converters.Add(typeof(DateTime), new DateTimeConverter());
        }

        public static IQueryable<T> Where<T>(this IQueryable<T> source, string exp)
        {
            if (string.IsNullOrWhiteSpace(exp))
            {
                throw new SyntaxException(-1, "Condition empty.");
            }
            WhereCompiler wc = new WhereCompiler(_converters);
            WhereTokenParser wtp = new WhereTokenParser();
            var whereExpression = wc.Compile(source, wtp.Parse(exp).ToArray());
            return (IQueryable<T>)source.Provider.CreateQuery<T>(whereExpression);
        }
    }
}