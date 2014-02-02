using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Exp = System.Linq.Expressions;

namespace LiteralLinq.Expression.Compiler
{
    internal static class Util
    {
        /// <summary>
        /// Create an expression that accessing a property/parameterless function
        /// </summary>
        public static Exp.Expression BuildAccessExpression(Exp.ParameterExpression targetExpression, Queue<Token> paths)
        {
            MemberInfo targetPathInfo = null;
            return BuildAccessExpression(targetExpression, paths, ref targetPathInfo);
        }

        /// <summary>
        /// Create an expression that accessing a property/parameterless function
        /// </summary>
        public static Exp.Expression BuildAccessExpression(Exp.ParameterExpression targetExpression, Queue<Token> paths, ref MemberInfo targetPathInfo)
        {
            Exp.Expression builtExpression = null;
            //var pathTokens = paths.Count;
            //for (int i = 1; i <= pathTokens; i++)
            //{
            //targetPathInfo = null;
            while (paths.Any())
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
                        targetPathInfo = path.Member;
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
                        targetPathInfo = methodToCall;
                        builtExpression = Exp.Expression.Call(curTarget, methodToCall);
                    }
                    catch (ArgumentException)
                    {
                        throw new SyntaxException(pathToken.StartOffset, "Type \"{0}\" does not have method \"{1}()\"", targetExpression.Type.FullName, pathToken.TokenText);
                    }
                }
                // }
            }
            return builtExpression;
        }
    }
}