class DomainMessage:
    property MessageDefinition as string
    property MessageHandler as Method

def CountMethodInvocations(root as Expression) as int:
    match root:
        case MethodInvocationExpression(Target: target):
            return CountMethodInvocations(target) + 1

        case MemberReferenceExpression(Target: target, Name: name):
            return CountMethodInvocations(target)

        case ReferenceExpression(Name: name):
            return 0

def MakeName(root as Expression) as string:
    match root:
        case MethodInvocationExpression(Target: target):
            return "${MakeName(target)}{${CountMethodInvocations(target)}}"

        case MemberReferenceExpression(Target: target, Name: name):
            return "${MakeName(target)}.${name}"

        case ReferenceExpression(Name: name):
            return name

def MakeParameters(root as Expression) as List[of ParameterDeclaration]:
    match root:
        case MethodInvocationExpression(Target: target, Arguments: arguments):
            parameters = List[of ParameterDeclaration]()
            for argument in arguments:
                match argument:
                    case [| $(ReferenceExpression(Name: name)) as $type |]:
                        parameter = ParameterDeclaration(Name: name, Type: type)
                        parameters.Add(parameter)
            targetParameters = MakeParameters(target)
            return targetParameters.Extend(parameters)

        otherwise:
            return List[of ParameterDeclaration]()

macro domain:
    case [| domain $(MethodInvocationExpression(Target: ReferenceExpression(Name: name))) |]:
        domainName = MakeDomainType(name)
        yield [| Pantheon.Universe.Current.Domains.Add($(ReferenceExpression(domainName))()) |]

    case [| domain $(ReferenceExpression(Name: name)) |]:
        domainName = MakeDomainType(name)
        klass = [|
            class $(domainName) (Pantheon.Domain):
                $(domain.Body)
        |]
        for message as DomainMessage in domain.Get("messages"):
            #klass.Members.Add(message.MessageDefinition)
            klass.Members.Add(message.MessageHandler)
        yield klass

        macro message:
            case [| message $(ReferenceExpression(Name: name)) |]:
                messageName = MakeMessageType(name)
                method = [|
                    def $(messageName)():
                        $(message.Body)
                |]
                domainMessage = DomainMessage(MessageDefinition: messageName, MessageHandler: method)
                domain.Add("messages", domainMessage)

            case [| message $(signature = MethodInvocationExpression()) |]:
                methodName = MakeName(signature)
                #targetName = NameFromSignature(signature)
                #messageName = MakeMessageType(targetName)
                messageName = "${methodName}Message"
                method = [|
                    def $(messageName)():
                        $(message.Body)
                |]
                method.Parameters.Extend(MakeParameters(signature))
                domainMessage = DomainMessage(MessageDefinition: messageName, MessageHandler: method)
                domain.Add("messages", domainMessage)

            otherwise:
                for arg in message.Arguments:
                    print arg.GetType()