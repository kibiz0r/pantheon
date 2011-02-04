def MessageExpressionFromName(name as string):
    return [| $(ReferenceExpression("${name}Message"))() |]

def ParentExpression(root as Expression, childInstantiation as Expression) as MethodInvocationExpression:
    match root:
        case MethodInvocationExpression(Target: MemberReferenceExpression(Target: target, Name: name), Arguments: arguments):
            myInstantiation = MethodInvocationExpression(
                ReferenceExpression("Pantheon.Message"),
                *((of Expression: StringLiteralExpression(name)) + arguments.ToArray())
            )
            myInstantiation.NamedArguments.Add([| ChildMessage: $childInstantiation |])
            return ParentExpression(target, myInstantiation)

        case MethodInvocationExpression(Target: ReferenceExpression(Name: name), Arguments: arguments):
            myInstantiation = MethodInvocationExpression(
                ReferenceExpression("Pantheon.Message"),
                *((of Expression: StringLiteralExpression(name)) + arguments.ToArray())
            )
            myInstantiation.NamedArguments.Add([| ChildMessage: $childInstantiation |])
            return myInstantiation

        case MemberReferenceExpression(Target: target, Name: name):
            return ParentExpression([| $(root)() |], childInstantiation)

        case ReferenceExpression(Name: name):
            return ParentExpression([| $(root)() |], childInstantiation)

        otherwise:
            pass

def MessageExpression(root as Expression) as MethodInvocationExpression:
    match root:
        case MethodInvocationExpression(Target: MemberReferenceExpression(Target: target, Name: name), Arguments: arguments):
            myInstantiation = MethodInvocationExpression(ReferenceExpression("Pantheon.Message"),
                *((of Expression: StringLiteralExpression(name)) + arguments.ToArray()))
            return ParentExpression(target, myInstantiation)

        case MethodInvocationExpression(Target: ReferenceExpression(Name: name), Arguments: arguments):
            return MethodInvocationExpression(ReferenceExpression("Pantheon.Message"),
                *((of Expression: StringLiteralExpression(name)) + arguments.ToArray()))

        case MemberReferenceExpression(Target: target, Name: name):
            return MessageExpression([| $(root)() |])

        case ReferenceExpression(Name: name):
            return MessageExpression([| $(root)() |])

        otherwise:
            pass