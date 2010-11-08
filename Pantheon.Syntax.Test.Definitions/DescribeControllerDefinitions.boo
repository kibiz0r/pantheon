namespace Pantheon.Syntax.Test.Definitions
import NUnit.Framework

controller DescribedController:
    message FailMessage:
        pass

    message MessageWithParens():
        pass

    message MessageWithArg(i as int):
        raise "got 5" if i == 5

    message MessageWithArgs(i as int, s as string):
        raise "got 42-foo" if i == 42 and s == "foo"
        raise "got 99-bar" if i == 99 and s == "bar"

    message MessageWithCoincidentalArg(o as object):
        pass

describe_controller DescribedController:
    when FailMessage:
        Assert.Fail()

    when MessageWithParens()

    when MessageWithArg(5):
        pass

    when MessageWithArgs(42, "foo"):
        pass

    when MessageWithArgs(99, "bar"):
        pass

    when MessageWithCoincidentalArg(8):
        pass

    when MessageWithCoincidentalArg("8"):
        pass

    when MessageWithCoincidentalArg(8.0):
        pass

    when MessageWithCoincidentalArg("8_1"):
        pass