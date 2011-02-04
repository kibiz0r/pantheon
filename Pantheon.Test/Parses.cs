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
        public class ParsesToConstraint<T> : Constraint
        {
            public ParsesToConstraint(T expected)
            {
                this.expected = expected;
            }

            protected T expected;
            protected string source;

            public override bool Matches(object _source)
            {
                this.source = (string)_source;
                actual = Pantheon.Evaluate(source);
                return expected.Equals(actual);
            }

            public override void WriteDescriptionTo(MessageWriter writer)
            {
                writer.WritePredicate(string.Format("{0} parses to {1}", source, expected));
            }

            public virtual ParsesToWithRuleConstraint<T> WithRule(PantheonRule rule)
            {
                return new ParsesToWithRuleConstraint<T>(expected, rule);
            }
        }

        public class ParsesToWithRuleConstraint<T> : Constraint
        {
            public ParsesToWithRuleConstraint(T expected, PantheonRule rule)
            {
                this.expected = expected;
                this.rule = rule;
            }

            protected T expected;
            protected string source;
            protected PantheonRule rule;
            protected Exception exception;

            public override bool Matches(object _source)
            {
                this.source = (string)_source;
                try
                {
                    actual = Pantheon.Evaluate(source, rule);
                    return expected.Equals(actual);
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

        public static ParsesToConstraint<T> To<T>(T expected)
        {
            return new ParsesToConstraint<T>(expected);
        }

        public static ParsesThrowingConstraint<T> Throwing<T>() where T : Exception
        {
            return new ParsesThrowingConstraint<T>();
        }
    }
}

