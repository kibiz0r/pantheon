macro control_scheme(name as ReferenceExpression):
    klass = [|
        class $(name) (Pantheon.ControlScheme):
            pass
    |]
    if control_scheme["inputs"]:
        for input in control_scheme["inputs"]:
            klass.Members.Add(input)
    yield klass

    macro input:
        case [|input $(ReferenceExpression(Name: name))|]:
            methodName = "input_${name}"
            method = [|
                def $(methodName)():
                    $(input.Body)
            |]
            control_scheme["inputs"] = control_scheme["inputs"] or []
            (control_scheme["inputs"] as List[of object]).Add(method)

        macro action:
            pass