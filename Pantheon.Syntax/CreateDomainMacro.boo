macro create_domain:
    case [| create_domain $(ReferenceExpression(Name: left)) = $(ReferenceExpression(Name: right)) |]:
        statement = [| $(left) = $(ReferenceExpression("${right}Domain"))() |]
        yield statement

    otherwise:
        print "onoz"