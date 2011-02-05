using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Pantheon.Test
{
    [TestFixture]
    public class Multiply
    {
        [Test]
        public void MultiplyIntegers()
        {
            Assert.That("5 * 3", Parses.To(3 * 5));
        }

        [Test]
        public void MultiplyChained()
        {
            Assert.That("3 * 5 * 9", Parses.To(3 * 5 * 9));
        }
    }
}

