using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LBD.Framework.ExppressionExtends
{
    public static class ExpressionTypeExtend
    {

        /// <summary>
        ///  表达式树的连接类型转为数据库类型
        /// </summary>
        /// <param name="expressionType"></param>
        /// <returns></returns>
        public static string ToSqlOperator(this ExpressionType expressionType)
        {
            var result = string.Empty;
            switch (expressionType)
            {
                case ExpressionType.Add:
                case ExpressionType.AddChecked:
                    return " + ";
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                    return " AND ";
                case ExpressionType.ArrayLength:
                    throw new Exception("不支持该方法");
                case ExpressionType.ArrayIndex:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Call:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Coalesce:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Conditional:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Constant:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Convert:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.ConvertChecked:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Divide:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Equal:
                    return " = ";
                case ExpressionType.ExclusiveOr:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.GreaterThan:
                    return " > ";
                case ExpressionType.GreaterThanOrEqual:
                    return " >= ";
                case ExpressionType.Invoke:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Lambda:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.LeftShift:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.LessThan:
                    return " < ";
                case ExpressionType.LessThanOrEqual:
                    return " <= ";
                case ExpressionType.ListInit:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.MemberAccess:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.MemberInit:
                    return " / ";
                case ExpressionType.Modulo:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.MultiplyChecked:
                case ExpressionType.Multiply:
                    return " * ";
                case ExpressionType.Negate:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.UnaryPlus:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.NegateChecked:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.New:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.NewArrayInit:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.NewArrayBounds:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Not:
                    return " NOT ";
                case ExpressionType.NotEqual:
                    return " <> ";
                case ExpressionType.OrElse:
                case ExpressionType.Or:
                    return " OR ";

                case ExpressionType.Parameter:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Power:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Quote:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.RightShift:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Subtract:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.SubtractChecked:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.TypeAs:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.TypeIs:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Assign:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Block:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.DebugInfo:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Decrement:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Dynamic:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Default:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Extension:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Goto:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Increment:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Index:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Label:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.RuntimeVariables:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Loop:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Switch:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Throw:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Try:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.Unbox:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.AddAssign:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.AndAssign:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.DivideAssign:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.ExclusiveOrAssign:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.LeftShiftAssign:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.ModuloAssign:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.MultiplyAssign:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.OrAssign:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.PowerAssign:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.RightShiftAssign:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.SubtractAssign:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.AddAssignChecked:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.MultiplyAssignChecked:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.SubtractAssignChecked:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.PreIncrementAssign:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.PreDecrementAssign:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.PostIncrementAssign:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.PostDecrementAssign:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.TypeEqual:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.OnesComplement:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.IsTrue:
                    throw new Exception("不支持该方法"); ;
                case ExpressionType.IsFalse:
                    throw new Exception("不支持该方法"); ;
                default:
                    throw new Exception("不支持该方法"); ;
            }

            return result;
        }

    }
}
