def NameFromSignature(signature as MethodInvocationExpression):
    match signature.Target:
        case ReferenceExpression(Name: name):
            return name

def ParametersFromSignature(signature as MethodInvocationExpression):
    for arg in signature.Arguments:
        match arg:
            case [| $(ReferenceExpression(Name: name)) as $type |]:
                yield ParameterDeclaration(Name: name, Type: type)

def ArgumentsFromSignature(signature as MethodInvocationExpression):
    return signature.Arguments