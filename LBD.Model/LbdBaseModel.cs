using LBD.Framework.MappingExtend;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Model
{
    public class LbdBaseModel
    {
        [LBDKey("Id", true)]
        public int Id { get; set; }
    }
}
