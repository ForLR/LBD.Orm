using System;

namespace LBD.Framework.MappingExtend
{
    /// <summary>
    /// 验证特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class LBDAbstractValidateAttribute : Attribute
    {
        /// <summary>
        /// 验证方法
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public abstract bool Validate(object obj);
    }
}
