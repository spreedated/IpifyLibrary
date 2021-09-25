using System;

namespace neXn.IpifyWrapper.Attributes
{
    internal class QueryNameAttribute : Attribute
    {
        public string name;
        public QueryNameAttribute(string name) : base()
        {
            this.name = name;
        }
    }
}
