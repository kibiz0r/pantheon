using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Pantheon.Test
{
    [TestFixture]
    public class Days
    {
        [Test]
        public void Parses7d()
        {
            Assert.That("7d", Parses.To(TimeSpan.FromDays(7)));
        }
    }
}

