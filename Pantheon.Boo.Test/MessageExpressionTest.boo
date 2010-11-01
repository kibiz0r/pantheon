import NUnit.Framework
import Pantheon
import Boo.Lang.Compiler.Ast

[TestFixture]
class MessageExpressionTest:
    [Test]
    def SimpleMessageExpression():
        expected = [| Message(MessageComponent("Foo")) |]
        actual = MessageExpression([| Foo |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    def TwoPartMessageExpression():
        expected = [| Message(MessageComponent("Foo"), MessageComponent("Bar")) |]
        actual = MessageExpression([| Foo.Bar |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    def MessageWithArgs():
        expected = [| Message(MessageComponent("Foo", 5, "hi")) |]
        actual = MessageExpression([| Foo(5, "hi") |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    def TwoPartMessageWithArgs():
        expected = [| Message(MessageComponent("First", 1), MessageComponent("Second", 2)) |]
        actual = MessageExpression([| First(1).Second(2) |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))