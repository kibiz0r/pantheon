macro send:
    case [| send $message |]:
        yield [| Pantheon.Universe.Current.Send($(MessageExpression(message))) |]

    otherwise:
        raise "wat"