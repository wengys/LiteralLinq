using LiteralLinq.Expression.Compiler.PredefinedConverter;
using LiteralLinq.Expression.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteralLinq.Expression.Compiler
{
    /// <summary>
    /// Collection that contains value converters
    /// </summary>
    internal class ValueConverterCollection
    {
        private List<ILiteralGeneralConverter> _generalConverters = new List<ILiteralGeneralConverter>();
        private Dictionary<Type, ILiteralConverter> _converters = new Dictionary<Type, ILiteralConverter>();
        private static ValueConverterCollection _instance;

        private ValueConverterCollection()
        {
            InitDefaultConverterRegistrations();
        }

        static ValueConverterCollection()
        {
            _instance = new ValueConverterCollection();
        }

        public static ValueConverterCollection Instance
        {
            get { return ValueConverterCollection._instance; }
        }

        private void InitDefaultConverterRegistrations()
        {
            this.RegistConverter(typeof(byte), new ByteConverter());
            this.RegistConverter(typeof(Int16), new Int16Converter());
            this.RegistConverter(typeof(Int32), new Int32Converter());
            this.RegistConverter(typeof(Int64), new Int64Converter());
            this.RegistConverter(typeof(sbyte), new SbyteConverter());
            this.RegistConverter(typeof(UInt16), new UInt16Converter());
            this.RegistConverter(typeof(UInt32), new UInt32Converter());
            this.RegistConverter(typeof(UInt64), new UInt64Converter());
            this.RegistConverter(typeof(float), new FloatConverter());
            this.RegistConverter(typeof(double), new DoubleConverter());
            this.RegistConverter(typeof(decimal), new DecimalConverter());
            this.RegistConverter(typeof(string), new StringConverter());
            this.RegistConverter(typeof(DateTime), new DateTimeConverter());
            this.RegistConverter(typeof(char), new CharConverter());
            this.RegistConverter(typeof(bool), new BooleanConverter());
            this.RegistConverter(new EnumConverter());
        }

        /// <summary>
        /// Regist a ILiteralGeneralConverter instance
        /// </summary>
        public void RegistConverter(ILiteralGeneralConverter generalConverter)
        {
            _generalConverters.Insert(0, generalConverter);
        }

        /// <summary>
        /// Regist a ILiteralConverter instance
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="converter"></param>
        public void RegistConverter(Type targetType, ILiteralConverter converter)
        {
            _converters[targetType] = converter;
        }

        /// <summary>
        /// Convert string to target type object
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="valueStr"></param>
        /// <param name="formatter"></param>
        /// <param name="result">Convert result</param>
        /// <returns>Is convert success</returns>
        public bool Convert(Type targetType, string valueStr, string formatter, out object result)
        {
            foreach (var generalConverter in _generalConverters)
            {
                if (generalConverter.CanConvert(targetType))
                {
                    result = generalConverter.Convert(targetType, valueStr, formatter);
                    return true;
                }
            }
            if (_converters.ContainsKey(targetType))
            {
                result = _converters[targetType].Convert(valueStr, formatter);
                return true;
            }
            result = null;
            return false;
        }
    }
}