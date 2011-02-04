using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Pantheon.Test
{
    [TestFixture]
    public class Milliseconds
    {
        [Test]
        public void Parses14_53ms()
        {
            Assert.That("14.53ms", Parses.To(TimeSpan.FromMilliseconds(14.53)));
        }
    }
}

