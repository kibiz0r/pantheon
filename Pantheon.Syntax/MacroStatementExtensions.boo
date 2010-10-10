import Boo.Lang.Compiler.Ast

[extension]
static def Add(macroStatement as MacroStatement, name as string, value as object):
    macroStatement.Get(name).Add(value)

[extension]
static def Get(macroStatement as MacroStatement, name as string):
    macroStatement[name] = macroStatement[name] or []
    return macroStatement[name] as List[of object]