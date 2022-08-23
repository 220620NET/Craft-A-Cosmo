using System.Runtime.Serialization;

namespace CustomExceptions;

[System.Serializable]
public class EmailNotAvailableExceptionException : System.Exception
{
    public EmailNotAvailableExceptionException() { }
    public EmailNotAvailableExceptionException(string message) : base(message) { }
    public EmailNotAvailableExceptionException(string message, System.Exception inner) : base(message, inner) { }
    protected EmailNotAvailableExceptionException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}