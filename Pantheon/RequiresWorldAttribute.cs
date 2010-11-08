using System;
namespace Pantheon
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RequiresWorldAttribute : Attribute
    {
        public Type WorldType
        {
            get;
            set;
        }

        public RequiresWorldAttribute(Type worldType)
        {
            WorldType = worldType;
        }
    }
}

