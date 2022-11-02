using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Framework
{
    public class OriginException : Exception
    {
        public OriginException(string Message) : base(Message)
        { }

        public OriginException(string Message, Exception ex) : base(Message, ex)
        { }

        public OriginException(Exception ex) : base(ex.Message, ex)
        { }
    }
}
