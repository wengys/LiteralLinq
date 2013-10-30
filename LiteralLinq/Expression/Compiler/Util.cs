using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exp = System.Linq.Expressions;

namespace LiteralLinq.Expression.Compiler
{
    public static class Util
    {
        public static Exp.Expression BuildAccessExpression(Exp.ParameterExpression targetExpression, Queue<Token> paths)
        {
            Exp.Expression builtExpression = null;
            var pathTokens = paths.Count;
            for (int i = 1; i <= pathTokens; i++)
            {
                var curTarget = builtExpression ?? targetExpression;
                var pathToken = paths.Dequeue();
                if (pathToken.TokenType == TokenType.PropertyOrField)
                {
                    if (string.IsNullOrEmpty(pathToken.TokenText))
                    {
                        return targetExpression;
                    }
                    try
                    {
                        var path = Exp.Expression.PropertyOrField(curTarget, pathToken.TokenText);
                        builtExpression = Exp.Expression.MakeMemberAccess(curTarget, path.Member);
                    }
                    catch (ArgumentException)
                    {
                        throw new SyntaxException(pathToken.StartOffset, "Type \"{0}\" does not have property \"{1}\"", targetExpression.Type.Name, pathToken.TokenText);
                    }
                }
                else if (pathToken.TokenType == TokenType.Method)
                {
                    try
                    {
                        var methodToCall = curTarget.Type.GetMethod(pathToken.TokenText);
                        builtExpression = Exp.Expression.Call(curTarget, methodToCall);
                    }
                    catch (ArgumentException)
                    {
                        throw new SyntaxException(pathToken.StartOffset, "Type \"{0}\" does not have method \"{1}()\"", targetExpression.Type.FullName, pathToken.TokenText);
                    }
                }
            }
            return builtExpression;
        }
    }
}