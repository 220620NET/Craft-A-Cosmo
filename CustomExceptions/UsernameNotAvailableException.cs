using System.Runtime.Serialization;

namespace CustomExceptions;
 
public class UsernameNotAvailableException : Exception
{
    public UsernameNotAvailableException()
    {
    }

    public UsernameNotAvailableException(string? message) : base(message)
    {
    }

    public UsernameNotAvailableException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected UsernameNotAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}