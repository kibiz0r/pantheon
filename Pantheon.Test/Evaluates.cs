using System;
using NUnit.Framework.Constraints;
using PantheonRule = System.Func<Pantheon.Pantheon, System.Action<int, System.Collections.Generic.IEnumerable<Pantheon._Pantheon_Item>>>;
using System.Text.RegularExpressions;

namespace Pantheon.Test
{
    public class Evaluates
    {
        public class EvaluatesToConstraint<T> : Constraint
        {
            public EvaluatesToConstraint(T expected)
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
                writer.WritePredicate(string.Format("{0} evaluates to {1}", source, expected));
            }

            public virtual EvaluatesToWithRuleConstraint<T> WithRule(PantheonRule rule)
            {
                return new EvaluatesToWithRuleConstraint<T>(expected, rule);
            }
        }

        public class EvaluatesToWithRuleConstraint<T> : Constraint
        {
            public EvaluatesToWithRuleConstraint(T expected, PantheonRule rule)
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
                writer.WritePredicate(string.Format("{0} to evaluate to {1} ({2})", source, expected, expected.GetType()));
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

        public class EvaluatesThrowingConstraint<T> : Constraint where T : Exception
        {
            public EvaluatesThrowingConstraint()
            {
            }

            public EvaluatesThrowingConstraint(string message)
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
                writer.WritePredicate(string.Format("{0} fails to evaluate with {1}", source, typeof(T)));
            }
        }

        public static EvaluatesToConstraint<T> To<T>(T expected)
        {
            return new EvaluatesToConstraint<T>(expected);
        }

        public static EvaluatesThrowingConstraint<T> Throwing<T>() where T : Exception
        {
            return new EvaluatesThrowingConstraint<T>();
        }
    }
}

