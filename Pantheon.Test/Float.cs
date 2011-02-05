using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Linq.Expressions;

namespace Pantheon.Test
{
    [TestFixture]
    public class Float
    {
        [Test]
        public void Parses3_5f()
        {
            Assert.That("3.5f", Parses.To(Expression.Constant(3.5f)));
        }

        [Test]
        public void Parses_5f()
        {
            Assert.That(".5f", Parses.To(Expression.Constant(.5f)));
        }

        [Test]
        public void ParsesNegative_5f()
        {
            Assert.That("-.501f", Parses.To(Expression.Constant(-.501f)));
        }
    }
}

