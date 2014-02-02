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
        private static ValueConverterCollection _converters = new ValueConverterCollection();

        public static void RegistConverter<T>(ILiteralConverter converter)
        {
            _converters.RegistConverter(typeof(T), converter);
        }

        public static void RegistConverter(ILiteralGeneralConverter converter)
        {
            _converters.RegistConverter(converter);
        }

        static WhereExt()
        {
            _converters.RegistConverter(typeof(Int16), new Int16Converter());
            _converters.RegistConverter(typeof(Int32), new Int32Converter());
            _converters.RegistConverter(typeof(Int64), new Int64Converter());
            _converters.RegistConverter(typeof(UInt16), new UInt16Converter());
            _converters.RegistConverter(typeof(UInt32), new UInt32Converter());
            _converters.RegistConverter(typeof(UInt64), new UInt64Converter());
            _converters.RegistConverter(typeof(float), new FloatConverter());
            _converters.RegistConverter(typeof(double), new DoubleConverter());
            _converters.RegistConverter(typeof(decimal), new DecimalConverter());
            _converters.RegistConverter(typeof(string), new StringConverter());
            _converters.RegistConverter(typeof(DateTime), new DateTimeConverter());
            _converters.RegistConverter(new EnumConverter());
        }

        public static IQueryable<T> Where<T>(this IQueryable<T> source, string exp)
        {
            if (string.IsNullOrWhiteSpace(exp))
            {
                throw new SyntaxException(-1, "Syntax empty.");
            }
            WhereCompiler wc = new WhereCompiler(_converters);
            WhereTokenParser wtp = new WhereTokenParser();
            var whereExpression = wc.Compile(source, wtp.Parse(exp).ToArray());
            return (IQueryable<T>)source.Provider.CreateQuery<T>(whereExpression);
        }
    }
}