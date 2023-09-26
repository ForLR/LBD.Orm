using LBD.Framework.MappingExtend;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Reflection;
using System.Text;

namespace LBD.CodeFirst
{
    public class SqlCodeMapping : ICodeMapping
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual string MappingToSql<T>() where T : class
        {
            var mappingDescription = GetMappingDescription<T>();
            var sqlBuilder = new StringBuilder();

            sqlBuilder.AppendLine($"CREATE TABLE {mappingDescription.TableName} (");
            foreach (var item in mappingDescription.MappingColunms)
            {
                sqlBuilder.AppendLine($@" [{item.Name}] [{GetSqlDbTypeFromCSharpType(item.Type)}] {(item.AllowIsNull ? "NULL" : "NOT NULL")} {(item.DefaultValue != null ? $"DEFAULT (({item.DefaultValue}))" : "")}");
            }
            sqlBuilder.AppendLine(")");

            if (mappingDescription.IndexColunmDescriptions != null && mappingDescription.IndexColunmDescriptions.Count > 0)
            {
                foreach (var item in mappingDescription.IndexColunmDescriptions)
                {
                    sqlBuilder.AppendLine($@" CREATE INDEX {(item.IsUnique ? "UNIQUE" : "")} {item.IndexName} ON {mappingDescription.TableName} ({mappingDescription.IndexColunmDescriptions.SelectMany(x => x.IndexFields).Aggregate((x, y) => $@"{x},{y}")})");
                }
            }
            return sqlBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual MappingDescription GetMappingDescription<T>()
        {
            Type type = typeof(T);
            var table = type.Name;
            var result = new MappingDescription()
            {
                TableName = table
            };
            var instance = Activator.CreateInstance<T>();
            var mappingColunms = new List<MappingColunmDescription>();
            var indexColunmDescriptions = new List<MappingIndexColunmDescription>();
            foreach (var item in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var columnName = item.GetCustomAttribute<LBDPropertyAttribute>(false)?.GetName() ?? item.Name;
                var isRequired = item.GetCustomAttribute<LBDRequiredAttribute>(false);
                var description = item.GetCustomAttribute<DescriptionAttribute>(false);

                mappingColunms.Add(new MappingColunmDescription
                {
                    Name = columnName,
                    AllowIsNull = isRequired == null,
                    Description = description?.Description ?? string.Empty,
                    Type = item.PropertyType,
                    DefaultValue = item.GetValue(instance)
                });
            }
            var indexs = type.GetCustomAttributes<LBDIndexAttribute>(true);
            foreach (var index in indexs)
            {
                indexColunmDescriptions.Add(new MappingIndexColunmDescription
                {
                    IndexName = index.IndexName,
                    IsUnique = index.IsUnique,
                    IndexFields = index.IndexFields,
                });
            }

            result.MappingColunms = mappingColunms;
            result.IndexColunmDescriptions = indexColunmDescriptions;
            return result;
        }

        public static SqlDbType GetSqlDbTypeFromCSharpType(Type type)
        {
            // 使用switch语句将C#数据类型映射到SqlDbType
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Int32:
                    return SqlDbType.Int;
                case TypeCode.Int64:
                    return SqlDbType.BigInt;
                case TypeCode.Int16:
                    return SqlDbType.SmallInt;
                case TypeCode.String:
                    return SqlDbType.NVarChar;
                case TypeCode.DateTime:
                    return SqlDbType.DateTime;
                case TypeCode.Boolean:
                    return SqlDbType.Bit;
                case TypeCode.Single:
                    return SqlDbType.Float;
                case TypeCode.Double:
                    return SqlDbType.Float;
                case TypeCode.Decimal:
                    return SqlDbType.Decimal;
                case TypeCode.Byte:
                    return SqlDbType.TinyInt;
                case TypeCode.Char:
                    return SqlDbType.Char;
                case TypeCode.SByte:
                    return SqlDbType.TinyInt;
                case TypeCode.UInt16:
                    return SqlDbType.SmallInt;
                case TypeCode.UInt32:
                    return SqlDbType.Int;
                case TypeCode.UInt64:
                    return SqlDbType.BigInt;
                case TypeCode.Object:
                    if (type == typeof(Guid))
                    {
                        return SqlDbType.UniqueIdentifier;
                    }
                    else if (type == typeof(byte[]))
                    {
                        return SqlDbType.VarBinary;
                    }
                    else if (type == typeof(TimeSpan))
                    {
                        return SqlDbType.Time;
                    }
                    else if (type == typeof(SqlXml))
                    {
                        return SqlDbType.Xml;
                    }
                    // 添加更多对象类型映射...
                    break;
                default:
                    throw new ArgumentException($"Unsupported C# type: {type.Name}");
            }
            throw new ArgumentException($"Unsupported C# type: {type.Name}");
        }
    }
}
