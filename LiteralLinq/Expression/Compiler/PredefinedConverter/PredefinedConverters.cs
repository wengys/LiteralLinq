using LiteralLinq.Expression.Design;
using System;
using System.Globalization;
using System.Linq;

namespace LiteralLinq.Expression.Compiler.PredefinedConverter
{
    internal class ByteConverter : ILiteralConverter
    {
        public object Convert(string valueStr, string formatter)
        {
            return byte.Parse(valueStr);
        }
    }

    internal class Int16Converter : ILiteralConverter
    {
        public object Convert(string valueStr, string formatter)
        {
            return Int16.Parse(valueStr);
        }
    }

    internal class Int32Converter : ILiteralConverter
    {
        public object Convert(string valueStr, string formatter)
        {
            return Int32.Parse(valueStr);
        }
    }

    internal class Int64Converter : ILiteralConverter
    {
        public object Convert(string valueStr, string formatter)
        {
            return Int64.Parse(valueStr);
        }
    }

    internal class SbyteConverter : ILiteralConverter
    {
        public object Convert(string valueStr, string formatter)
        {
            return sbyte.Parse(valueStr);
        }
    }

    internal class UInt16Converter : ILiteralConverter
    {
        public object Convert(string valueStr, string formatter)
        {
            return UInt16.Parse(valueStr);
        }
    }

    internal class UInt32Converter : ILiteralConverter
    {
        public object Convert(string valueStr, string formatter)
        {
            return UInt32.Parse(valueStr);
        }
    }

    internal class UInt64Converter : ILiteralConverter
    {
        public object Convert(string valueStr, string formatter)
        {
            return UInt64.Parse(valueStr);
        }
    }

    internal class FloatConverter : ILiteralConverter
    {
        public object Convert(string valueStr, string formatter)
        {
            return float.Parse(valueStr);
        }
    }

    internal class DoubleConverter : ILiteralConverter
    {
        public object Convert(string valueStr, string formatter)
        {
            return double.Parse(valueStr);
        }
    }

    internal class DecimalConverter : ILiteralConverter
    {
        public object Convert(string valueStr, string formatter)
        {
            return decimal.Parse(valueStr);
        }
    }

    internal class StringConverter : ILiteralConverter
    {
        public object Convert(string valueStr, string formatter)
        {
            return valueStr;
        }
    }

    internal class CharConverter : ILiteralConverter
    {
        public object Convert(string valueStr, string formatter)
        {
            return valueStr.ToCharArray().FirstOrDefault();
        }
    }

    internal class BooleanConverter : ILiteralConverter
    {
        public object Convert(string valueStr, string formatter)
        {
            return bool.Parse(valueStr);
        }
    }

    internal class DateTimeConverter : ILiteralConverter
    {
        public object Convert(string valueStr, string formatter)
        {
            if (string.IsNullOrEmpty(formatter))
            {
                formatter = "yyyy-MM-dd";
            }
            return DateTime.ParseExact(valueStr, formatter, CultureInfo.InvariantCulture);
        }
    }

    internal class EnumConverter : ILiteralGeneralConverter
    {
        public bool CanConvert(Type targetType)
        {
            return targetType.IsEnum;
        }

        public object Convert(Type targetType, string valueStr, string formatter)
        {
            return Enum.Parse(targetType, valueStr, false);
        }
    }
}