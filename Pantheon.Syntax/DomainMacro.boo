class DomainMessage:
    property MessageDefinition as string
    property MessageHandler as Method

macro domain:
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
                    def $(messageName)(message as Pantheon.Message):
                        $(message.Body)
                |]
                domainMessage = DomainMessage(MessageDefinition: messageName, MessageHandler: method)
                domain.Add("messages", domainMessage)

        macro send:
            case [| send $(ReferenceExpression(Name: name)) |]:
                statement = [| self.Send($(StringLiteralExpression(name))) |]
                yield statement