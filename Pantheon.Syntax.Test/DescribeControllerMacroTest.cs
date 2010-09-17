using System;
using Pantheon.Syntax.Test.Definitions;
using NUnit.Framework;

namespace Pantheon.Syntax.Test
{
    [TestFixture]
    public class DescribeControllerMacroTest
    {
        [Test]
        public void ShouldBeAControllerTest()
        {
            Assert.That(typeof(describe_controller_DescribedController).BaseType, Is.EqualTo(typeof(ControllerTest<controller_DescribedController>)));
        }

        [Test]
        public void WhenShouldBeATest()
        {
            var when = typeof(describe_controller_DescribedController).GetMethod("when_SomeMessage");
            Assert.That(when, Is.Not.Null);
            Assert.That(when, Has.Attribute<TestAttribute>());
        }

        [Test]
        [ExpectedException(typeof(AssertionException))]
        public void WhenSomeMessageShouldFail()
        {
            var controller = new describe_controller_DescribedController();
            controller.when_SomeMessage();
        }
    }
}

