using System;
using NUnit.Framework.Constraints;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using PantheonRule = System.Func<Pantheon.Pantheon, System.Action<int, System.Collections.Generic.IEnumerable<Pantheon._Pantheon_Item>>>;

namespace Pantheon.Test
{
    public static class Parses
    {
        public class ParsesToConstraint : Constraint
        {
            public ParsesToConstraint(Expression expected)
            {
                this.expected = expected;
            }

            protected Expression expected;
            protected string source;

            protected Expression actualExpression
            {
                get { return (Expression)actual; }
            }

            public override bool Matches(object _source)
            {
                this.source = (string)_source;
                actual = Pantheon.Parse(source);
                return expected.EqualsExpression(actualExpression);
            }

            public override void WriteActualValueTo(MessageWriter writer)
            {
                writer.WriteActualValue(actualExpression.ToLongString());
            }

            public override void WriteDescriptionTo(MessageWriter writer)
            {
                writer.WritePredicate(string.Format("{0} parses to {1}", source, expected.ToLongString()));
            }

            public virtual ParsesToWithRuleConstraint WithRule(PantheonRule rule)
            {
                return new ParsesToWithRuleConstraint(expected, rule);
            }
        }

        public class ParsesToWithRuleConstraint : ParsesToConstraint
        {
            public ParsesToWithRuleConstraint(Expression expected, PantheonRule rule) : base(expected)
            {
                this.rule = rule;
            }

            protected PantheonRule rule;
            protected Exception exception;

            public override bool Matches(object _source)
            {
                this.source = (string)_source;
                try
                {
                    actual = Pantheon.Parse(source, rule);
                    return expected.EqualsExpression(actualExpression);
                }
                catch (Exception ex)
                {
                    exception = ex;
                    return false;
                }
            }

            public override void WriteDescriptionTo(MessageWriter writer)
            {
                writer.WritePredicate(string.Format("{0} to parse to {1} ({2})", source, expected, expected.GetType()));
            }

            public override void WriteActualValueTo(MessageWriter writer)
            {
                if (exception != null)
                {
                    writer.WriteActualValue(string.Format("{0}", exception.Message));
                }
                else
                {
                    writer.WriteActualValue(string.Format("{0} ({1})", actual, actual.GetType()));
                }
            }
        }

        public class ParsesThrowingConstraint<T> : Constraint where T : Exception
        {
            public ParsesThrowingConstraint(){}

            public ParsesThrowingConstraint(string message)
            {
                this.message = message;
            }

            protected string message;
            protected string source;

            public override bool Matches(object _source)
            {
                try
                {
                    this.source = (string)_source;
                    actual = Pantheon.Evaluate(source);
                }
                catch (T exception)
                {
                    if (message != null)
                    {
                        return Regex.Match(exception.Message, message) != null;
                    }
                    else
                    {
                        return true;
                    }
                }
                return false;
            }

            public override void WriteDescriptionTo(MessageWriter writer)
            {
                writer.WritePredicate(string.Format("{0} fails to parse with {1}", source, typeof(T)));
            }
        }

        public static ParsesToConstraint To(Expression expected)
        {
            return new ParsesToConstraint(expected);
        }

        /* Doesn't quite work because of C# compiler optimizations.
        public static ParsesToConstraint To<T>(Expression<Func<T>> expected)
        {
            return new ParsesToConstraint(expected.Body);
        }*/

        public static ParsesThrowingConstraint<T> Throwing<T>() where T : Exception
        {
            return new ParsesThrowingConstraint<T>();
        }
    }
}

