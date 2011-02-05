using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Linq.Expressions;

namespace Pantheon.Test
{
    [TestFixture]
    public class Days
    {
        [Test]
        public void Parses7d()
        {
            Assert.That("7d", Parses.To(Expression.Constant(TimeSpan.FromDays(7))));
        }
    }
}

