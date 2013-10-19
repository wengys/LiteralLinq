using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteralLinq.Expression.Compiler
{
    public struct Token
    {
        public string TokenText;

        public int StartOffset;

        public int EndOffset;

        public TokenType TokenType;

        public Token(string token, TokenType type, int start, int end)
        {
            TokenText = token;
            StartOffset = start;
            EndOffset = end;
            TokenType = type;
            TokenText.Equals("asc", StringComparison.OrdinalIgnoreCase);
        }
    }
}