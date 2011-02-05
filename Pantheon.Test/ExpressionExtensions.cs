using System;
using System.Linq.Expressions;

namespace Pantheon.Test
{
    public static class ExpressionExtensions
    {
        public static bool EqualsExpression(this Expression e1, Expression e2)
        {
            if (!(e1.NodeType == e2.NodeType && e1.Type == e2.Type))
            {
                return false;
            }
            switch (e1.NodeType)
            {
                case ExpressionType.Constant:
                    return (e1 as ConstantExpression).EqualsExpression(e2 as ConstantExpression);

                case ExpressionType.Add:
                case ExpressionType.Multiply:
                    return (e1 as BinaryExpression).EqualsExpression(e2 as BinaryExpression);

                case ExpressionType.Convert:
                    return (e1 as UnaryExpression).EqualsExpression(e2 as UnaryExpression);
            }
            return false;
        }

        public static bool EqualsExpression(this ConstantExpression e1, ConstantExpression e2)
        {
            return e1.Value.Equals(e2.Value);
        }

        public static bool EqualsExpression(this BinaryExpression e1, BinaryExpression e2)
        {
            return e1.Method == e2.Method && e1.Left.EqualsExpression(e2.Left) && e1.Right.EqualsExpression(e2.Right);
        }

        public static bool EqualsExpression(this UnaryExpression e1, UnaryExpression e2)
        {
            return e1.Method == e2.Method && e1.Operand.EqualsExpression(e2.Operand);
        }

        public static string ToLongString(this Expression expr)
        {
            return string.Format("{0} ({1} -> {2})", expr, expr.NodeType, expr.Type);
        }
    }
}

