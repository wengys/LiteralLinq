using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteralLinq.Expression.Compiler
{
    internal class TokenParseBuffer
    {
        private StringBuilder buffer;

        public int StartOffset { get; private set; }

        public int EndOffset { get; private set; }

        public TokenType TokenType { get; private set; }

        public TokenParseBuffer()
        {
            buffer = new StringBuilder();
        }

        public void BeginBuffer(int offset)
        {
            Clear();
            StartOffset = offset;
        }

        public void Clear()
        {
            EndOffset = -1;
            TokenType = TokenType.Undefined;
            buffer.Clear();
        }

        public void Append(char ch)
        {
            buffer.Append(ch);
        }

        public void SetTokenType(TokenType type)
        {
            TokenType = type;
        }

        public Token EndBuffer(int offset)
        {
            EndOffset = offset;
            return new Token(buffer.ToString(), TokenType, StartOffset, EndOffset);
        }

        public string Current()
        {
            return buffer.ToString();
        }
    }
}