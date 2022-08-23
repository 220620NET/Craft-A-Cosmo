using System.Runtime.Serialization;

namespace CustomExceptions;

[System.Serializable]
public class UserNotAvailableExceptionException : System.Exception
{
    public UserNotAvailableExceptionException() { }
    public UserNotAvailableExceptionException(string message) : base(message) { }
    public UserNotAvailableExceptionException(string message, System.Exception inner) : base(message, inner) { }
    protected UserNotAvailableExceptionException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}