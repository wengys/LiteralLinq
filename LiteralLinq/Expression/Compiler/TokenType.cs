using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteralLinq.Expression.Compiler
{
    public enum TokenType
    {
        Undefined,
        PropertyOrField,
        Method,
        Literal, //Any argument or setting
        Operator,
        Null
    }
}