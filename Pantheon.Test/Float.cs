using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Pantheon.Test
{
    [TestFixture]
    public class Float
    {
        [Test]
        public void Parses3_5f()
        {
            Assert.That("3.5f", Parses.To(3.5f));
        }

        [Test]
        public void Parses_5f()
        {
            Assert.That(".5f", Parses.To(.5f));
        }

        [Test]
        public void ParsesNegative_5f()
        {
            Assert.That("-.501f", Parses.To(-.501f));
        }
    }
}

