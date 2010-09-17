namespace Pantheon.Syntax.Test.Definitions
import NUnit.Framework

controller DescribedController:
    message FailMessage

describe_controller DescribedController:
    when FailMessage:
        Assert.Fail()

    when MessageWithParens():
        pass

    when MessageWithArgs(i as int, s as string):
        pass