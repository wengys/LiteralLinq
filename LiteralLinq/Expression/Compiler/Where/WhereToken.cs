using System.Collections.Generic;

namespace LiteralLinq.Expression.Compiler.Where
{
    /// <summary>
    /// Token unit in Where syntax.
    /// </summary>
    internal class WhereToken
    {
        public Queue<Token> Tokens { get; private set; }

        public WhereTokenType Type { get; private set; }

        public int? Priority { get; private set; }

        private WhereToken()
        { }

        public static WhereToken Create(Queue<Token> tokens, WhereTokenType type, int? priority = null)
        {
            return new WhereToken
            {
                Tokens = tokens,
                Type = type,
                Priority = priority
            };
        }
    }
}