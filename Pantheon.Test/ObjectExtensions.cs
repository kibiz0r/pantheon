using System;
using System.Linq.Expressions;

namespace Pantheon.Test
{
    public static class ObjectExtensions
    {
        public static Expression AsExpression(this object obj)
        {
            if (obj is Expression)
            {
                return (Expression)obj;
            }
            return Expression.Constant(obj);
        }

        public static ConstantExpression Constant(this object obj)
        {
            return Expression.Constant(obj);
        }

        public static BinaryExpression Add(this object left, object right)
        {
            return Expression.Add(left.AsExpression(), right.AsExpression());
        }

        public static UnaryExpression Convert<T>(this object obj)
        {
            return Expression.Convert(obj.AsExpression(), typeof(T));
        }

        public static BinaryExpression Multiply(this object left, object right)
        {
            return Expression.Multiply(left.AsExpression(), right.AsExpression());
        }
    }
}

