def TypeMembersForClassFromBlock(klass as ClassDefinition, body as Block):
    for statement as DeclarationStatement in body.Statements:
        if statement.Initializer:
            if statement.Initializer:
                m = [|
                    def $(statement.Declaration.Name)() as $(statement.Declaration.Type or TypeReference.Lift(void)):
                        $((statement.Initializer as BlockExpression).Body)
                |]
                m.Parameters = (statement.Initializer as BlockExpression).Parameters
                yield m
            else:
                m = [|
                    def $(statement.Declaration.Name)() as $(statement.Declaration.Type or TypeReference.Lift(void)):
                        pass
                |]
                yield m
        else:
            f = [|
                $(statement.Declaration.Name) as $(statement.Declaration.Type)
            |]
            yield f