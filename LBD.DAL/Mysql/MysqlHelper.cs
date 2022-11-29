using LBD.DAL.Interfaces;
using LBD.Framework;
using LBD.Framework.MappingExtend;
using LBD.Framework.SQLCache;
using LBD.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace LBD.DAL.Mysql
{
    /// <summary>
    /// 
    /// </summary>
    public class MysqlHelper : ILbdDb
    {
        /// <summary>
        /// 
        /// </summary>
        public static string connStr = ConfigMange.GetConnStr();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Find<T>(int id) where T : LbdBaseModel, new()
        {
            Type type = typeof(T);
            var sql = MysqlCache<T>.GetSelect();

            var propertyInfos = type.GetProperties();
            using (MySqlConnection connection = new MySqlConnection(connStr))
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new MySqlParameter("@Id", id));
                var read = command.ExecuteReader();

                if (read.Read())
                {
                    T result = new T();
                    foreach (PropertyInfo property in propertyInfos)
                    {
                        var propertyName = property.GetName();
                        property.SetValue(result, read[propertyName] is DBNull ? null : read[propertyName]);
                    }
                    return result;
                }
            }
            return default;
        }

        public void Insert<T>(T t) where T : LbdBaseModel, new()
        {
            var sql = MysqlCache<T>.GetInsert(t, out MySqlParameter[] parameters);

            using (MySqlConnection connection = new MySqlConnection(connStr))
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {

                connection.Open();
                command.Parameters.AddRange(parameters);
                command.ExecuteNonQuery();
            }
        }

        public void Update<T>(T t) where T : LbdBaseModel, new()
        {
            var sql = MysqlCache<T>.GetUpdate(t, out MySqlParameter[] paras);

            using (MySqlConnection connection = new MySqlConnection(connStr))
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {

                connection.Open();
                command.Parameters.AddRange(paras);
                command.ExecuteNonQuery();
            }

        }

        public void Delete<T>(T t) where T : LbdBaseModel, new()
        {
            var sql = MysqlCache<T>.GetDelete(t, out MySqlParameter parameter);
            using (MySqlConnection connection = new MySqlConnection(connStr))
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {

                connection.Open();
                command.Parameters.Add(parameter);
                command.ExecuteNonQuery();
            }

        }

        public void SavaChange()
        {
        }

        public T Find<T>(Expression<Func<T, bool>> expression) where T : LbdBaseModel, new()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindList<T>(Expression<Func<T, bool>> expression) where T : LbdBaseModel, new()
        {
            throw new NotImplementedException();
        }

        public int BulkInsert<T>(IEnumerable<T> t) where T : LbdBaseModel, new()
        {
            throw new NotImplementedException();
        }

        public T FindAsync<T>(int id) where T : LbdBaseModel, new()
        {
            Type type = typeof(T);
            var sql = MysqlCache<T>.GetSelect();

            var propertyInfos = type.GetProperties();
            using (MySqlConnection connection = new MySqlConnection(connStr))
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new MySqlParameter("@Id", id));
                var read = command.ExecuteReader();

                if (read.Read())
                {
                    T result = new T();
                    foreach (PropertyInfo property in propertyInfos)
                    {
                        var propertyName = property.GetName();
                        property.SetValue(result, read[propertyName] is DBNull ? null : read[propertyName]);
                    }
                    return result;
                }
            }
            return default;
        }
    }
}
