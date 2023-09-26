using System;
using System.Collections.Generic;
using System.Linq;

namespace LBD.Framework.MappingExtend
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class LBDIndexAttribute : Attribute
    {
        public string IndexName { get; set; }

        /// <summary>
        /// 是否唯一索引
        /// </summary>
        public bool IsUnique { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> IndexFields { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="indexName"></param>
        /// <param name="isUnique"></param>
        /// <param name="indexField"></param>
        public LBDIndexAttribute(string indexName, bool isUnique, params string[] indexField)
        {

            IndexName = indexName;
            IsUnique = isUnique;
            IndexFields = indexField.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="indexName"></param>
        /// <param name="indexField"></param>
        public LBDIndexAttribute(string indexName, params string[] indexField)
        {
            IndexName = indexName;
            IsUnique = false;
            IndexFields = indexField.ToList();
        }

    }
}

