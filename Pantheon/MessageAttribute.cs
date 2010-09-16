using System;
namespace Pantheon
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class MessageAttribute : Attribute
    {
        public string Name { get; set; }
    }
}

