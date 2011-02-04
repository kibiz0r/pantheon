using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Pantheon.Interactive
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write(">>>");
                var input = Console.ReadLine();
                Console.WriteLine(Pantheon.Evaluate(input));
            }
        }
    }
}

