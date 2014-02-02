using System;

namespace LiteralLinq.Expression.Design
{
    /// <summary>
    /// Provide a way of converting string to certain type, with optional formatter
    /// </summary>
    public interface ILiteralConverter
    {
        /// <summary>
        /// Convert a string to an object
        /// </summary>
        /// <param name="valueStr">string which represent a value</param>
        /// <param name="formatter">string which indicate how to convert valueStr</param>
        /// <returns></returns>
        object Convert(string valueStr, string formatter);
    }

    /// <summary>
    /// Indicate which ILiteralConverter implemention will used to convert value string
    /// </summary>
    [AttributeUsage(
        AttributeTargets.Class
        | AttributeTargets.Enum
        | AttributeTargets.Field
        | AttributeTargets.Method
        | AttributeTargets.Property
        | AttributeTargets.Struct
        , AllowMultiple = false)]
    public class LiteralConverterAttribute : Attribute
    {
        public ILiteralConverter Converter { get; private set; }

        /// <summary>
        /// Initial new instance of LiteralConverterAttribute
        /// </summary>
        /// <param name="converterType">The converter type which implement ILiteralConverter</param>
        public LiteralConverterAttribute(Type converterType)
        {
            Converter = (ILiteralConverter)System.Activator.CreateInstance(converterType);
            if (Converter == null)
            {
                throw new ArgumentException(String.Format("Type {0} does not implement ILiteralConverter", converterType.FullName));
            }
        }
    }
}