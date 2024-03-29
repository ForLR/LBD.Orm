﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Framework.MappingExtend
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class LBDTableAttribute : LBDAbstractNameAttribute
    {
        public LBDTableAttribute(string tableName) : base(tableName)
        {

        }
    }
}
