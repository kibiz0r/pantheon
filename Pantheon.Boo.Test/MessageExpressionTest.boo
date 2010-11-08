import NUnit.Framework
import Pantheon
import Boo.Lang.Compiler.Ast

[TestFixture]
class MessageExpressionTest:
    [Test]
    [Ignore]
    def SimpleMessageExpression():
        expected = [|
            Messages.Foo.FooMessage()
        |]
        actual = MessageExpression([| Foo |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    [Ignore]
    def TwoPartMessageExpression():
        expected = [|
            Messages.Foo.Bar.FooBarMessage()
        |]
        actual = MessageExpression([| Foo.Bar |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    [Ignore]
    def MessageWithArgs():
        expected = [|
            Messages.Foo.FooMessage(5, "hi")
        |]
        actual = MessageExpression([| Foo(5, "hi") |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    [Ignore]
    def TwoPartMessageWithArgs():
        expected = [|
            Messages.First.Second.FirstSecondMessage(1, 2)
        |]
        actual = MessageExpression([| First(1).Second(2) |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))