using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEkobit.Exceptions
{

    public class EntityNotFound : Exception
    {
        public EntityNotFound()
        {

        }

        public EntityNotFound(string message)
            : base(message)
        {
            Console.WriteLine(message);
        }

        public EntityNotFound(string message, Exception ex)  
            : base(message, ex)
        {
            Console.WriteLine(message);
        }
    }
}
