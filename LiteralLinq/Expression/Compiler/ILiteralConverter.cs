﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteralLinq.Expression.Compiler
{
    public interface ILiteralConverter
    {
        object Convert(string valueStr, string formatter);
    }
}