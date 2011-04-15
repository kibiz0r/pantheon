using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Linq.Expressions;

namespace Pantheon.Test
{
    [TestFixture]
    public class OperatorPrecedence
    {
        [Test]
        public void MultiplyBeforeAdd()
        {
            Assert.That("5 * 1 + 3", Parses.To(5.Multiply(1).Add(3)));
            Assert.That("3 + 1 * 5", Parses.To(3.Add(1.Multiply(5))));
            Assert.That("12 + 45 * 9 * 10 + 38 + 121 * 24", Parses.To(
                12.Add(45.Multiply(9).Multiply(10)).Add(38).Add(121.Multiply(24))
            ));
        }
    }
}

