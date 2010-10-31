macro send:
    case [| send $(ReferenceExpression(Name: name)) |]:
        messageName = MakeMessageType(name)
        yield [| Pantheon.Universe.Current.Send() |]

    case [| send $(MethodInvocationExpression(Target: target)) |]:
        yield [| Pantheon.Universe.Current.Send() |]

    otherwise:
        for argument in send.Arguments:
            print argument