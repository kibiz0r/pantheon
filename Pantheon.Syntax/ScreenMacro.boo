import Pantheon.StringExtensions

macro screen(name as ReferenceExpression):
    klassName = MakeScreenType(name.Name)
    klass = [|
        class $(klassName) (Pantheon.Screen):
            def constructor():
                pass
    |]
    for widgetAdder in screen.Get("widgets"):
        klass.GetConstructor(0).Body.Add(widgetAdder as Expression)
    for widgetAdder in WidgetAddersFromStatements(screen.Body.Statements):
        klass.GetConstructor(0).Body.Add(widgetAdder)
    yield klass

    macro view_context(name as ReferenceExpression):
        for widgetAdder in WidgetAddersWithViewContextFromStatements(name.Name, view_context.Body.Statements):
            screen.Add("widgets", widgetAdder)

def WidgetAddersWithViewContextFromStatements(viewContext as string, statements as Statement*):
    for statement in statements:
        match statement:
            case [|$(ExpressionStatement(Expression: expression))|]:
                match expression:
                    case [|$(MethodInvocationExpression(Target: target, Arguments: arguments))|]:
                        yield [| Widgets.Add($(MethodInvocationExpression(ReferenceExpression(MakeWidgetType(target.ToString().PascalCase()))))) |]

def WidgetAddersFromStatements(statements as Statement*):
    for statement in statements:
        match statement:
            case [|$(ExpressionStatement(Expression: expression))|]:
                match expression:
                    case [|$(MethodInvocationExpression(Target: target, Arguments: arguments))|]:
                        yield [| Widgets.Add($(MethodInvocationExpression(ReferenceExpression(MakeWidgetType(target.ToString().PascalCase()))))) |]

def WidgetAdderFromNameAndArgs(name as string, *args as (ReferenceExpression)):
    return [| Widgets.Add($(MethodInvocationExpression(ReferenceExpression(MakeWidgetType(name)), *args))) |]