using System;
using System.Linq.Expressions;
using PantheonRule = System.Func<Pantheon.Pantheon, System.Action<int, System.Collections.Generic.IEnumerable<Pantheon._Pantheon_Item>>>;

namespace Pantheon
{
    public partial class Pantheon
    {
        public static object Evaluate(string source)
        {
            return Parse(source)();
        }

        public static object Evaluate(string source, PantheonRule rule)
        {
            return Parse(source, rule)();
        }

        public static Func<object> Parse(string source)
        {
            return Parse(source, p => p.Expr);
        }

        public static Func<object> Parse(string source, PantheonRule rule)
        {
            var pantheon = new Pantheon(source);
            var matchRule = rule(pantheon);
            var match = pantheon.GetMatch(matchRule);
            if (!match.Success)
            {
                throw new Exception(pantheon.GetLastError().Message);
            }
            if (match.NextIndex < source.Length)
            {
                throw new Exception(string.Format("Only parsed up to {0}", source.Substring(0, match.NextIndex)));
            }
            var result = match.Result;
            var lambda = Expression.Lambda(result).Compile();
            return () => lambda.DynamicInvoke();
        }
    }
}

