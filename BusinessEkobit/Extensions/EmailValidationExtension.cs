using BusinessEkobit.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessEkobit.Extensions
{
    public static class EmailValidationExtension
    {
        public static void EmailCheck(this string email)
        {
            Regex regex = new Regex("@\"^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$\"");
            if (!regex.Match(email).Success)
            {
                throw new EmailNotCorrectException("Wrong email!");
            }
        }
        
    }
}
