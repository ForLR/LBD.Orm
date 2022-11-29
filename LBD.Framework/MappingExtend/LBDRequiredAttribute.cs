namespace LBD.Framework.MappingExtend
{
    /// <summary>
    /// 
    /// </summary>
    public class LBDRequiredAttribute : LBDAbstractValidateAttribute
    {
        public LBDRequiredAttribute()
        {

        }

        public override bool Validate(object obj)
        {
            return !(obj is null) && obj.ToString().Length > 0;
        }
    }
}
