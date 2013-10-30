using LiteralLinq.Expression.Compiler.Where;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteralLinq.Expression.Compiler.Where.Tests
{
    [TestClass()]
    public class WhereTokenParserTests
    {
        [TestMethod()]
        [TestCategory("WhereParser")]
        public void OneExpressionTest()
        {
            WhereTokenParser parser = new WhereTokenParser();
            var tokens = parser.Parse("it.Remarks.First() <EQ> '3\\\\''").ToArray();
            Assert.AreEqual(3, tokens.Length);
            Assert.AreEqual(WhereTokenType.MemberAccess, tokens[0].Type);
            Assert.AreEqual(2, tokens[0].Tokens.Count);
            Assert.AreEqual(WhereTokenType.Operator, tokens[2].Type);
            Assert.AreEqual(@"3\'", tokens[1].Tokens.Peek().TokenText);//Escape char handling
        }

        [TestMethod()]
        [TestCategory("WhereParser")]
        public void OneExpressionWithFormatterTest()
        {
            WhereTokenParser parser = new WhereTokenParser();
            var tokens = parser.Parse("it.Date <EQ> '2013-11-11'@'yyyy-MM-dd'").ToArray();
            Assert.AreEqual(4, tokens.Length);
            Assert.AreEqual(WhereTokenType.Formatter, tokens[2].Type);
        }

        [TestMethod()]
        [TestCategory("WhereParser")]
        public void OneExpressionWithArrayValueTest()
        {
            WhereTokenParser parser = new WhereTokenParser();
            var tokens = parser.Parse("it.Date <In> ['2013-11-11','2013-11-22']").ToArray();
            Assert.AreEqual(3, tokens.Length);
            Assert.AreEqual(2, tokens[1].Tokens.Count);
        }

        [TestMethod()]
        [TestCategory("WhereParser")]
        public void OneExpressionWithArrayValueFormatterTest()
        {
            WhereTokenParser parser = new WhereTokenParser();
            var tokens = parser.Parse("it.Date <EQ> ['2013-11-11','2013-11-22']@'yyyy-MM-dd'").ToArray();
            Assert.AreEqual(4, tokens.Length);
            Assert.AreEqual(2, tokens[1].Tokens.Count);
            Assert.AreEqual(WhereTokenType.Formatter, tokens[2].Type);
        }

        [TestMethod()]
        [TestCategory("WhereParser")]
        public void TwoExpressionTest()
        {
            WhereTokenParser parser = new WhereTokenParser();
            var tokens = parser.Parse("it.Name().Length <EQ> '3' <AND> it.Age <NE> '30' ").ToArray();
            Assert.AreEqual(7, tokens.Length);
            Assert.AreEqual("AND", tokens.Last().Tokens.Peek().TokenText);
        }

        [TestMethod()]
        [TestCategory("WhereParser")]
        public void TwoExpressionWithParenthesesTest()
        {
            WhereTokenParser parser = new WhereTokenParser();
            var tokens = parser.Parse("(it.Name().Length <EQ> '3') <AND> ((it.Age <NE> '30') <or> (it.Age <EQ> '18')) ").ToArray();
            Assert.AreEqual("AND", tokens.Last().Tokens.Peek().TokenText);
            Assert.AreEqual("or", tokens[9].Tokens.Peek().TokenText);
        }
    }
}