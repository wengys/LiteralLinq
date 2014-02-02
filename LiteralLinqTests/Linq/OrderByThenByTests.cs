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

        /// <summary>
        /// This test shows how to sort a simple value type collection (such as an int collection)
        /// </summary>
        [TestMethod]
        [TestCategory("OrderBy")]
        public void OrderBySelfTest()
        {
            var rnd = new Random();
            var source2 = (new[]{
                rnd.Next(100),
                rnd.Next(100),
                rnd.Next(100),
                rnd.Next(100),
                rnd.Next(100)
            }).AsQueryable();
            var ascending1 = source2.OrderBy("it");//Just use "it" to represent a value in a collection, use default ascending order
            var ascending2 = source2.OrderBy("it asc");//Just use "it" to represent a value in a collection, use explicit ascending order

            var descending = source2.OrderBy("it desc");//Descending order

            CollectionAssert.AreEqual(source2.OrderBy(it => it).ToArray(), ascending1.ToArray());
            CollectionAssert.AreEqual(source2.OrderBy(it => it).ToArray(), ascending2.ToArray());
            CollectionAssert.AreEqual(source2.OrderByDescending(it => it).ToArray(), descending.ToArray());
        }

        /// <summary>
        /// This test shows how to sort a complex type collection by one of it's property
        /// </summary>
        [TestMethod()]
        [TestCategory("OrderBy")]
        public void OrderByOnePropertyTest()
        {
            var actual = source.OrderBy(" it.Id ");//Order By Id field,
            var expected = source.OrderBy(it => it.Id);
            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());

            actual = source.OrderBy(" it.Id desc ");
            expected = source.OrderByDescending(it => it.Id);
            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
        }

        /// <summary>
        /// This test shows how to sort by sub Property or parameterless function
        /// </summary>
        [TestMethod()]
        [TestCategory("OrderBy")]
        public void OrderByComplexPathTest()
        {
            var actual1 = source.OrderBy(" it.Detail.Rank desc ");//Sort by Detail.Rank property, descending order
            var expected1 = source.OrderByDescending(it => it.Detail.Rank);
            CollectionAssert.AreEqual(expected1.ToArray(), actual1.ToArray());

            var actual2 = source.OrderBy(" it.TotalPrice() ");//Sort by a parameterless function
            var expected2 = source.OrderBy(it => it.TotalPrice());
            CollectionAssert.AreEqual(expected2.ToArray(), actual2.ToArray());
        }

        /// <summary>
        /// This test shows how to sort by multiple paths in one query
        /// </summary>
        [TestMethod()]
        [TestCategory("OrderBy")]
        public void OrderByMultiplePathsTest()
        {
            var actual = source.OrderBy(" it.Detail.Rank desc,it.TotalPrice() ");
            var expected = source.OrderByDescending(it => it.Detail.Rank).ThenBy(it => it.TotalPrice());
            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
        }

        /// <summary>
        /// This test shows how to perform a subsequent sorting
        /// </summary>
        [TestMethod()]
        [TestCategory("OrderBy")]
        public void ThenByTest()
        {
            var actual = source.OrderByDescending(it => it.Detail.Rank).ThenBy(" it.TotalPrice() desc");
            var expected = source.OrderByDescending(it => it.Detail.Rank).ThenByDescending(it => it.TotalPrice());
            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
        }
    }
}