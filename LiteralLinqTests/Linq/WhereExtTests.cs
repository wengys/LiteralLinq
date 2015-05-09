using LiteralLinq.Expression.Design;
using LiteralLinqTests.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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

        [LiteralConverterAttribute(typeof(LLPointConverter))]
        public GeoPoint Geolocation { get; set; }

        [LiteralConverterAttribute(typeof(LLPointConverter))]
        public GeoPoint GetBaseLocation()
        {
            return new GeoPoint(1, 1, 1);
        }
    }

    [TestClass()]
    public class WhereExtTests
    {
        private IQueryable<MasterData2> source = new List<MasterData2> {
            new MasterData2{Id=1,Price=5,Detail=new DetailData2{Quantity=10,Rank=4}},
            new MasterData2{Id=2,Price=10,Detail=new DetailData2{Quantity=2,Rank=4}},
            new MasterData2{Id=3,Price=15,Detail=new DetailData2{Quantity=4,Rank=1,ShipDate=DateTime.Today,Geolocation=new GeoPoint(10,10,10)}},
            new MasterData2{Id=4,Price=20,Detail=new DetailData2{Quantity=6,Rank=2}},
            new MasterData2{Id=5,Price=25,Detail=new DetailData2{Quantity=4,Rank=3}},
        }.AsQueryable();

        /// <summary>
        /// This test shows filtering a simple collection with one condition
        /// </summary>
        [TestMethod()]
        [TestCategory("Where")]
        public void WhereOneConditionTest()
        {
            var data = (Enumerable.Range(0, 100)).AsQueryable();
            var expected = 50;
            var actual = data.Where("it <GE> '50'").Count();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// This test shows filtering a collection with two conditions
        /// </summary>
        [TestMethod()]
        [TestCategory("Where")]
        public void WhereTwoConditionsTest()
        {
            var data = (Enumerable.Range(0, 100)).AsQueryable();
            var expected = 25;
            var actual = data.Where("it <GE> '50' <and> it <LT> '75'").Count();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// This test shows how to handle DateTime value
        /// </summary>
        [TestMethod()]
        [TestCategory("Where")]
        public void WhereDateTimeValueTest()
        {
            var expected = source.Where(s => s.Detail.ShipDate == DateTime.Today);
            var todayStr = DateTime.Today.ToString("yyyy-MM-dd");
            var exp1 = " it.Detail.ShipDate <eq> '" + todayStr + "'";//Default format string for DateTime is yyyy-MM-dd
            var actual1 = source.Where(exp1);
            CollectionAssert.AreEqual(expected.ToArray(), actual1.ToArray());

            var exp2 = " it.Detail.ShipDate <eq> '" + todayStr + "'@'yyyy-MM-dd'";//Explicitly set format string
            var actual2 = source.Where(exp2);
            CollectionAssert.AreEqual(expected.ToArray(), actual2.ToArray());
        }

        /// <summary>
        /// This test shows how to handle enum value
        /// </summary>
        [TestMethod()]
        [TestCategory("Where")]
        public void WhereEnumValueTest()
        {
            var source2 = Enum.GetValues(typeof(System.DayOfWeek)).Cast<System.DayOfWeek>().AsQueryable<System.DayOfWeek>();
            var actual = source2.Where("it <EQ> 'Monday'").Count();//Default converter use name of the enum value, not value of the enum value
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// This test shows how to handle null value
        /// </summary>
        [TestMethod()]
        [TestCategory("Where")]
        public void WhereNullValueTest()
        {
            var expected = source.Where(s => s.Discount() != null);
            var exp = " it.Discount() <NE> null ";
            var actual = source.Where(exp);
            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
        }

        /// <summary>
        /// This test shows how to handle value which contains single quotation mark
        /// </summary>
        [TestMethod()]
        [TestCategory("Where")]
        public void WhereValueContainsEscapeCharTest()
        {
            var source2 = (new[] { "a'1", "b'2" }).AsQueryable();
            var expeced = 1;
            var exp = @"it <eq> 'a\'1'";//Use blackslash as escape char
            //Another format: var exp="it <eq> 'a\\'1'";
            var actual = source2.Where(exp).Count();
            Assert.AreEqual(expeced, actual);
        }

        /// <summary>
        /// This test shows how to use custom value formatter
        /// </summary>
        [TestMethod()]
        [TestCategory("Where")]
        public void WhereCustomValueFormatterTest()
        {
            var dateFormat = "yyyy@MM@dd";
            var today = DateTime.Today.ToString(dateFormat);
            var expected = source.Where(s => s.Detail.ShipDate == DateTime.Today);
            var exp = "it.Detail.ShipDate <EQ> '" + today + "'@'" + dateFormat + "'";
            var actual = source.Where(exp);
            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
        }

        /// <summary>
        /// This test shows how to change default order of filter expressions
        /// </summary>
        [TestMethod()]
        [TestCategory("Where")]
        public void WhereParenthesesTest()
        {
            var expected = source.Where(s => (s.Detail.Rank > 2 && s.Id <= 3) || s.Detail.Quantity >= 4);
            var exp = "(it.Detail.Rank <GT> '2' <AND> it.Id <LE> '3') <OR> it.Detail.Quantity <GE> '4' ";
            var actual = source.Where(exp);
            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
        }

        /// <summary>
        /// This test shows how to handle value collection
        /// </summary>
        [TestMethod()]
        [TestCategory("Where")]
        public void WhereArrayValueTest()
        {
            var expected1 = source.Where(s => (new[] { 1, 2 }).Contains(s.Id));
            var exp = "it.Id <IN> ['1','2']";//Test to see if Id field is 1 or 2
            var actual1 = source.Where(exp);
            CollectionAssert.AreEqual(expected1.ToArray(), actual1.ToArray());

            var expected2 = 0;
            exp = "it.Id <IN> []";//Empty value collection
            var actual2 = source.Where(exp).Count();
            Assert.AreEqual(expected2, actual2);

            var expected3 = source.Where(s => !(new DateTime?[] { DateTime.Today }).Contains(s.Detail.ShipDate));
            exp = "it.Detail.ShipDate <NOT IN> ['" + DateTime.Today.ToString("yyyy-MM-dd") + "']@'yyyy-MM-dd'";//Custom formatter
            var actual3 = source.Where(exp);
            CollectionAssert.AreEqual(expected3.ToArray(), actual3.ToArray());
        }

        /// <summary>
        /// This test shows how to handle string value with like operation
        /// </summary>
        [TestMethod()]
        [TestCategory("Where")]
        public void WhereStringLikeOperTest()
        {
            var monthes = (new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", " October", " November", " December" }).AsQueryable();

            var expected1 = monthes.Where(m => m.Contains("mb"));
            var actual1 = monthes.Where("it <like> '%mb%'");
            CollectionAssert.AreEqual(expected1.ToArray(), actual1.ToArray());

            var expected2 = monthes.Where(m => m.EndsWith("ary"));
            var actual2 = monthes.Where("it <like> '%ary'");
            CollectionAssert.AreEqual(expected2.ToArray(), actual2.ToArray());

            var expected3 = monthes.Where(m => m.StartsWith("Ma"));
            var actual3 = monthes.Where("it <like> 'Ma%'");
            CollectionAssert.AreEqual(expected3.ToArray(), actual3.ToArray());
        }

        /// <summary>
        /// One example of multiple conditions handling
        /// </summary>
        [TestMethod()]
        [TestCategory("Where")]
        public void WhereComplexPropertyWithValueContainsEscapeCharTest()
        {
            var dateFormat = "yyyy\\'MM\\'dd";
            var today = DateTime.Today.ToString(dateFormat).Replace("'", "\\'");
            var expected = 5;
            var exp = "it.Id <LT> '3' <OR> it.Discount() <NE> null <OR> it.Detail.ShipDate <EQ> '" + today + "'@'" + dateFormat.Replace("'", "\\'") + "'";
            var actual = source.Where(exp).Count();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// This test shows custom converter attribute usage
        /// </summary>
        [TestMethod()]
        [TestCategory("Where")]
        public void WhereCustomConverterAttributeInPropertyTest()
        {
            var actual = source.Where(s => s.Detail.Geolocation == new GeoPoint(10, 10, 10));//As Equals method does not work on an EntityFramework environment, operation== must be implement. See GeoPoint.cs
            var expeced = source.Where("it.Detail.Geolocation <eq> '10,10,10'");//Check Detail.Geolocation above
            CollectionAssert.AreEqual(expeced.ToArray(), actual.ToArray());

            var actual2 = source.Where(s => s.Detail.GetBaseLocation() == (new GeoPoint(1, 1, 1)));
            var expeced2 = source.Where("it.Detail.GetBaseLocation() <eq> '1,1,1'");
            CollectionAssert.AreEqual(expeced2.ToArray(), actual2.ToArray());
        }

        /// <summary>
        /// This test shows custom converter attribute usage
        /// </summary>
        [TestMethod()]
        [TestCategory("Where")]
        public void WhereCustomConverterAttributeInClassOrStructTest()
        {
            var source2 = (new[] { new GeoPoint2(1, 1, 1), new GeoPoint2(2, 2, 2) }).AsQueryable();
            var actual = source2.Where(s => s == (new GeoPoint2(1, 1, 1)));
            var expeced = source2.Where("it <eq> '1,1,1'");//The class GeoPoint2 has a custom converter attribute
            CollectionAssert.AreEqual(expeced.ToArray(), actual.ToArray());
        }

        /// <summary>
        /// This test shows global custom converter
        /// </summary>
        [TestMethod()]
        [TestCategory("Where")]
        public void WhereCustomConverterInGlobalTest()
        {
            LiteralLinqSettings.RegistConverter<GeoPoint>(new LLPointConverter());//Regist global converter
            var source2 = (new[] { new GeoPoint(1, 1, 1), new GeoPoint(2, 2, 2) }).AsQueryable();
            var actual = source2.Where(s => s == (new GeoPoint(1, 1, 1)));
            var expeced = source2.Where("it <eq> '1,1,1'");
            CollectionAssert.AreEqual(expeced.ToArray(), actual.ToArray());
        }
    }
}