using LBD.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LBD.DAL.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILbdDb
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T Find<T>(int id) where T : LbdBaseModel, new();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T FindAsync<T>(int id) where T : LbdBaseModel, new();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        T Find<T>(Expression<Func<T, bool>> expression) where T : LbdBaseModel, new();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        IEnumerable<T> FindList<T>(Expression<Func<T, bool>> expression) where T : LbdBaseModel, new();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        void Delete<T>(T t) where T : LbdBaseModel, new();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        void Insert<T>(T t) where T : LbdBaseModel, new();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        void Update<T>(T t) where T : LbdBaseModel, new();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        int BulkInsert<T>(IEnumerable<T> t) where T : LbdBaseModel, new();

        /// <summary>
        /// 
        /// </summary>
        void SavaChange();
    }

}
