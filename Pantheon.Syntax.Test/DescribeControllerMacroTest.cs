using System;
using Pantheon.Syntax.Test.Definitions;
using NUnit.Framework;
using Pantheon.Test;

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
        public void WhenFailMessageShouldBeATest()
        {
            var when = typeof(describe_controller_DescribedController).GetMethod("when_FailMessage");
            Assert.That(when, Is.Not.Null);
            Assert.That(when, Has.Attribute<TestAttribute>());
        }

        [Test]
        [ExpectedException(typeof(AssertionException))]
        public void WhenFailMessageShouldFail()
        {
            var controller = new describe_controller_DescribedController();
            controller.when_FailMessage();
        }

        [Test]
        public void WhenMessageWithParensShouldBeATest()
        {
            Assert.That(typeof(describe_controller_DescribedController).GetMethod("when_MessageWithParens"), Definitely.IsATest());
        }

        [Test]
        public void WhenMessageWithArgsShouldBeATest()
        {
            Assert.That(typeof(describe_controller_DescribedController).GetMethod("when_MessageWithArgs"), Definitely.IsATest());
        }

        [Test]
        public void WhenMessageWithArgsMustExist()
        {
            Assert.That(typeof(controller_DescribedController).GetMethod("message_MessageWithArgs"), Is.Not.Null);
        }
    }
}

