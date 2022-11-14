using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LBD.Framework.MappingExtend
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public abstract class LBDAbstractNameAttribute : Attribute
    {
        private string _name { get; set; }
        public LBDAbstractNameAttribute(string name)
        {
            this._name = name;
        }

        public string GetName()
        {
            return this._name;
        }
    }
}
