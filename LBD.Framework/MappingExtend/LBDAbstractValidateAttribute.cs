using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Framework.MappingExtend
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class LBDAbstractValidateAttribute : Attribute
    {
        public abstract bool Validate(object obj);
    }
}
