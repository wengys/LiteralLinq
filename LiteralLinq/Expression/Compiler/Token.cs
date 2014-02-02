namespace LiteralLinq.Expression.Compiler
{
    /// <summary>
    /// Store single token string and related metadata.
    /// </summary>
    internal struct Token
    {
        /// <summary>
        /// Token text
        /// </summary>
        public string TokenText;

        /// <summary>
        /// Start offset in source
        /// </summary>
        public int StartOffset;

        /// <summary>
        /// End offset in source
        /// </summary>
        public int EndOffset;

        public TokenType TokenType;

        public Token(string token, TokenType type, int start, int end)
        {
            TokenText = token;
            StartOffset = start;
            EndOffset = end;
            TokenType = type;
        }
    }
}