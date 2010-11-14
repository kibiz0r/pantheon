def MessageDefinitionExpressionFromName(name as string):
    return [|
        public class $("${name}Message")(Pantheon.Message):
            public def constructor():
                super($name)
    
        public class $("${name}Message")[of ChildMessageType(Pantheon.Message)]($("${name}Message")):
            public def constructor():
                super()
    
            public property ChildMessage as ChildMessageType
    |]

def MessageDefinitionExpression(root as Expression) as Module:
    match root:
        case MemberReferenceExpression(Target: target, Name: name):
            parentModule = MessageDefinitionExpression(target)
            classes = MessageDefinitionExpressionFromName(name)
            parentModule.Members.Extend(classes.Members)
            return parentModule

        case ReferenceExpression(Name: name):
            return MessageDefinitionExpressionFromName(name)