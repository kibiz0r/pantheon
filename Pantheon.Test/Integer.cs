using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Linq.Expressions;

namespace Pantheon.Test
{
    [TestFixture]
    public class Integer
    {
        [Test]
        public void Parses45()
        {
            Assert.That("45", Parses.To(Expression.Constant(45)));
        }

        [Test]
        public void Parses2()
        {
            Assert.That("2", Parses.To(Expression.Constant(2)));
        }

        [Test]
        public void ParsesNegative5()
        {
            Assert.That("-5", Parses.To(Expression.Constant(-5)));
        }
    }
}

