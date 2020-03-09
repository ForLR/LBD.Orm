using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Framework.MappingExtend
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LBDKeyAttribute: LBDAbstractNameAttribute
    {
        public  bool IsAutoIncrement { get; }

        /// <summary>
        /// 主键名 是否自增列
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="isAutoIncrement"></param>
        public LBDKeyAttribute(string keyName,bool isAutoIncrement) :base(keyName)
        {
            this.IsAutoIncrement = isAutoIncrement;

        }
        
    }
}
