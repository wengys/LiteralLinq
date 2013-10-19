using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteralLinq.Expression
{
    public class SyntexException : Exception
    {
        public int Location { get; private set; }

        public SyntexException(int location, string message, params object[] msgParams)
            : base(string.Format(message, msgParams))
        {
            this.Location = location;
        }
    }
}