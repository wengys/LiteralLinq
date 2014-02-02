using System.Collections.Generic;

namespace LiteralLinq.Expression.Compiler.Where
{
    /// <summary>
    /// Indicate priority of operators
    /// </summary>
    internal static class WhereOperatorTable
    {
        private static readonly System.Collections.Generic.Dictionary<string, int> OperatorPriorities = new Dictionary<string, int> {
            { "EQ",1},
            { "NE",1},
            { "GT",1},
            { "LT",1},
            { "GE",1},
            { "LE",1},
            { "LIKE",1},
            { "IN",1},
            { "NOT IN",1},

            { "AND",2},
            { "OR",2},

            { "(",99},
            { ")",99},
        };

        public static int? GetOperatorPriority(string oper)
        {
            oper = oper.ToUpper();
            if (!OperatorPriorities.ContainsKey(oper))
            {
                return null;
            }
            return OperatorPriorities[oper];
        }
    }
}