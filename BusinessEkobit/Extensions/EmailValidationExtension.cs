using BusinessEkobit.Exceptions;
using System.Text.RegularExpressions;

namespace BusinessEkobit.Extensions
{
    public static class EmailValidationExtension
    {
        public static void EmailCheck(this string email)
        {
            Regex regex = new("@\"^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$\"");
            if (!regex.Match(email).Success)
            {
                throw new EmailNotCorrectException("Wrong email!");
            }
        }

    }
}
