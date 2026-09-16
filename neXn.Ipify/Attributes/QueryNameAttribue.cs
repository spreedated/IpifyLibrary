using System;

namespace neXn.Ipify.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class QueryNameAttribute : Attribute
    {
#if NET8_0_OR_GREATER
        public string Name { get; init; }
#else
        public string Name { get; }
#endif
        public QueryNameAttribute(string name) : base()
        {
            this.Name = name;
        }
    }
}
