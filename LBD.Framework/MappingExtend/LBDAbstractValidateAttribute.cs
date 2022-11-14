using System;

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
