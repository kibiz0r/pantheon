def MessageDefinitionExpression(root as Expression) as TypeDefinition:
    match root:
        case ReferenceExpression(Name: name):
            component = [|
                public class $("${name}Component") (Pantheon.MessageComponent):
                    pass
            |]
            mod = Module(Namespace: NamespaceDeclaration("Messages.${name}"))
            mod.Members.Add(component)
            return mod