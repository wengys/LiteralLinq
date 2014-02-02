using System;

namespace LiteralLinq.Expression
{
    public class SyntaxException : Exception
    {
        public int Location { get; private set; }

        public SyntaxException(int location, string message, params object[] msgParams)
            : base(string.Format(message, msgParams))
        {
            this.Location = location;
        }
    }
}