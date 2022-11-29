using LBD.Framework.MappingExtend;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LBD.Framework.SQLCache
{
    /// <summary>
    /// 泛型缓存 mysql语句
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MysqlCache<T>
    {
        /// <summary>
        /// 
        /// </summary>
        private static string _selectSql = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private static string Where = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private static string _insertSql = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private static string _InsertList = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private static string _deleteSql = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private static string _updateSql = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private static Type _Type = typeof(T);

        /// <summary>
        /// 
        /// </summary>
        private static string _PropertyStr;

        /// <summary>
        /// 
        /// </summary>
        public static PropertyInfo[] propertyInfos;

        /// <summary>
        /// 
        /// </summary>
        public static string _TableName;

        /// <summary>
        /// 
        /// </summary>
        private static PropertyInfo _KeyProperty;

        /// <summary>
        /// 
        /// </summary>
        static MysqlCache()
        {
            _TableName = _Type.GetName();

            propertyInfos = _Type.GetProperties();

            _KeyProperty = _Type.GetPropertyLBDKye();

            _PropertyStr = string.Join(",", propertyInfos.Select(x => x.GetName()));

            {
                _selectSql = $" select {_PropertyStr} from {_TableName} where Id=@Id ";

            }

            {

                _insertSql = $" insert into {_TableName} ({string.Join(",", _Type.GetPropertysWithoutKey().Select(x => x.GetName()))}) VALUES ({string.Join(",", _Type.GetPropertysWithoutKey().Select(x => $"@{x.GetName()}"))}) ;";

            }
            {
                // _InsertList= $" insert into { _TableName} ({string.Join(",", _Type.GetPropertysWithoutKey().Select(x => x.GetName())) }) VALUES ({ string.Join(",", _Type.GetPropertysWithoutKey().Select(x => $"@{x.GetName()}"))  }) ;";
            }

            {
                _deleteSql = $" delete from {_TableName} where Id=@Id ;";
            }

            {
                var setSql = string.Join(",", propertyInfos.Where(x => !x.IsDefined(typeof(LBDKeyAttribute), true)).Select(x => $"{x.GetName()}=@{x.GetName()}"));
                _updateSql = $" update {_TableName} set {setSql} where Id=@Id";
            }
        }

        /// <summary>
        ///  查询
        /// </summary>
        /// <returns></returns>
        public static string GetSelect()
        {
            return _selectSql;
        }

        /// <summary>
        /// 获取更新
        /// </summary>
        /// <param name="t"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string GetUpdate(T t, out MySqlParameter[] parameters)
        {
            var paras = new List<MySqlParameter>();
            foreach (var item in propertyInfos.Where(x => !x.IsDefined(typeof(LBDKeyAttribute), true)))
            {
                paras.Add(new MySqlParameter($"@{item.GetName()}", item.GetValue(t)));
            }
            var keyPropertName = _KeyProperty.GetName();
            paras.Add(new MySqlParameter($"@{keyPropertName}", _KeyProperty.GetValue(t)));
            parameters = paras.ToArray();
            return _updateSql;
        }

        /// <summary>
        /// 获取删除
        /// </summary>
        /// <param name="t"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetDelete(T t, out MySqlParameter parameter)
        {

            var value = _KeyProperty.GetValue(t);
            if (value == null)
            {
                throw new Exception("主键值为空");
            }
            parameter = new MySqlParameter($"@{_KeyProperty.GetName()}", value);
            return _deleteSql;
        }

        /// <summary>
        /// 获取新增
        /// </summary>
        /// <param name="t"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string GetInsert(T t, out MySqlParameter[] parameters)
        {
            var paras = new List<MySqlParameter>();

            foreach (var item in propertyInfos)
            {
                paras.Add(new MySqlParameter($"@{item.GetName()}", item.GetValue(t)));
            }
            parameters = paras.ToArray();
            return _insertSql;
        }
    }
}
