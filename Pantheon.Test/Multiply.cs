using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Pantheon.Test
{
    [TestFixture]
    public class Multiply
    {
        [Test]
        public void MultipliesIntegers()
        {
            Assert.That("5 * 3", Parses.To(3 * 5));
        }
    }
}

