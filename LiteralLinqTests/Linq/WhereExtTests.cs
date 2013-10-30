using LiteralLinq.Expression.Compiler.PredefinedConverter;
using LiteralLinq.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteralLinq.Linq.Tests
{
    [TestClass()]
    public class WhereExtTests
    {
        [TestMethod()]
        [TestCategory("Where")]
        public void WhereOnePropertyTest()
        {
            var data = (Enumerable.Range(0, 100)).AsQueryable();
            var expected = 50;
            var actual = data.Where("it <GE> '50'").Count();
            Assert.AreEqual(expected, actual);
        }
    }
}