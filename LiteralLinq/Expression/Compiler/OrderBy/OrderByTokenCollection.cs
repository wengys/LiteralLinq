using System.Collections.Generic;

namespace LiteralLinq.Expression.Compiler.OrderBy
{
    internal class OrderByTokenCollection
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