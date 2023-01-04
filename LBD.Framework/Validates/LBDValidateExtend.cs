using LBD.Common.Execptions;
using LBD.Framework.MappingExtend;
using System.Linq;
using System.Reflection;

namespace LBD.Framework.Validates
{
    /// <summary>
    /// 验证
    /// </summary>
    public static class LBDValidateExtend
    {
        public static bool Validate<T>(this T t) where T : class
        {
            var type = typeof(T);
            var propertys = type.GetProperties().Where(x => x.IsDefined(typeof(LBDAbstractValidateAttribute), true));
            foreach (var item in propertys)
            {
                var lbdAttributes = item.GetCustomAttributes<LBDAbstractValidateAttribute>();
                var value = item.GetValue(t);
                foreach (var lbd in lbdAttributes)
                {
                    if (!lbd.Validate(value))
                    {
                        throw new LbdException("数据验证错误");
                    }
                }
            }

            return true;
        }
    }
}
