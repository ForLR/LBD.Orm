using LBD.Framework.MappingExtend;

namespace LBD.Model
{
    public class LbdBaseModel
    {
        [LBDKey("Id", true)]
        public int Id { get; set; }
    }
}
