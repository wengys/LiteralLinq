using LiteralLinq.Expression.Compiler;
using LiteralLinq.Expression.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteralLinq
{
    public static class LiteralLinqSettings
    {
        private static ValueConverterCollection _converters = ValueConverterCollection.Instance;

        public static void RegistConverter<T>(ILiteralConverter converter)
        {
            _converters.RegistConverter(typeof(T), converter);
        }

        public static void RegistConverter(ILiteralGeneralConverter converter)
        {
            _converters.RegistConverter(converter);
        }
    }
}