namespace BusinessEkobit.Exceptions
{

    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
        {

        }

        public EntityNotFoundException(string message)
            : base(message)
        {
            Console.WriteLine(message);
        }

        public EntityNotFoundException(string message, Exception ex)
            : base(message, ex)
        {
            Console.WriteLine(message);
        }
    }
}
