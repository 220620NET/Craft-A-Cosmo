using Models;



namespace CustomExceptions
{
    public class UserNotFound : Exception
    {
        public UserNotFound()
        {
        }

        public UserNotFound(string? message) : base(message)
        {
        }

        public UserNotFound(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}