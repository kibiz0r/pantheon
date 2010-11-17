def MessageTransformer(message as Expression, name as ReferenceExpression, callback as ReferenceExpression) as Method:
    match message:
        case MethodInvocationExpression(Arguments: arguments):
            statements = List[of Statement]()
            callbackArguments = List[of ReferenceExpression]()
            i = -1
            for argument in arguments:
                i++
                match argument:
                    case TryCastExpression(Target: target, Type: type):
                        statements.Add(ExpressionStatement([| $target = message.Arguments[$i] as $type |]))
                        callbackArguments.Add(target)
            return [|
                def $(name)(message as Pantheon.Message):
                    try:
                        $(Block(*statements.ToArray()))
                        $(MethodInvocationExpression(callback, *callbackArguments.ToArray()))
            |]

        case ReferenceExpression():
            return MessageTransformer([| $(message)() |], name, callback)