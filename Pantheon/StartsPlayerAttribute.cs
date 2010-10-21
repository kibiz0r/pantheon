using System;

namespace Pantheon
{
    [AttributeUsage(AttributeTargets.Class)]
    public class StartsPlayerAttribute : Attribute
    {
        public Type PlayerType
        {
            get;
            set;
        }

        public StartsPlayerAttribute(Type playerType)
        {
            PlayerType = playerType;
        }
    }
}

