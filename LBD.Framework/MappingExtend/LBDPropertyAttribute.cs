using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Framework.MappingExtend
{
    [AttributeUsage( AttributeTargets.Property)]
    public class LBDPropertyAttribute:LBDAbstractNameAttribute
    {
        public LBDPropertyAttribute(string propertyName):base(propertyName)
        {

        }
    }
}
