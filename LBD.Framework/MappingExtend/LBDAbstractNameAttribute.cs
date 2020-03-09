using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LBD.Framework.MappingExtend
{
    [AttributeUsage( AttributeTargets.Property| AttributeTargets.Class)]
    public  abstract class LBDAbstractNameAttribute:Attribute
    {
        private string _Name { get; set; }
        public LBDAbstractNameAttribute(string name)
        {
            this._Name = name;
        }

        public string GetName()
        {
            return this._Name;
        }
    }
}
