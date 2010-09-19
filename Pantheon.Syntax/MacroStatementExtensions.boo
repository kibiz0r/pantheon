import Boo.Lang.Compiler.Ast

[extension]
static def Add(macroStatement as MacroStatement, name as string, value as object):
    macroStatement[name] = macroStatement[name] or []
    (macroStatement[name] as List[of object]).Add(value)

[extension]
static def Get(macroStatement as MacroStatement, name as string):
    return macroStatement[name] as List[of object] or []