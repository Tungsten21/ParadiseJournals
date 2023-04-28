using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string message)
        : base(message)
        { }

        public ResourceNotFoundException(string message, Exception inner)
        : base(message, inner)
        { }
    }
}
