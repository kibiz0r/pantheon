using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Pantheon
{
    public static class _Pantheon_ItemExtensions
    {
        public static string Text(this _Pantheon_Item item)
        {
            return item.Inputs.ToString();
        }

        public static Expression Expression(this _Pantheon_Item item)
        {
            return (Expression)item;
        }

        public static bool IsExpressionOf<T>(this _Pantheon_Item item)
        {
            return item.Expression().Type == typeof(T);
        }
    }
}

