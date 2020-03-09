using LBD.Framework.MappingExtend;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LBD.DAL.Mysql
{
    public  class MySqlAdo
    {



        public static T DataReaderToGenerics<T>(string connStr, string sql, MySqlParameter mySqlParameter) where T:new()
        {
            T result = new T();
            using (MySqlConnection connection = new MySqlConnection(connStr))
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

        public static IEnumerable<T>  DataReaderToGenericsList<T>(string connStr, string sql, MySqlParameter mySqlParameter) where T : new()
        {
            List<T> result = new List<T>();
            using (MySqlConnection connection = new MySqlConnection(connStr))
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
