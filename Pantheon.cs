using System;
using System.Linq;
using System.Linq.Expressions;
using PantheonRule = System.Func<Pantheon.Pantheon, System.Action<int, System.Collections.Generic.IEnumerable<Pantheon._Pantheon_Item>>>;

namespace Pantheon
{
    public partial class Pantheon
    {
        public static object Evaluate(string source)
        {
            return Evaluate(source, null);
        }

        public static object Evaluate(string source, PantheonRule rule)
        {
            var result = Parse(source, rule);
            var lambda = Expression.Lambda(result).Compile();
            return lambda.DynamicInvoke();
        }

        public static Expression Parse(string source)
        {
            return Parse(source, null);
        }

        public static Expression Parse(string source, PantheonRule rule)
        {
            var pantheon = new Pantheon(source);
            if (rule == null)
            {
                rule = p => p.Expr;
            }
            var matchRule = rule(pantheon);
            var match = pantheon.GetMatch(matchRule);
            var got = match.Results;
            if (!match.Success)
            {
                var error = pantheon.GetLastError();
                var message = error.Message;
                var pos = error.Pos;
                var around = source.Substring(pos - 5, 10);
                throw new Exception(string.Format("{0} around {1}\ngot {2}", message, around, got));
            }
            if (match.NextIndex < source.Length)
            {
                throw new Exception(string.Format("Only parsed up to {0}\ngot {1}", source.Substring(0, match.NextIndex), string.Join(", ", got)));
            }
            return match.Result;
        }
    }
}

