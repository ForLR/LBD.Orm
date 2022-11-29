using LBD.Framework.MappingExtend;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace LBD.DAL.Mysql
{
    public class MySqlAdo
    {
        /// <summary>
        /// 
        /// </summary>
        private static string _connStr = "";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connStr"></param>
        public static void SetConnStr(string connStr)
        {
            _connStr = connStr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="mySqlParameter"></param>
        /// <returns></returns>
        public static T DataReaderToGenerics<T>(string sql, MySqlParameter mySqlParameter) where T : new()
        {
            T result = new T();
            using (MySqlConnection connection = new MySqlConnection(_connStr))
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                connection.Open();
                if (mySqlParameter != null)
                {
                    command.Parameters.Add(mySqlParameter);
                }
                var read = command.ExecuteReader();
                if (read.Read() && !read.IsClosed)
                {
                    foreach (PropertyInfo property in typeof(T).GetProperties())
                    {
                        var propertyName = property.GetName();
                        property.SetValue(result, read[propertyName] is DBNull ? null : read[propertyName]);
                    }

                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="mySqlParameter"></param>
        /// <returns></returns>
        public static IEnumerable<T> DataReaderToGenericsList<T>(string sql, MySqlParameter mySqlParameter) where T : new()
        {
            List<T> result = new List<T>();
            using (MySqlConnection connection = new MySqlConnection(_connStr))
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                connection.Open();
                if (mySqlParameter != null)
                {
                    command.Parameters.Add(mySqlParameter);
                }
                var read = command.ExecuteReader();
                while (read.Read())
                {
                    T entity = new T();
                    foreach (PropertyInfo property in typeof(T).GetProperties())
                    {
                        var propertyName = property.GetName();
                        property.SetValue(entity, read[propertyName] is DBNull ? null : read[propertyName]);
                    }
                    result.Add(entity);
                }
            }
            return result;
        }
    }
}
