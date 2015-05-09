using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteralLinq.Spec;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LiteralLinq.Spec.Tests
{
    [TestClass()]
    public class SpecificationTests
    {
        private class Model
        {
            public int Id { get; set; }
        }

        [TestMethod()]
        public void IsSatisfiedByTest()
        {
            var model = new Model
            {
                Id = 10
            };

            var spec = new LiteralSpecification<Model>("it.Id <EQ> '10'");
            var expression = spec.IsSatisfiedBy();
            var isSatisfiedBy = expression.Compile()(model);
            Assert.AreEqual(true, isSatisfiedBy);
            var spec2 = new LiteralSpecification<Model>("it <EQ> null");
            Assert.AreEqual(false, spec2.IsSatisfiedBy().Compile()(model));
        }
    }
}