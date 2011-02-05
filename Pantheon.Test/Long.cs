using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Linq.Expressions;

namespace Pantheon.Test
{
    [TestFixture]
    public class Long
    {
        [Test]
        public void Parses63l()
        {
            Assert.That("63l", Parses.To(Expression.Constant(63L)));
        }

        [Test]
        public void Parses63L()
        {
            Assert.That("63L", Parses.To(Expression.Constant(63L)));
        }
    }
}

