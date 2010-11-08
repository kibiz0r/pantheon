def MessageExpression(root as Expression):
    return MethodInvocationExpression(ReferenceExpression("Message"), *MessageComponents(root))

def MessageComponents(root as Expression) as (Expression):
    match root:
        case [| $(MemberReferenceExpression(Target: target, Name: name)) |]:
            return MessageComponents(target) + (of Expression: [| MessageComponent($name) |])
        case [| $(ReferenceExpression(Name: name)) |]:
            return (of Expression: [| MessageComponent($name) |])
        case [| $(MethodInvocationExpression(Target: MemberReferenceExpression(Target: target, Name: name),
            Arguments: arguments)) |]:
            return MessageComponents(target) + (of Expression: MethodInvocationExpression(
                ReferenceExpression("MessageComponent"),
                *((of Expression: StringLiteralExpression(name)) + arguments.ToArray())
            ))
        case [| $(MethodInvocationExpression(Target: ReferenceExpression(Name: name), Arguments: arguments)) |]:
            return (of Expression: MethodInvocationExpression(
                ReferenceExpression("MessageComponent"),
                *((of Expression: StringLiteralExpression(name)) + arguments.ToArray())
            ))