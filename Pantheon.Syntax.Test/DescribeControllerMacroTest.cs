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
        public void WhenMessageWithArgShouldBeATest()
        {
            Assert.That(typeof(describe_controller_DescribedController).GetMethod("when_MessageWithArg"), Definitely.IsATest());
        }

        [Test]
        public void WhenMessageWithArgIsCalledWithArg()
        {
            var controller = new describe_controller_DescribedController();
            Assert.DoesNotThrow(() => controller.Controller.message_MessageWithArg(4));
            Assert.That(Assert.Throws<Exception>(() => controller.when_MessageWithArg()).Message, Is.EqualTo("got 5"));
        }

        [Test]
        public void WhenMessageWithArgsIsCalledWithArgs()
        {
            var controller = new describe_controller_DescribedController();
            Assert.DoesNotThrow(() => controller.Controller.message_MessageWithArgs(12, "bar"));
            Assert.That(Assert.Throws<Exception>(() => controller.when_MessageWithArgs()).Message, Is.EqualTo("got 42-foo"));
        }
    }
}

