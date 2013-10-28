using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteralLinq.Expression.Compiler.OrderBy
{
    /// <summary>
    /// Token unit in OrderBy syntax.
    /// </summary>
    public class OrderToken
    {
        /// <summary>
        /// Key access path
        /// </summary>
        public Queue<Token> PathTokens { get; private set; }

        /// <summary>
        /// Direction argument
        /// </summary>
        public Token DirectionToken { get; private set; }

        private OrderToken()
        { }

        public static OrderToken Create(Queue<Token> orderPathToken, Token orderDirectionToken)
        {
            return new OrderToken
            {
                PathTokens = orderPathToken,
                DirectionToken = orderDirectionToken
            };
        }
    }
}