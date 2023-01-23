using BusinessEkobit.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessEkobit.Extensions
{
    public static class EmailValidationExtension2
    {
        public static void EmailCheck(string email)
        {
            Regex regex = new Regex("@\"^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$\"");
            try
            {
                var equal = regex.Match(email);
                //if (!equal.Success)
                //{
                //    throw new EmailNotCorrectException();
                //}

            }
            catch
            {
                throw new EmailNotCorrectException("Wrong email!");
            }
        }
    }
}
