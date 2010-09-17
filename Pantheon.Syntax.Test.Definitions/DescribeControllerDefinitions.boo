namespace Pantheon.Syntax.Test.Definitions
import NUnit.Framework

controller DescribedController:
    message SomeMessage

describe_controller DescribedController:
    when SomeMessage:
        Assert.Fail()