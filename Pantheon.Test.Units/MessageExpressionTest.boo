import NUnit.Framework
import Pantheon
import Boo.Lang.Compiler.Ast

[TestFixture]
class MessageExpressionTest:
    [Test]
    def SimpleMessageExpression():
        expected = [|
            FooMessage()
        |]
        actual = MessageExpression([| Foo |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    def TwoPartMessageExpression():
        expected = [|
            FooMessage[of BarMessage](ChildMessage: BarMessage())
        |]
        actual = MessageExpression([| Foo.Bar |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    def ThreePartMessageExpression():
        expected = [|
            FooMessage[of BarMessage[of BazMessage]](ChildMessage: BarMessage[of BazMessage](ChildMessage: BazMessage()))
        |]
        actual = MessageExpression([| Foo.Bar.Baz |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    [Ignore]
    def MessageWithArgs():
        expected = [|
            Messages.Foo(5, "hi")
        |]
        actual = MessageExpression([| Foo(5, "hi") |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    [Ignore]
    def TwoPartMessageWithArgs():
        expected = [|
            Messages.First[of Messages.Second](1, ChildMessage: Messages.Second(2))
        |]
        actual = MessageExpression([| First(1).Second(2) |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))