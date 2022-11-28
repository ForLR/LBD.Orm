using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LBD.Framework.MappingExtend
{
    public static class AttributeExtend
    {
        /// <summary>
        /// 获取特性标注的名称
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetName(this MemberInfo type)
        {
            if (type.IsDefined(typeof(LBDAbstractNameAttribute), true))
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

        /// <summary>
        /// 获取标识的主键
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static PropertyInfo GetPropertyLBDKye(this Type type)
        {
            if (type.GetProperties().Count(x => x.IsDefined(typeof(LBDKeyAttribute), true)) > 1)
            {
                throw new LbdException("不支持的多主键");
            }
            return type.GetProperties().FirstOrDefault(x => x.IsDefined(typeof(LBDKeyAttribute), true));

        }
    }
}
