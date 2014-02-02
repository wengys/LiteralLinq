using System.Text;

namespace LiteralLinq.Expression.Compiler
{
    /// <summary>
    /// Hold current parsing token
    /// </summary>
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

        /// <summary>
        /// Begin buffering.
        /// </summary>
        /// <param name="offset">Start position of new token</param>
        public void BeginBuffer(int offset)
        {
            Clear();
            StartOffset = offset;
        }

        private void Clear()
        {
            EndOffset = -1;
            TokenType = TokenType.Undefined;
            buffer.Clear();
        }

        /// <summary>
        /// Append new char
        /// </summary>
        /// <param name="ch"></param>
        public void Append(char ch)
        {
            buffer.Append(ch);
        }

        /// <summary>
        /// Set current token's type
        /// </summary>
        /// <param name="type"></param>
        public void SetTokenType(TokenType type)
        {
            TokenType = type;
        }

        /// <summary>
        /// Indicate current token has parsed and get current token
        /// </summary>
        /// <param name="offset">End position of current token</param>
        /// <returns>Current token</returns>
        public Token EndBuffer(int offset)
        {
            EndOffset = offset;
            return new Token(buffer.ToString(), TokenType, StartOffset, EndOffset);
        }

        /// <summary>
        /// return current token string
        /// </summary>
        /// <returns></returns>
        public string Current()
        {
            return buffer.ToString();
        }
    }
}