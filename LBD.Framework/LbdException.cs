using System;

namespace LBD.Framework
{
    /// <summary>
    /// 异常
    /// </summary>
    public class LbdException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public LbdException()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public LbdException(string message) : base(message)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public LbdException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
