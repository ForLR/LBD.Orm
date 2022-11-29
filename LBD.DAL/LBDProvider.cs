using LBD.DAL.Interfaces;
using LBD.DAL.Mysql;
using System;

namespace LBD.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class LBDProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        public LBDProvider(ConnectionConfig connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// 
        /// </summary>
        private ConnectionConfig _connection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ILbdDb db
        {
            get
            {
                if (_connection.DbType == DbType.MYSQL)
                {
                    return new MysqlHelperDelay(_connection.Connection);
                }
                throw new NotSupportedException("暂不支持的数据库");
            }
        }
    }
}
