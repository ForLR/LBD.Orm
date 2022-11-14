using System;

namespace LBD.Framework.MappingExtend
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class LBDKeyAttribute : LBDAbstractNameAttribute
    {
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
