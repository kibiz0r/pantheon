using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Pantheon.Test
{
    [TestFixture]
    public class Add
    {
        [Test]
        public void AddIntegers()
        {
            Assert.That("3 + 2", Parses.To(5));
        }

        [Test]
        public void AddFloats()
        {
            Assert.That("3.2f + 2.4f", Parses.To(3.2f + 2.4f));
        }

        [Test]
        public void AddDoubles()
        {
            Assert.That("6.8 + 9.1", Parses.To(6.8 + 9.1));
        }

        [Test]
        public void AddIntegerAndFloat()
        {
            Assert.That("4 + 6.2f", Parses.To(4 + 6.2f));
        }

        [Test]
        public void AddIntegersChained()
        {
            Assert.That("1 + 2 + 3 + 4", Parses.To(1 + 2 + 3 + 4));
        }

        [Test]
        public void AddMixedChained()
        {
            Assert.That("2.2f + 4 + 9.8 + 2 + 6.6", Parses.To(2.2f + 4 + 9.8 + 2 + 6.6));
        }
    }
}

