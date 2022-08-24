using System.Runtime.Serialization;

namespace CustomExceptions;

public class InvalidInputException  : Exception
{
    public InvalidInputExceptionException()
    {
    }

    public InvalidInputExceptionException(string? message) : base(message)
    {
    }

    public InvalidInputExceptionException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected InvalidInputExceptionException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}