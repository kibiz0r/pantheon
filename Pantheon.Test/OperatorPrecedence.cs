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
        }
    }
}

