using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base()
        {
            Console.WriteLine();
        }

        public NotFoundException(string message) : base(message)
        {
            Console.WriteLine(message);
        }
    }
}
