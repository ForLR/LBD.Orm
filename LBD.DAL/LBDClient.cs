using LBD.DAL.Interfaces;
using LBD.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LBD.DAL
{
    /// <summary>
    /// 连接客户端
    /// </summary>
    public class LBDClient : ILBDClient, IDisposable
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        /// <param name="connectionConfig"></param>
        public LBDClient(ConnectionConfig connectionConfig)
        {
            this._connectionConfig = connectionConfig;
            this._provider = new LBDProvider(_connectionConfig);
        }

        /// <summary>
        /// 
        /// </summary>
        private ConnectionConfig _connectionConfig { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private LBDProvider _provider { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public int BulkInsert<T>(IEnumerable<T> t) where T : LbdBaseModel, new()
        {
            return this._provider.Db.BulkInsert(t);

        }


        #region Operation
        public void Delete<T>(T t) where T : LbdBaseModel, new()
        {
            this._provider.Db.Delete(t);
        }

        public void Dispose()
        {
            GC.Collect();
        }

        public T Find<T>(int id) where T : LbdBaseModel, new()
        {
            return this._provider.Db.Find<T>(id);
        }

        public T Find<T>(Expression<Func<T, bool>> expression) where T : LbdBaseModel, new()
        {
            return this._provider.Db.Find<T>(expression);
        }

        public IEnumerable<T> FindList<T>(Expression<Func<T, bool>> expression) where T : LbdBaseModel, new()
        {
            return this._provider.Db.FindList<T>(expression);
        }

        public void Insert<T>(T t) where T : LbdBaseModel, new()
        {
            this._provider.Db.Insert<T>(t);
        }
        public void SavaChange()
        {
            this._provider.Db.SavaChange();

        }

        public void Update<T>(T t) where T : LbdBaseModel, new()
        {
            this._provider.Db.Update(t);
        }
        #endregion

    }
}
