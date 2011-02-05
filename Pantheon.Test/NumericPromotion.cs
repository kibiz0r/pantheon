using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Linq.Expressions;

namespace Pantheon.Test
{
    [TestFixture]
    public class NumericPromotion
    {
        [Test]
        public void PromotesIntToFloat()
        {
            Assert.That("10", Parses.To(10.Convert<float>()).WithRule(p => p.FloatExpr));
            Assert.That("10+20", Parses.To(10.Add(20).Convert<float>()).WithRule(p => p.FloatExpr));
        }

        [Test]
        public void PromotesIntToDouble()
        {
            Assert.That("5", Parses.To(5.Convert<double>()).WithRule(p => p.DoubleExpr));
            Assert.That("5+7", Parses.To(5.Add(7).Convert<double>()).WithRule(p => p.DoubleExpr));
        }

        [Test]
        public void PromotesFloatToDouble()
        {
            Assert.That("5f", Parses.To(5f.Convert<double>()).WithRule(p => p.DoubleExpr));
            Assert.That("5f+7f", Parses.To(5f.Add(7f).Convert<double>()).WithRule(p => p.DoubleExpr));
        }
    }
}

