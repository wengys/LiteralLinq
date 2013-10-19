using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteralLinq.Expression.Compiler.OrderBy
{
    public class OrderByTokenCollection
    {
        public Queue<OrderToken> OrderTokens { get; set; }

        public OrderByTokenCollection()
        {
            OrderTokens = new Queue<OrderToken>();
        }

        public void Append(Queue<Token> pathTokens, Token directionToken)
        {
            OrderTokens.Enqueue(OrderToken.Create(pathTokens, directionToken));
        }
    }
}