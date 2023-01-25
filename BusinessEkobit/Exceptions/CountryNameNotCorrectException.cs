using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEkobit.Exceptions
{
    public class CountryNameNotCorrectException : Exception
    {
        public CountryNameNotCorrectException()
        {

        }
        public CountryNameNotCorrectException(string message)
            : base(message) 
        { 

        }

        public CountryNameNotCorrectException(string message, Exception ex)
            : base(message, ex)
        {

        }

    }
}
