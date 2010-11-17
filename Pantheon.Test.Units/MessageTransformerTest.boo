import NUnit.Framework
import Pantheon
import Boo.Lang.Compiler.Ast

[TestFixture]
class MessageTransformerTest:
    [Test]
    def SimpleMessage():
        expected = [|
            def MyMessageTransformer(message as Pantheon.Message):
                try:
                    FooMessage()
        |]
        actual = MessageTransformer([| Foo |], [| MyMessageTransformer |], [| FooMessage |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    def SimpleMessageAsCall():
        expected = [|
            def AnotherMessageTransformer(message as Pantheon.Message):
                try:
                    Blah()
        |]
        actual = MessageTransformer([| Bar() |], [| AnotherMessageTransformer |], [| Blah |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    def MessageWithArg():
        expected = [|
            def MyMessageTransformer(message as Pantheon.Message):
                try:
                    i = message.Arguments[0] as int
                    FooMessage(i)
        |]
        actual = MessageTransformer([| Msg(i as int) |], [| MyMessageTransformer |], [| FooMessage |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))

    [Test]
    def MessageWithTwoArgs():
        expected = [|
            def MyMessageTransformer(message as Pantheon.Message):
                try:
                    i = message.Arguments[0] as int
                    j = message.Arguments[1] as string
                    FooMessage(i, j)
        |]
        actual = MessageTransformer([| Msg(i as int, j as string) |], [| MyMessageTransformer |], [| FooMessage |])
        Assert.That(actual.ToCodeString(), Is.EqualTo(expected.ToCodeString()))