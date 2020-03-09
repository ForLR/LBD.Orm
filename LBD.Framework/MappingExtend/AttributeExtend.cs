using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace LBD.Framework.MappingExtend
{
    public static class AttributeExtend
    {
        public static string GetName(this MemberInfo type)
        {
            if (type.IsDefined(typeof(LBDAbstractNameAttribute),true))
            {
                LBDAbstractNameAttribute name = type.GetCustomAttribute<LBDAbstractNameAttribute>();
                return name.GetName();
            }
            return type.Name;
        }

        /// <summary>
        /// 获取非自增列
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetPropertysWithoutKey(this Type type)
        {
            return type.GetProperties().Where(x => !x.IsDefined(typeof(LBDKeyAttribute), true));
        }

        public static PropertyInfo GetPropertyLBDKye(this Type type)
        {
            return type.GetProperties().FirstOrDefault(x => x.IsDefined(typeof(LBDKeyAttribute), true));

        }
    }
}
