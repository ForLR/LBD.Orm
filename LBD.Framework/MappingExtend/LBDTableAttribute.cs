using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Framework.MappingExtend
{
    [AttributeUsage( AttributeTargets.Class)]
    public  class LBDTableAttribute: LBDAbstractNameAttribute
    {
        public LBDTableAttribute(string tableName):base(tableName)
        {

        }
    }
}
