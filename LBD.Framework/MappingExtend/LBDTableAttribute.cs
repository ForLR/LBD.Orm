using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Framework.MappingExtend
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class LBDTableAttribute : LBDAbstractNameAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        public LBDTableAttribute(string tableName) : base(tableName)
        {

        }
    }
}
