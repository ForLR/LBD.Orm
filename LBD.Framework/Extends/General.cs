using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using LBD.Framework.MappingExtend;

namespace LBD.Framework.Extends
{
    public static class General
    {
        public static void ToCsv(this DataTable table)
        {
            //以半角逗号（即,）作分隔符，列为空也要表达其存在。
            //列内容如存在半角逗号（即,）则用半角引号（即""）将该字段值包含起来。
            //列内容如存在半角引号（即"）则应替换成半角双引号（""）转义，并用半角引号（即""）将该字段值包含起来。
            StringBuilder sb = new StringBuilder();
            DataColumn colum;
            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    colum = table.Columns[i];
                    if (i != 0) sb.Append(",");
                    if (colum.DataType == typeof(string) && row[colum].ToString().Contains(","))
                    {
                        sb.Append("\"" + row[colum].ToString().Replace("\"", "\"\"") + "\"");
                    }
                    else sb.Append(row[colum].ToString());
                }
                sb.AppendLine();
            }
            File.WriteAllText(table.TableName + ".csv", sb.ToString());

        }

        /// <summary>
        /// 对象集合转DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable<T>(this IEnumerable<T> t, string tableName)
        {
            if (t == null)
            {
                throw new ArgumentNullException("转换的集合为空");
            }
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            DataTable dt = new DataTable(!string.IsNullOrWhiteSpace(tableName) ? tableName : type.Name);
            foreach (var item in properties)
            {
                dt.Columns.Add(new DataColumn(item.GetName()) { DataType = item.PropertyType });
            }
            foreach (var item in t)
            {
                DataRow row = dt.NewRow();
                foreach (var property in properties)
                {
                    row[property.GetName()] = property.GetValue(item);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}
