using DbType = LBD.DAL.Interfaces.DbType;

namespace LBD.DAL
{
    /// <summary>
    /// 初始化信息
    /// </summary>
    public class ConnectionConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn">连接字符串</param>
        /// <param name="dbType">数据库类型</param>
        public ConnectionConfig(string conn, DbType dbType = DbType.MYSQL)
        {
            this.Connection = conn;
            this.DbType = dbType;
        }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public DbType DbType { get; set; }

        /// <summary>
        /// 连接字符串
        /// </summary>
        public string Connection { get; set; }
    }
}
