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