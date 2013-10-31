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
    internal class MasterData2
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public double? Discount()
        {
            return Price >= 20 ? (double?)3.4 : null;
        }

        public DetailData2 Detail { get; set; }
    }

    internal class DetailData2
    {
        public int Quantity { get; set; }

        public DateTime? ShipDate { get; set; }

        public int? Rank { get; set; }
    }

    [TestClass()]
    public class WhereExtTests
    {
        private IQueryable<MasterData2> source = new List<MasterData2> {
            new MasterData2{Id=1,Price=5,Detail=new DetailData2{Quantity=10,Rank=4}},
            new MasterData2{Id=2,Price=10,Detail=new DetailData2{Quantity=2,Rank=4}},
            new MasterData2{Id=3,Price=15,Detail=new DetailData2{Quantity=4,Rank=1,ShipDate=DateTime.Today}},
            new MasterData2{Id=4,Price=20,Detail=new DetailData2{Quantity=6,Rank=2}},
            new MasterData2{Id=5,Price=25,Detail=new DetailData2{Quantity=4,Rank=3}},
        }.AsQueryable();

        [TestMethod()]
        [TestCategory("Where")]
        public void WhereOnePropertyTest()
        {
            var data = (Enumerable.Range(0, 100)).AsQueryable();
            var expected = 50;
            var actual = data.Where("it <GE> '50'").Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [TestCategory("Where")]
        public void WhereTwoPropertyTest()
        {
            var data = (Enumerable.Range(0, 100)).AsQueryable();
            var expected = 25;
            var actual = data.Where("it <GE> '50' <and> it <LT> '75'").Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [TestCategory("Where")]
        public void WhereComplexPropertyTest()
        {
            var dateFormat = "yyyy\\'MM\\'dd";
            var today = DateTime.Today.ToString(dateFormat).Replace("'", "\\'");
            var expected = 5;
            var exp = "it.Id <LT> '3' <OR> it.Discount() <NE> null <OR> it.Detail.ShipDate <EQ> '" + today + "'@'" + dateFormat.Replace("'", "\\'") + "'";
            var actual = source.Where(exp).Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [TestCategory("Where")]
        public void WhereParenthesesTest()
        {
            var expected = 5;
            var exp = "(it.Detail.Rank <GT> '2' <AND> it.Id <LE> '3') <OR> it.Detail.Quantity <GE> '4' ";
            var actual = source.Where(exp).Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [TestCategory("Where")]
        public void WhereArrayValueTest()
        {
            var expected = 2;
            var exp = "it.Id <IN> ['1','2']";
            var actual = source.Where(exp).Count();
            Assert.AreEqual(expected, actual);

            expected = 1;
            exp = "it.Id <IN> ['1']";
            actual = source.Where(exp).Count();
            Assert.AreEqual(expected, actual);

            expected = 0;
            exp = "it.Id <IN> []";
            actual = source.Where(exp).Count();
            Assert.AreEqual(expected, actual);

            expected = 1;
            exp = "it.Detail.ShipDate <IN> ['" + DateTime.Today.ToString("yyyy-MM-dd") + "']@'yyyy-MM-dd'";
            actual = source.Where(exp).Count();
            Assert.AreEqual(expected, actual);
        }
    }
}