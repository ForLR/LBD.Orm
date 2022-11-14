using System;

namespace LBD.Framework
{
    /// <summary>
    /// 
    /// </summary>
    public class LbdException : Exception
    {
        public LbdException()
        {

        }
        public LbdException(string message) : base(message)
        {

        }
        public LbdException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
