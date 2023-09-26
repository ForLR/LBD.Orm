using System.Collections;

namespace LBD.CodeFirst
{
    /// <summary>
    /// 
    /// </summary>
    public class MappingDescription
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 列说明
        /// </summary>
        public List<MappingColunmDescription> MappingColunms { get; set; }

        /// <summary>
        /// 索引说明
        /// </summary>
        public List<MappingIndexColunmDescription> IndexColunmDescriptions { get; set; }

    }



    /// <summary>
    /// 
    /// </summary>
    public class MappingColunmDescription
    {

        /// <summary>
        /// 列名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public object? DefaultValue { get; set; }

        /// <summary>
        /// 是否为空
        /// </summary>
        public bool AllowIsNull { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; }
    }

    /// <summary>
    /// 索引说明
    /// </summary>
    public class MappingIndexColunmDescription
    {
        /// <summary>
        /// 索引名字
        /// </summary>
        public string IndexName { get; set; }

        /// <summary>
        /// 是否唯一索引
        /// </summary>
        public bool IsUnique { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> IndexFields { get; set; }
    }


}
