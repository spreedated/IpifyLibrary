using System;

namespace neXn.IpifyWrapper.Attributes
{
    internal class QueryNameAttribute : Attribute
    {
        public string Name { get; private set; }
        public QueryNameAttribute(string name) : base()
        {
            this.Name = name;
        }
    }
}
