using System;

namespace LBD.Framework.MappingExtend
{
    /// <summary>
    /// 主键特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class LBDKeyAttribute : LBDAbstractNameAttribute
    {
        /// <summary>
        /// 是否自增列
        /// </summary>
        public bool IsAutoIncrement { get; }

        /// <summary>
        /// 主键名 是否自增列
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="isAutoIncrement"></param>
        public LBDKeyAttribute(string keyName, bool isAutoIncrement) : base(keyName)
        {
            this.IsAutoIncrement = isAutoIncrement;
        }

    }
}
