import Pantheon.StringExtensions

macro screen(name as ReferenceExpression):
    klassName = "screen_${name}"
    klass = [|
        class $(klassName) (Pantheon.Screen):
            def constructor():
                pass
    |]
    for elementAdder in screen.Get("elements"):
        klass.GetConstructor(0).Body.Add(elementAdder as Expression)
    for elementAdder in ElementAddersFromStatements(screen.Body.Statements):
        klass.GetConstructor(0).Body.Add(elementAdder)
    yield klass

    macro world(name as string):
        pass

def ElementAddersFromStatements(statements as Statement*):
    for statement in statements:
        match statement:
            case [|$(ExpressionStatement(Expression: expression))|]:
                match expression:
                    case [|$(MethodInvocationExpression(Target: target, Arguments: arguments))|]:
                        yield [| Elements.Add($(MethodInvocationExpression(ReferenceExpression("${target.ToString().PascalCase()}ScreenElement"), *arguments.ToArray()))) |]

def ElementAdderFromNameAndArgs(name as string, *args as (ReferenceExpression)):
    return [| Elements.Add($(MethodInvocationExpression(ReferenceExpression("${name}ScreenElement}"), *args))) |]