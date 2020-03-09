using LBD.DAL.Interfaces;
using LBD.DAL.Mysql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DbType = LBD.DAL.Interfaces.DbType;

namespace LBD.DAL
{
    /// <summary>
    /// 初始化信息
    /// </summary>
    public class ConnectionConfig
    {
        public ConnectionConfig(string conn, DbType dbType= DbType.MYSQL)
        {
            this.Connection = conn;
            this.DbType = dbType;
        }
        
        public DbType DbType { get; set; }

        public string Connection { get; set; }
    }
}
