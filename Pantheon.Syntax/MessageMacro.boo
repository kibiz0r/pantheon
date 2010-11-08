macro message:
    case [| message $(MethodInvocationExpression(Target: target, Arguments: arguments)) |]:
        print "wat^2"
        yield [| MyDomainDomain.Foo() |]

    otherwise:
        for arg in message.Arguments:
            print arg