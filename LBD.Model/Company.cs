using LBD.Framework.MappingExtend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LBD.Model
{
    [LBDTable("Companys")]
    [LBDIndex("test", "Name", "CreateDate")]
    public class Company : LbdBaseModel
    {
        [LBDLength(100, 5)]
        [LBDRequired]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [LBDProperty("CreateDateTime")]
        public DateTime CreateDate { get; set; }
    }
}
