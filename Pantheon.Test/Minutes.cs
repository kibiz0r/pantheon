using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Pantheon.Test
{
    [TestFixture]
    public class Minutes
    {
        [Test]
        public void Parses23_2m()
        {
            Assert.That("23.2m", Parses.To(TimeSpan.FromMinutes(23.2)));
        }
    }
}

