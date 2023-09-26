namespace LBD.CodeFirst
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICodeMapping
    {
        /// <summary>
        /// 映射成sql语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        string MappingToSql<T>() where T : class;

    }
}
