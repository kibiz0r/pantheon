macro message(prototype as MethodInvocationExpression):
    method = [|
        def blah():
            pass
    |]
    yield method