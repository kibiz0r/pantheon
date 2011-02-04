using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Pantheon.Test
{
    [TestFixture]
    public class OperatorPrecedence
    {
        [Test]
        public void MultiplyBeforeAdd()
        {
            Assert.That("5 * 1 + 3", Parses.To(5 * 1 + 3));
            Assert.That("3 + 1 * 5", Parses.To(3 + 1 * 5));
        }
    }
}

