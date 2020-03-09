    using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LBD.Framework.ExppressionExtends
{
    public class ConditionBuilderVisitor : ExpressionVisitor
    {

        private Stack<string> _stringStack = new Stack<string>();


        public string Condition()
        {
            var result = string.Concat(_stringStack.ToArray());
            _stringStack.Clear();

            return result;
        }


        /// <summary>
        /// 二元表达式
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("BinaryExpression");
            }

            this._stringStack.Push(" ) ");
            base.Visit(node.Right);
            _stringStack.Push($" { node.NodeType.ToSqlOperator() } ");
            base.Visit(node.Left);
            this._stringStack.Push(" ( ");

            return node;
        }

        /// <summary>
        /// 成员表达式
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override Expression VisitMember(MemberExpression node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("MemberExpression");
            }
            _stringStack.Push($" {node.Member.Name} ");

            return node;
        }


        /// <summary>
        /// 常量表达式
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("ConstantExpression");
            }
            _stringStack.Push($"'{ node.Value }'");

            return node;
        }

        /// <summary>
        /// 方法表达式
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("MethodCallExpression");
            }
            string format;
            switch (node.Method.Name)
            {
                case "StartsWith":
                    format = " ({0} LIKE {1} %)";
                    break;
                case "Contains":
                    format = " ({0} LIKE %{1}%)";
                    break;
                case "EndsWith":
                    format = " ({0} LIKE % {1})";
                    break;
                default:
                    throw new NotSupportedException(node.Method.Name + "is not supported");
            }
            this.Visit(node.Object);
            this.Visit(node.Arguments[0]);

            string right = _stringStack.Pop();
            string left = _stringStack.Pop();
            _stringStack.Push(string.Format(format, left, right));
            return node;
        }

    }
}
