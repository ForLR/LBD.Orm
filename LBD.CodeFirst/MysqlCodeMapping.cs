namespace LBD.CodeFirst
{
    public class MysqlCodeMapping : ICodeMapping
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string MappingToSql<T>() where T : class
        {
            throw new NotImplementedException();
        }
    }
}
