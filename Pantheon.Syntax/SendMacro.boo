macro send:
    case [| send $message |]:
        yield [| Pantheon.Universe.Current.Send($(MessageExpression(message))) |]

    otherwise:
        for argument in send.Arguments:
            print argument