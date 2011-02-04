using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Pantheon.Test
{
    [TestFixture]
    public class Integer
    {
        [Test]
        public void Parses45()
        {
            Assert.That("45", Parses.To(45));
        }

        [Test]
        public void Parses2()
        {
            Assert.That("2", Parses.To(2));
        }

        [Test]
        public void ParsesNegative5()
        {
            Assert.That("-5", Parses.To(-5));
        }
    }
}

