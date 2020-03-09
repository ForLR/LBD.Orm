using LBD.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LBD.DAL.Interfaces
{
    public interface ILbdDb
    {

        T Find<T>(int id) where T : LbdBaseModel,new();

        T Find<T>(Expression<Func<T, bool>> expression) where T : LbdBaseModel, new();
        IEnumerable<T> FindList<T>(Expression<Func<T, bool>> expression) where T : LbdBaseModel, new();




        void Delete<T>(T t) where T : LbdBaseModel, new();

        void Insert<T>(T t) where T : LbdBaseModel,new();
        void Update<T>(T t) where T : LbdBaseModel, new();

        int BulkInsert<T>(IEnumerable<T> t) where T : LbdBaseModel, new();

        void SavaChange();
    }

}
