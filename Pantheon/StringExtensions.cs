using System;
using System.Linq;

namespace Pantheon
{
    public static class StringExtensions
    {
        public static string PascalCase(this string str)
        {
            if (str == "_")
            {
                return str;
            }
            var strings = str.Split('_');
            for (var i = 0; i < strings.Length; i++)
            {
                var s = strings[i];
                if (s.Length > 1)
                {
                    strings[i] = Char.ToUpper(s[0]) + s.Substring(1);
                }
                else
                {
                    strings[i] = s.ToUpper();
                }
            }
            return String.Join("", strings);
        }
    }
}

