﻿using LiteralLinq.Expression;
using LiteralLinq.Expression.Compiler.OrderBy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteralLinq.Linq
{
    public static partial class QueryableExt
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string exp)
        {
            if (string.IsNullOrWhiteSpace(exp))
            {
                throw new SyntexException(-1, "表达式长度不能为零");
            }
            OrderByTokenParser parser = new OrderByTokenParser();
            OrderByCompiler cpir = new OrderByCompiler();

            var tokens = parser.Parse(exp);

            var orderedExpression = cpir.Compile<T>(source, tokens.OrderTokens.Dequeue());
            var orderedQuery = (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(orderedExpression);

            while (tokens.OrderTokens.Count > 0)
            {
                orderedExpression = cpir.Compile<T>(orderedQuery, tokens.OrderTokens.Dequeue());
                orderedQuery = (IOrderedQueryable<T>)orderedQuery.Provider.CreateQuery<T>(orderedExpression);
            }

            return orderedQuery;
        }

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string exp)
        {
            if (string.IsNullOrWhiteSpace(exp))
            {
                throw new SyntexException(-1, "表达式长度不能为零");
            }
            OrderByTokenParser parser = new OrderByTokenParser();
            OrderByCompiler cpir = new OrderByCompiler();

            var tokens = parser.Parse(exp);

            var orderedQuery = source;

            while (tokens.OrderTokens.Count > 0)
            {
                var orderedExpression = cpir.Compile<T>(orderedQuery, tokens.OrderTokens.Dequeue());
                orderedQuery = (IOrderedQueryable<T>)orderedQuery.Provider.CreateQuery<T>(orderedExpression);
            }

            return orderedQuery;
        }
    }
}