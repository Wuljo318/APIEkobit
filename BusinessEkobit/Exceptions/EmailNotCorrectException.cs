using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEkobit.Exceptions
{
    public class EmailNotCorrectException : Exception
    {
        public EmailNotCorrectException()
        {

        }

        public EmailNotCorrectException(string message)
            : base(message)
        {
            Console.WriteLine(message);
        }

        public EmailNotCorrectException(string message, Exception ex)
            : base(message, ex)
        {
            Console.WriteLine(message);
        }
    }
}
