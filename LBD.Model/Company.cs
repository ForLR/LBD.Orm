using LBD.Framework.MappingExtend;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Model
{
    [LBDTable("Companys")]
    public class Company : LbdBaseModel
    {
        [LBDLength(100, 5)]
        [LBDRequired]
        public string Name { get; set; }

        [LBDProperty("CreateDateTime")]
        public DateTime CreateDate { get; set; }
    }
}
