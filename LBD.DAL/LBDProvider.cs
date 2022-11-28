using LBD.DAL.Interfaces;
using LBD.DAL.Mysql;
using System;

namespace LBD.DAL
{
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

        private ConnectionConfig _connection { get; set; }


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
