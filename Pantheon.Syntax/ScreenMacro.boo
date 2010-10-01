import Pantheon.StringExtensions

macro screen(name as ReferenceExpression):
    klassName = "screen_${name}"
    klass = [|
        class $(klassName) (Pantheon.Screen):
            def constructor():
                pass
    |]
    for statement in screen.Body.Statements:
        match statement:
            case [|$(ExpressionStatement(Expression: expression))|]:
                match expression:
                    case [|$(MethodInvocationExpression(Target: target, Arguments: arguments))|]:
                        addStatement = [| Elements.Add($(MethodInvocationExpression(ReferenceExpression("screen_element_${target.ToString().PascalCase()}"), *arguments.ToArray()))) |]
                        klass.GetConstructor(0).Body.Add(addStatement)
    yield klass

    macro world(name as ReferenceExpression):
        screen.Add("elements", ElementAdderFromNameAndArgs("World", name))

def ElementAdderFromNameAndArgs(name as string, *args as (ReferenceExpression)):
    return [| Elements.Add($(MethodInvocationExpression(ReferenceExpression("screen_element_${name}"), *args))) |]