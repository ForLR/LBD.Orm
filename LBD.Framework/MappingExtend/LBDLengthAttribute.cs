using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Framework.MappingExtend
{
    public class LBDLengthAttribute: LBDAbstractValidateAttribute
    {
        public int MaxLength { get; private set; }

        public int MinLength { get;private set; }

        public LBDLengthAttribute(int maxLength,int minLength)
        {
            this.MaxLength = maxLength;
            this.MinLength = minLength;
        }

        public override bool Validate(object obj)
        {
            return (obj != null && obj.ToString().Length > MinLength && obj.ToString().Length < MaxLength);
           
        }
    }
}
