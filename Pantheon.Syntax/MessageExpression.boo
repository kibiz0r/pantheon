def MessageExpressionFromName(name as string):
    return [| $(ReferenceExpression("${name}Message"))() |]

def ParentExpression(root as Expression, childGeneric as Expression, childInstantiation as Expression) as MethodInvocationExpression:
    match root:
        case MemberReferenceExpression(Target: target, Name: name):
            myGeneric = [| $(ReferenceExpression("${name}Message"))[of $childGeneric] |]
            myInstantiation = [| $(ReferenceExpression("${name}Message"))[of $childGeneric](ChildMessage: $childInstantiation) |]
            return ParentExpression(target, myGeneric, myInstantiation)
        case ReferenceExpression(Name: name):
            return [| $(ReferenceExpression("${name}Message"))[of $childGeneric](ChildMessage: $childInstantiation) |]

def MessageExpression(root as Expression) as MethodInvocationExpression:
    match root:
        case [| $(MemberReferenceExpression(Target: target, Name: name)) |]:
            myGeneric = ReferenceExpression("${name}Message")
            myInstantiation = [| $(myGeneric)() |]
            return ParentExpression(target, myGeneric, myInstantiation)
        case [| $(ReferenceExpression(Name: name)) |]:
            return MessageExpressionFromName(name)

def MessageWithChildExpression(root as Expression, child as Expression) as MethodInvocationExpression:
    pass

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