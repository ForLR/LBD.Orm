using LBD.DAL.Interfaces;
using LBD.Framework;
using LBD.Framework.ExppressionExtends;
using LBD.Framework.Extends;
using LBD.Framework.MappingExtend;
using LBD.Framework.SQLCache;
using LBD.Framework.Validates;
using LBD.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using DbType = LBD.DAL.Interfaces.DbType;

namespace LBD.DAL.Mysql
{
    class MysqlHelperDelay : ILbdDb
    {
        public MysqlHelperDelay(string connection)
        {
            connStr = connection;
        }
        //public static string connStr= ConfigMange.GetConnStr();
        public static string connStr { get; set; }

        private static IList<MySqlCommand> _Commands=new List<MySqlCommand>();

        public DbType DbType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public  T Find<T>(int id) where T: LbdBaseModel,new()
        {
            var sql = MysqlCache<T>.GetSelect();
            var result = MySqlAdo.DataReaderToGenerics<T>(connStr,sql, new MySqlParameter("@Id", id));
            return result;
        }
        public T Find<T>(Expression<Func<T,bool>> expression) where T : LbdBaseModel, new()
        {
            
            var sql = ExpressionToSql.Find(expression);
            var result = MySqlAdo.DataReaderToGenerics<T>(connStr, sql,null);
            return result;
        }
        public void Insert<T>(T t)where T: LbdBaseModel, new()
        {
            t.Validate();
            var sql = MysqlCache<T>.GetInsert(t,out MySqlParameter[] parameters);
            MySqlCommand command = new MySqlCommand(sql);
            command.Parameters.AddRange(parameters);
            _Commands.Add(command);
        }

        public void Update<T>(T t) where T : LbdBaseModel, new()
        {
            var sql = MysqlCache<T>.GetUpdate(t,out MySqlParameter[] paras);

            MySqlCommand command = new MySqlCommand(sql);
            command.Parameters.AddRange(paras);
            _Commands.Add(command);

        }

        public  void Delete<T>(T t) where T : LbdBaseModel, new()
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
                using (MySqlConnection connection = new MySqlConnection(connStr))
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

        public IEnumerable<T> FindList<T>(Expression<Func<T, bool>> expression) where T : LbdBaseModel, new()
        {
            var sql = ExpressionToSql.Find(expression);
            var result = MySqlAdo.DataReaderToGenericsList<T>(connStr, sql, null);
            return result;
        }

        public int BulkInsert<T>(IEnumerable<T> t) where T : LbdBaseModel, new()
        {
            string tablename = MysqlCache<T>._TableName;
            var table = t.ConvertToDataTable(tablename);
            table.ToCsv();
            var columns = table.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToList();
            using (MySqlConnection conn = new MySqlConnection(connStr))
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

        public void InsertList<T>(IEnumerable<T> t) where T : LbdBaseModel, new()
        {

            //t.Validate();
            //var sql = MysqlCache<T>.GetInsert(t, out MySqlParameter[] parameters);
            //MySqlCommand command = new MySqlCommand(sql);
            //command.Parameters.AddRange(parameters);
            //_Commands.Add(command);
        }
    }
}
