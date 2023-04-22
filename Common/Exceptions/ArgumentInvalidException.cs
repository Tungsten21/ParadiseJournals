using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class ArgumentInvalidException : Exception
    {   
        public ArgumentInvalidException(string message)
        :base(message)
        { }
       
        public ArgumentInvalidException(string message, Exception inner)
        :base(message, inner)
        { }
    }
}
