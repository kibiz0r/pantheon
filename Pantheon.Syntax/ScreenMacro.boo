import Pantheon.StringExtensions
import System.Linq.Enumerable

macro screen(name as ReferenceExpression):
    klassName = MakeScreenType(name.Name)
    klass = [|
        class $(klassName) (Pantheon.Screen):
            def constructor():
                pass
    |]
    konstructor = klass.GetConstructor(0)
    for statement in screen.Body.Statements:
        match statement:
            case [| $(ExpressionStatement(Expression: expression)) |]:
                match expression:
                    case [| $(MethodInvocationExpression(Target: ReferenceExpression(Name: target), Arguments: arguments)) |]:
                        name = arguments[0]
                        type = MakeWidgetType(target.PascalCase())
                        field = [|
                            public $(name) as $(type)
                        |]
                        klass.Members.Add(field)
                        addWidget = [|
                            $(name) = $(ReferenceExpression(type))()
                            Widgets.Add($(name))
                        |]
                        konstructor.Body.Add(addWidget)
    for widgetField in screen.Get("widget_fields"):
        klass.Members.Add(widgetField)
    for widgetAdder as Block in screen.Get("widget_adders"):
        konstructor.Body.Add(widgetAdder)
    yield klass

    macro view_context(name as ReferenceExpression):
        for statement in view_context.Body.Statements:
            match statement:
                case [| $(ExpressionStatement(Expression: expression)) |]:
                    match expression:
                        case [| $(MethodInvocationExpression(Target: ReferenceExpression(Name: target), Arguments: arguments)) |]:
                            name = arguments[0]
                            print(arguments[1].GetType()) if arguments.Count > 1
                            type = MakeWidgetType(target.PascalCase())
                            field = [|
                                public $(name) as $(type)
                            |]
                            screen.Add("widget_fields", field)
                            addWidget = [|
                                $(name) = $(ReferenceExpression(type))()
                                Widgets.Add($(name))
                            |]
                            screen.Add("widget_adders", addWidget)

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

def WidgetPropertyLinksFromBlock(block as Block):
    return null