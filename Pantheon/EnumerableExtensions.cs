using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Pantheon
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<Type> Types<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Select(e => e.GetType());
        }
    }
}

