using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBD.Framework
{
    public class LbdException: Exception
    {
        public LbdException()
        {

        }
        public LbdException(string message):base(message)
        {

        }
        public LbdException(string message, Exception exception) :base(message, exception)
        {

        }
    }
}
