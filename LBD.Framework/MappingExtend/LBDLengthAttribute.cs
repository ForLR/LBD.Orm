namespace LBD.Framework.MappingExtend
{
    /// <summary>
    /// 
    /// </summary>
    public class LBDLengthAttribute : LBDAbstractValidateAttribute
    {
        public int MaxLength { get; private set; }

        public int MinLength { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxLength"></param>
        /// <param name="minLength"></param>
        public LBDLengthAttribute(int maxLength, int minLength)
        {
            this.MaxLength = maxLength;
            this.MinLength = minLength;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Validate(object obj)
        {
            return (obj != null && obj.ToString().Length > MinLength && obj.ToString().Length < MaxLength);

        }
    }
}
