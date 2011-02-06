using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Linq.Expressions;

namespace Pantheon.Test
{
    [TestFixture]
    public class Add
    {
        [Test]
        public void AddIntegers()
        {
            Assert.That("3 + 2", Parses.To(3.Add(2)));
        }

        [Test]
        public void AddFloats()
        {
            Assert.That("3.2f + 2.4f", Parses.To(3.2f.Add(2.4f)));
        }

        [Test]
        public void AddDoubles()
        {
            Assert.That("6.8 + 9.1", Parses.To(6.8.Add(9.1)));
        }

        [Test]
        public void AddIntegerAndFloat()
        {
            Assert.That("4 + 6.2f", Parses.To(4.Convert<float>().Add(6.2f)));
        }

        [Test]
        public void AddIntegersChained()
        {
            Assert.That("1 + 2 + 3 + 4", Parses.To(1.Add(2).Add(3).Add(4)));
        }

        [Test]
        public void AddMixedChained()
        {
            Assert.That("2.2f + 4 + 9.8 + 2 + 6.6", Parses.To(2.2f.Add(4.Convert<float>()).Convert<double>().Add(9.8).Add(2.Convert<double>()).Add(6.6)));
            Assert.That("2.2f + 4 + 9.8 + 2 + 6.6", Evaluates.ToApproximately(2.2f + 4 + 9.8 + 2 + 6.6));
        }
    }
}

