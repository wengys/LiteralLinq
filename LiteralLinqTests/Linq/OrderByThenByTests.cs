using LiteralLinq.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteralLinq.Linq.Tests
{
    internal class MasterData
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public double TotalPrice()
        {
            return Price * Quantity;
        }

        public DetailData Detail { get; set; }
    }

    internal class DetailData
    {
        public int Rank { get; set; }
    }

    [TestClass()]
    public class QueryableExtTests
    {
        private IQueryable<MasterData> source = new List<MasterData> {
            new MasterData{Id=1,Price=1.2,Quantity=10,Detail=new DetailData{Rank=4}},
            new MasterData{Id=5,Price=2.2,Quantity=2,Detail=new DetailData{Rank=4}},
            new MasterData{Id=9,Price=3.2,Quantity=4,Detail=new DetailData{Rank=1}},
            new MasterData{Id=7,Price=4.2,Quantity=6,Detail=new DetailData{Rank=2}},
            new MasterData{Id=4,Price=5.2,Quantity=4,Detail=new DetailData{Rank=1}},
        }.AsQueryable();

        [TestMethod()]
        [TestCategory("OrderBy")]
        public void OrderByOnePropertyTest()
        {
            var actual = source.OrderBy(" it.Id ");
            var expected = source.OrderBy(it => it.Id);
            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());

            actual = source.OrderBy(" it.Id desc ");
            expected = source.OrderByDescending(it => it.Id);
            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
        }

        [TestMethod()]
        [TestCategory("OrderBy")]
        public void OrderByComplexPropertyTest()
        {
            var actual = source.OrderBy(" it.Detail.Rank desc,it.TotalPrice() ");
            var expected = source.OrderByDescending(it => it.Detail.Rank).ThenBy(it => it.TotalPrice());
            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
        }

        [TestMethod()]
        [TestCategory("OrderBy")]
        public void OrderBySelfTest()
        {
            var source2 = (new int[] { 3, 2, 1, 4 }).AsQueryable();
            var actual = source2.OrderBy(" it desc ");
            var expected = source2.OrderByDescending(it => it);
            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
        }

        [TestMethod()]
        [TestCategory("OrderBy")]
        public void ThenByComplexPropertyTest()
        {
            var actual = source.OrderByDescending(it => it.Detail.Rank).ThenBy(" it.TotalPrice() desc");
            var expected = source.OrderByDescending(it => it.Detail.Rank).ThenByDescending(it => it.TotalPrice());
            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
        }
    }
}