using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Linq.Expressions;

namespace Pantheon.Test
{
    [TestFixture]
    public class Multiply
    {
        [Test]
        public void MultiplyIntegers()
        {
            Assert.That("5 * 3", Parses.To(5.Multiply(3)));
        }

        [Test]
        public void MultiplyChained()
        {
            Assert.That("3 * 5 * 9", Parses.To(3.Multiply(5).Multiply(9)));
        }
    }
}

