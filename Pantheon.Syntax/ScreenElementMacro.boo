macro screen_element:
    case [| screen_element $(ReferenceExpression(Name: name)) |]:
        klassName = "screen_element_${name}"
        klass = [|
            class $(klassName) (Pantheon.ScreenElement):
                pass
        |]
        method = [|
            def myMethod():
                pass
        |]
        print(method.GetType())
        for statement as DeclarationStatement in screen_element.Body.Statements:
            print(statement.Declaration)
            print(statement.Initializer)
            if statement.Initializer:
                print "Making method"
                print(statement.Declaration.Name)
                print(statement.Declaration.Type)
                print(statement.Initializer)
                if statement.Initializer:
                    print(statement.Initializer.GetType())
                    m = [|
                        def $(statement.Declaration.Name)() as $(statement.Declaration.Type or TypeReference.Lift(void)):
                            $((statement.Initializer as BlockExpression).Body)
                    |]
                    m.Parameters = (statement.Initializer as BlockExpression).Parameters
                    #print("method: ${m.GetType()}")
                    klass.Members.Add(m)
                else:
                    m = [|
                        def $(statement.Declaration.Name)() as $(statement.Declaration.Type or TypeReference.Lift(void)):
                            pass
                    |]
                    #print("method: ${m.GetType()}")
                    klass.Members.Add(m)
            else:
                print "Making field"
                print(statement.Declaration.Name)
                print(statement.Declaration.Type)
                f = [|
                    $(statement.Declaration.Name) as $(statement.Declaration.Type)
                |]
                print("field: ${f.GetType()}")
                klass.Members.Add(f)
            #print(statement.Declaration)
        yield klass