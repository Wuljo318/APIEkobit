using BusinessEkobit.Exceptions;
using System.Text.RegularExpressions;

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

            }
            catch
            {
                throw new EmailNotCorrectException("Wrong email!");
            }
        }
    }
}
