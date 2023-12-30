using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : base()
        {

        }
        public BadRequestException(string message) : base(message)
        { 

        }
    }
}
