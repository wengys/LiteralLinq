using LiteralLinq.Expression.Compiler;
using LiteralLinq.Expression.Design;
using LiteralLinq.Linq.Tests;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LiteralLinqTests.Linq
{
    internal class LLPointConverter : ILiteralConverter
    {
        public object Convert(string valueStr, string formatter)
        {
            var location = valueStr.Split(',');

            return new GeoPoint(int.Parse(location[0]), int.Parse(location[1]), int.Parse(location[2]));
        }
    }
}