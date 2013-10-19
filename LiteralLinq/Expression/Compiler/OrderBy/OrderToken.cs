using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteralLinq.Expression.Compiler.OrderBy
{
    public class OrderToken
    {
        public Queue<Token> PathTokens { get; private set; }

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