using System.Runtime.Serialization;

namespace CustomExceptions;
 
public class EmailNotAvailableException : Exception
{
    public   EmailNotAvailableException()
    {
    }

    public EmailNotAvailableException(string? message) : base(message)
    {
    }

    public EmailNotAvailableException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected EmailNotAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}