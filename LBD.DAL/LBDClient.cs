using LBD.DAL.Interfaces;
using LBD.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LBD.DAL
{
    /// <summary>
    /// client
    /// </summary>
    public class LBDClient : ILBDClient, IDisposable
    {
        /// <summary>
        /// 
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
        public ConnectionConfig _connectionConfig { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private LBDProvider _provider { get; set; }


        /// <summary>
        /// 批量新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public int BulkInsert<T>(IEnumerable<T> t) where T : LbdBaseModel, new()
        {
            return this._provider.db.BulkInsert(t);

        }


        #region Operation

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void Delete<T>(T t) where T : LbdBaseModel, new()
        {
            this._provider.db.Delete(t);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            GC.Collect();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Find<T>(int id) where T : LbdBaseModel, new()
        {
            return this._provider.db.Find<T>(id);
        }

        public T Find<T>(Expression<Func<T, bool>> expression) where T : LbdBaseModel, new()
        {
            return this._provider.db.Find<T>(expression);
        }

        public async Task<T> FindAsync<T>(int id) where T : LbdBaseModel, new()
        {
            return await this._provider.db.FindAsync<T>(id);
        }

        public IEnumerable<T> FindList<T>(Expression<Func<T, bool>> expression) where T : LbdBaseModel, new()
        {
            return this._provider.db.FindList<T>(expression);
        }

        public void Insert<T>(T t) where T : LbdBaseModel, new()
        {
            this._provider.db.Insert<T>(t);
        }
        public void SavaChange()
        {
            this._provider.db.SavaChange();

        }

        public void Update<T>(T t) where T : LbdBaseModel, new()
        {
            this._provider.db.Update(t);
        }
        #endregion

    }
}
