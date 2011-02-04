macro send:
    case [| send $message |]:
        messageExpression = MessageExpression(message)
        if messageExpression:
            yield [| Pantheon.Universe.Current.Send($(messageExpression)) |]

    otherwise:
        raise "wat"