using LBD.DAL.Interfaces;
using LBD.Framework.ExppressionExtends;
using LBD.Framework.Extends;
using LBD.Framework.SQLCache;
using LBD.Framework.Validates;
using LBD.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using DbType = LBD.DAL.Interfaces.DbType;

namespace LBD.DAL.Mysql
{
    /// <summary>
    /// mysql
    /// </summary>
    class MysqlHelperDelay : ILbdDb
    {
        internal MysqlHelperDelay(string connection)
        {
            _connStr = connection;
            MySqlAdo.SetConnStr(_connStr);
        }

        /// <summary>
        /// 
        /// </summary>
        private static string _connStr { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private static IList<MySqlCommand> _Commands = new List<MySqlCommand>();

        /// <summary>
        /// 
        /// </summary>
        public DbType DbType { get { return DbType.MYSQL; } }


        public T Find<T>(int id) where T : LbdBaseModel, new()
        {

            var sql = MysqlCache<T>.GetSelect();
            var result = MySqlAdo.DataReaderToGenerics<T>(sql, new MySqlParameter("@Id", id));
            return result;
        }
        public T Find<T>(Expression<Func<T, bool>> expression) where T : LbdBaseModel, new()
        {

            var sql = ExpressionToSql.Find(expression);
            var result = MySqlAdo.DataReaderToGenerics<T>(sql, null);
            return result;
        }
        public void Insert<T>(T t) where T : LbdBaseModel, new()
        {
            t.Validate();
            var sql = MysqlCache<T>.GetInsert(t, out MySqlParameter[] parameters);
            MySqlCommand command = new MySqlCommand(sql);
            command.Parameters.AddRange(parameters);
            _Commands.Add(command);
        }

        public void Update<T>(T t) where T : LbdBaseModel, new()
        {
            var sql = MysqlCache<T>.GetUpdate(t, out MySqlParameter[] paras);

            MySqlCommand command = new MySqlCommand(sql);
            command.Parameters.AddRange(paras);
            _Commands.Add(command);

        }

        public void Delete<T>(T t) where T : LbdBaseModel, new()
        {
            var sql = MysqlCache<T>.GetDelete(t, out MySqlParameter parameter);
            MySqlCommand command = new MySqlCommand(sql);
            command.Parameters.Add(parameter);
            _Commands.Add(command);

        }


        /// <summary>
        /// 延迟提交 统一事务
        /// </summary>
        public void SavaChange()
        {

            if (_Commands.Any())
            {
                using (MySqlConnection connection = new MySqlConnection(_connStr))
                {
                    connection.Open();
                    using MySqlTransaction trans = connection.BeginTransaction();
                    try
                    {
                        foreach (MySqlCommand command in _Commands)
                        {
                            command.Connection = connection;
                            command.Transaction = trans;
                            command.ExecuteNonQuery();

                        }
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
                    }
                    finally
                    {
                        _Commands?.Clear();
                    }

                }

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(Expression<Func<T, bool>> expression) where T : LbdBaseModel, new()
        {
            var sql = ExpressionToSql.Find(expression);
            var result = MySqlAdo.DataReaderToGenericsList<T>(sql, null);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public int BulkInsert<T>(IEnumerable<T> t) where T : LbdBaseModel, new()
        {
            string tablename = MysqlCache<T>._TableName;
            var table = t.ConvertToDataTable(tablename);
            table.ToCsv();
            var columns = table.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToList();
            using (MySqlConnection conn = new MySqlConnection(_connStr))
            {
                MySqlBulkLoader mySqlBulk = new MySqlBulkLoader(conn)
                {
                    FieldTerminator = ",",
                    FieldQuotationCharacter = '"',
                    EscapeCharacter = '"',
                    LineTerminator = "\r\n",
                    FileName = table.TableName + ".csv",
                    NumberOfLinesToSkip = 0,
                    TableName = table.TableName,
                };
                mySqlBulk.Columns.AddRange(columns);
                return mySqlBulk.Load();
            }
        }

        /// <summary>
        /// 多条insert（临时版本）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ts"></param>
        public void InsertList<T>(IEnumerable<T> ts) where T : LbdBaseModel, new()
        {
            foreach (var item in ts)
            {
                item.Validate();
                var sql = MysqlCache<T>.GetInsert(item, out MySqlParameter[] parameters);
                MySqlCommand command = new MySqlCommand(sql);
                command.Parameters.AddRange(parameters);
                _Commands.Add(command);
            }


        }
    }
}
