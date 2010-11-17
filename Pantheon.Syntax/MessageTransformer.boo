def MessageTransformerStatements(root as Expression, ref messageExpression as ReferenceExpression) as (Statement):
    match root:
        case MethodInvocationExpression(Target: MemberReferenceExpression(Target: parent = MethodInvocationExpression()), Arguments: arguments):
            parentStatements = MessageTransformerStatements(parent, messageExpression)
            messageExpression = [| $(messageExpression).ChildMessage |]
            statements = List[of Statement]()
            i = -1
            for argument in arguments:
                i++
                match argument:
                    case TryCastExpression(Target: target, Type: type):
                        statements.Add(ExpressionStatement([| $target = $(messageExpression).Arguments[$i] as $type |]))
            return parentStatements + statements.ToArray()

        case MethodInvocationExpression(Target: MemberReferenceExpression(Target: parent2 = ReferenceExpression(), Name: name), Arguments: arguments):
            return MessageTransformerStatements(MethodInvocationExpression(Target: [| $(parent2)().$(name) |], Arguments: arguments), messageExpression)

        case MethodInvocationExpression(Target: ReferenceExpression(), Arguments: arguments):
            statements = List[of Statement]()
            i = -1
            for argument in arguments:
                i++
                match argument:
                    case TryCastExpression(Target: target, Type: type):
                        statements.Add(ExpressionStatement([| $target = $(messageExpression).Arguments[$i] as $type |]))
            return statements.ToArray()

        case ReferenceExpression():
            return MessageTransformerStatements([| $(root)() |], messageExpression)

def MessageTransformerCallbackArguments(root as Expression) as (Expression):
    match root:
        case MethodInvocationExpression(Target: MemberReferenceExpression(Target: parent = MethodInvocationExpression()), Arguments: arguments):
            callbackArguments = List[of Expression]()
            for argument in arguments:
                match argument:
                    case TryCastExpression(Target: target):
                        callbackArguments.Add(target)
            return MessageTransformerCallbackArguments(parent) + callbackArguments.ToArray()

        case MethodInvocationExpression(Target: MemberReferenceExpression(Target: parent2 = ReferenceExpression(), Name: name), Arguments: arguments):
            return MessageTransformerCallbackArguments(MethodInvocationExpression(Target: [| $(parent2)().$(name) |], Arguments: arguments))

        case MethodInvocationExpression(Target: ReferenceExpression(), Arguments: arguments):
            callbackArguments = List[of Expression]()
            for argument in arguments:
                match argument:
                    case TryCastExpression(Target: target):
                        callbackArguments.Add(target)
            return callbackArguments.ToArray()

        case ReferenceExpression():
            return MessageTransformerCallbackArguments([| $(root)() |])

def MessageTransformer(message as Expression, name as ReferenceExpression, callback as ReferenceExpression) as Method:
    _ = [| message |]
    statements = MessageTransformerStatements(message, _)
    callbackArguments = MessageTransformerCallbackArguments(message)
    return [|
        def $(name)(message as Pantheon.Message):
            try:
                $(Block(*statements))
                $(MethodInvocationExpression(callback, *callbackArguments))
    |]