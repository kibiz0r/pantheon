import NUnit.Framework
import Pantheon
import Boo.Lang.Compiler.Ast

[TestFixture]
class MessageExpressionTest:
    [Test]
    def SimpleMessageExpression():
        expected = [|
            Pantheon.Message("Foo")
        |]
        actual = MessageExpression([| Foo |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    def SimpleMessageInvocationExpression():
        expected = [|
            Pantheon.Message("Foo")
        |]
        actual = MessageExpression([| Foo() |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    def TwoPartMessageExpression():
        expected = [|
            Pantheon.Message("Foo", ChildMessage: Pantheon.Message("Bar"))
        |]
        actual = MessageExpression([| Foo.Bar |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    def ThreePartMessageExpression():
        expected = [|
            Pantheon.Message("Foo", ChildMessage: Pantheon.Message("Bar", ChildMessage: Pantheon.Message("Baz")))
        |]
        actual = MessageExpression([| Foo.Bar.Baz |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    def MessageWithArgs():
        expected = [|
            Pantheon.Message("Foo", 5, "hi")
        |]
        actual = MessageExpression([| Foo(5, "hi") |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    def TwoPartMessageWithArgs():
        expected = [|
            Pantheon.Message("First", 1, ChildMessage: Pantheon.Message("Second", 2))
        |]
        actual = MessageExpression([| First(1).Second(2) |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))