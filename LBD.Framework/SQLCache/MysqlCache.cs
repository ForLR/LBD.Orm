using LBD.Framework.MappingExtend;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LBD.Framework.SQLCache
{
    /// <summary>
    /// 泛型缓存 mysql语句
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MysqlCache<T>
    {

        private static string _Select = string.Empty;

        private static string Where = string.Empty;


        private static string _Insert = string.Empty;

        private static string _InsertList = string.Empty;


        private static string _Delete = string.Empty;

        private static string _Update = string.Empty;

        private static Type _Type = typeof(T);

        private static string _PropertyStr;

        public static PropertyInfo[] propertyInfos;

        public static string _TableName;

        private static PropertyInfo _KeyProperty;
        static MysqlCache()
        {
            _TableName = _Type.GetName();

            propertyInfos = _Type.GetProperties();

            _KeyProperty = _Type.GetPropertyLBDKye();

            _PropertyStr = string.Join(",", propertyInfos.Select(x => x.GetName()));

            {
                _Select = $" select {_PropertyStr} from { _TableName } where Id=@Id ";

            }

            {

                _Insert = $" insert into { _TableName} ({string.Join(",", _Type.GetPropertysWithoutKey().Select(x => x.GetName())) }) VALUES ({ string.Join(",", _Type.GetPropertysWithoutKey().Select(x => $"@{x.GetName()}"))  }) ;";

            }
            {
                // _InsertList= $" insert into { _TableName} ({string.Join(",", _Type.GetPropertysWithoutKey().Select(x => x.GetName())) }) VALUES ({ string.Join(",", _Type.GetPropertysWithoutKey().Select(x => $"@{x.GetName()}"))  }) ;";
            }

            {
                _Delete = $" delete from {_TableName} where Id=@Id ;";
            }

            {
                var setSql = string.Join(",", propertyInfos.Where(x => !x.IsDefined(typeof(LBDKeyAttribute), true)).Select(x => $"{x.GetName()}=@{x.GetName()}"));
                _Update = $" update {_TableName} set {setSql } where Id=@Id";
            }
        }

        public static string GetSelect()
        {
            return _Select;
        }

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
            return _Update;
        }

        public static string GetDelete(T t, out MySqlParameter parameter)
        {

            var value = _KeyProperty.GetValue(t);
            if (value == null)
            {
                throw new Exception("主键值为空");
            }
            parameter = new MySqlParameter($"@{_KeyProperty.GetName()}", value);
            return _Delete;
        }

        public static string GetInsert(T t, out MySqlParameter[] parameters)
        {
            var paras = new List<MySqlParameter>();

            foreach (var item in propertyInfos)
            {
                paras.Add(new MySqlParameter($"@{item.GetName()}", item.GetValue(t)));
            }
            parameters = paras.ToArray();
            return _Insert;
        }
    }
}
