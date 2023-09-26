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
        /// 自增步长
        /// </summary>
        public int StepIndex { get; set; }
        /// <summary>
        /// 主键名 是否自增列
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="isAutoIncrement"></param>
        public LBDKeyAttribute(string keyName, bool isAutoIncrement, int stepIndex = 1) : base(keyName)
        {
            this.IsAutoIncrement = isAutoIncrement;
            this.StepIndex = stepIndex;
        }

    }
}
