using LBD.Framework.MappingExtend;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LBD.Framework.ExppressionExtends
{
    /// <summary>
    /// 
    /// </summary>
    public static class ExpressionToSql
    {

        public static string Find<T>(Expression<Func<T, bool>> expression)
        {

            var condition = new ConditionBuilderVisitor();
            condition.Visit(expression);
            var where = condition.Condition();

            var sql = $"select * from {typeof(T).GetName()} where {where}";

            return sql;
        }

    }
}
