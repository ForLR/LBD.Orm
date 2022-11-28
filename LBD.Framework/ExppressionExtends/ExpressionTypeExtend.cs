using System.Linq.Expressions;

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
                    throw new LbdException("不支持该方法");
                case ExpressionType.ArrayIndex:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Call:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Coalesce:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Conditional:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Constant:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Convert:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.ConvertChecked:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Divide:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Equal:
                    return " = ";
                case ExpressionType.ExclusiveOr:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.GreaterThan:
                    return " > ";
                case ExpressionType.GreaterThanOrEqual:
                    return " >= ";
                case ExpressionType.Invoke:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Lambda:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.LeftShift:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.LessThan:
                    return " < ";
                case ExpressionType.LessThanOrEqual:
                    return " <= ";
                case ExpressionType.ListInit:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.MemberAccess:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.MemberInit:
                    return " / ";
                case ExpressionType.Modulo:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.MultiplyChecked:
                case ExpressionType.Multiply:
                    return " * ";
                case ExpressionType.Negate:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.UnaryPlus:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.NegateChecked:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.New:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.NewArrayInit:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.NewArrayBounds:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Not:
                    return " NOT ";
                case ExpressionType.NotEqual:
                    return " <> ";
                case ExpressionType.OrElse:
                case ExpressionType.Or:
                    return " OR ";

                case ExpressionType.Parameter:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Power:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Quote:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.RightShift:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Subtract:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.SubtractChecked:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.TypeAs:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.TypeIs:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Assign:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Block:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.DebugInfo:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Decrement:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Dynamic:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Default:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Extension:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Goto:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Increment:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Index:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Label:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.RuntimeVariables:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Loop:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Switch:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Throw:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Try:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.Unbox:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.AddAssign:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.AndAssign:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.DivideAssign:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.ExclusiveOrAssign:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.LeftShiftAssign:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.ModuloAssign:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.MultiplyAssign:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.OrAssign:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.PowerAssign:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.RightShiftAssign:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.SubtractAssign:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.AddAssignChecked:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.MultiplyAssignChecked:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.SubtractAssignChecked:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.PreIncrementAssign:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.PreDecrementAssign:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.PostIncrementAssign:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.PostDecrementAssign:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.TypeEqual:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.OnesComplement:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.IsTrue:
                    throw new LbdException("不支持该方法"); ;
                case ExpressionType.IsFalse:
                    throw new LbdException("不支持该方法"); ;
                default:
                    throw new LbdException("不支持该方法"); ;
            }

            return result;
        }

    }
}
