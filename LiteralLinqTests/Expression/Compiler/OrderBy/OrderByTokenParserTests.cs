using LiteralLinq.Expression.Compiler;
using LiteralLinq.Expression.Compiler.OrderBy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LiteralLinq.Expression.Compiler.Tests
{
    [TestClass()]
    public class OrderByExpressionTokenParserTests
    {
        [TestMethod()]
        public void OnePropertyTest()
        {
            OrderByTokenParser parser = new OrderByTokenParser();
            var actual = parser.Parse("it.Name asc");
            Assert.IsTrue(actual.OrderTokens.Count > 0);
            Assert.AreEqual(actual.OrderTokens.Peek().PathTokens.Peek().TokenText, "Name");
            Assert.AreEqual(actual.OrderTokens.Peek().DirectionToken.TokenText, "asc");
        }

        [TestMethod()]
        public void OnePropertyDefaultDirectionTest()
        {
            OrderByTokenParser parser = new OrderByTokenParser();
            var actual = parser.Parse("it.Name asc");
            Assert.IsTrue(actual.OrderTokens.Count > 0);
            Assert.AreEqual(actual.OrderTokens.Peek().PathTokens.Peek().TokenText, "Name");
            StringAssert.Matches(actual.OrderTokens.Peek().DirectionToken.TokenText, new Regex("asc", RegexOptions.IgnoreCase));
        }

        [TestMethod()]
        public void OneHierarchyPropertyTest()
        {
            OrderByTokenParser parser = new OrderByTokenParser();
            var actual = parser.Parse("it.Name.Day asc");
            Assert.IsTrue(actual.OrderTokens.Count > 0);
            Assert.AreEqual(actual.OrderTokens.Peek().PathTokens.Dequeue().TokenText, "Name");
            Assert.AreEqual(actual.OrderTokens.Peek().PathTokens.Dequeue().TokenText, "Day");
            Assert.AreEqual(actual.OrderTokens.Peek().DirectionToken.TokenText, "asc");
        }

        [TestMethod()]
        public void OneFunctionPropertyTest()
        {
            OrderByTokenParser parser = new OrderByTokenParser();
            var actual = parser.Parse("it.Name() asc");
            Assert.IsTrue(actual.OrderTokens.Count > 0);
            var orderByTokenToken = actual.OrderTokens.Peek().PathTokens.Dequeue();
            Assert.AreEqual(orderByTokenToken.TokenText, "Name");
            Assert.AreEqual(orderByTokenToken.TokenType, TokenType.Method);
            Assert.AreEqual(actual.OrderTokens.Peek().DirectionToken.TokenText, "asc");
        }

        [TestMethod()]
        public void TwoFunctionPropertyTest()
        {
            OrderByTokenParser parser = new OrderByTokenParser();
            var actual = parser.Parse("it.Name() desc,It.Desc()");
            Assert.IsTrue(actual.OrderTokens.Count > 0);
            var orderByTokens = actual.OrderTokens.Dequeue();
            var orderByToken = orderByTokens.PathTokens.Dequeue();
            Assert.AreEqual(orderByToken.TokenText, "Name");
            Assert.AreEqual(orderByToken.TokenType, TokenType.Method);
            Assert.AreEqual(orderByTokens.DirectionToken.TokenText, "desc");

            Assert.IsTrue(actual.OrderTokens.Count() > 0);

            var thenbyToken = actual.OrderTokens.Dequeue();

            Assert.AreEqual(thenbyToken.PathTokens.Dequeue().TokenText, "Desc");
            StringAssert.Matches(thenbyToken.DirectionToken.TokenText, new Regex("asc", RegexOptions.IgnoreCase));
        }

        [TestMethod()]
        public void OrderBySelfTest()
        {
            OrderByTokenParser parser = new OrderByTokenParser();
            var actual = parser.Parse("it,it desc");
            Assert.IsTrue(actual.OrderTokens.Count > 0);
            var orderByTokens = actual.OrderTokens.Dequeue();
            var orderByToken = orderByTokens.PathTokens.Dequeue();
            Assert.AreEqual(orderByToken.TokenText, "");
            Assert.AreEqual(orderByToken.TokenType, TokenType.PropertyOrField);
            Assert.AreEqual(orderByTokens.DirectionToken.TokenText, "ASC");

            Assert.IsTrue(actual.OrderTokens.Count() > 0);

            var thenbyToken = actual.OrderTokens.Dequeue();

            Assert.AreEqual(thenbyToken.PathTokens.Dequeue().TokenText, "");
            StringAssert.Matches(thenbyToken.DirectionToken.TokenText, new Regex("desc", RegexOptions.IgnoreCase));
        }
    }
}