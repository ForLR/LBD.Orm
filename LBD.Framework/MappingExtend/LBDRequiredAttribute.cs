using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Framework.MappingExtend
{
    public class LBDRequiredAttribute:LBDAbstractValidateAttribute
    {
        public LBDRequiredAttribute()
        {

        }

        public override bool Validate(object obj)
        {
            return  !(obj is null) &&obj.ToString().Length>0;
        }
    }
}
