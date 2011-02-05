using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Pantheon.Test
{
    [TestFixture]
    public class NumericPromotion
    {
        [Test]
        public void PromotesIntToFloat()
        {
            Assert.That("10", Parses.To(10f).WithRule(p => p.FloatExpr));
            Assert.That("10+20", Parses.To(30f).WithRule(p => p.FloatExpr));
        }

        [Test]
        public void PromotesIntToDouble()
        {
            Assert.That("5", Parses.To(5.0).WithRule(p => p.DoubleExpr));
            Assert.That("5+7", Parses.To(12.0).WithRule(p => p.DoubleExpr));
        }

        [Test]
        public void PromotesFloatToDouble()
        {
            Assert.That("5f", Parses.To(5.0).WithRule(p => p.DoubleExpr));
            Assert.That("5f+7f", Parses.To(12.0).WithRule(p => p.Add));
        }
    }
}

