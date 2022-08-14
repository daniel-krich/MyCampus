namespace MyCampusUI.Exceptions
{
    public class InvalidCredentialsException : ApplicationException
    {
        public InvalidCredentialsException() : base()
        {

        }

        public InvalidCredentialsException(string message) : base(message)
        {

        }
    }
}
