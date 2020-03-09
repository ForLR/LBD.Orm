using LBD.DAL.Interfaces;
using LBD.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LBD.DAL
{
    public  class LBDClient : ILBDClient
    {
        public LBDClient(ConnectionConfig connectionConfig)
        {
            this._connectionConfig = connectionConfig;
            this._provider = new LBDProvider(_connectionConfig);
        }

        public ConnectionConfig _connectionConfig { get; set; }
        public LBDProvider _provider { get; set; }

        public int BulkInsert<T>(IEnumerable<T> t) where T : LbdBaseModel, new()
        {
           return this._provider.db.BulkInsert(t);

        }


        #region Operation
        public void Delete<T>(T t) where T : LbdBaseModel, new()
        {
            this._provider.db.Delete(t);
        }
        public  T Find<T>(int id) where T : LbdBaseModel, new()
        {
            return this._provider.db.Find<T>(id);
        }

        public T Find<T>(Expression<Func<T, bool>> expression) where T : LbdBaseModel, new()
        {
            return this._provider.db.Find<T>(expression);
        }

        public IEnumerable<T> FindList<T>(Expression<Func<T, bool>> expression) where T : LbdBaseModel, new()
        {
            return this._provider.db.FindList<T>(expression);
        }

        public  void Insert<T>(T t) where T : LbdBaseModel, new()
        {
            this._provider.db.Insert<T>(t);
        }
        public  void SavaChange()
        {
            this._provider.db.SavaChange();

        }

        public  void Update<T>(T t) where T : LbdBaseModel, new()
        {
            this._provider.db.Update(t);
        }
        #endregion

    }
}
