using System.Runtime.Serialization;

namespace CustomExceptions;

[System.Serializable]
public class UsernameNotAvailableExceptionException : System.Exception
{
    public UsernameNotAvailableExceptionException() { }
    public UsernameNotAvailableExceptionException(string message) : base(message) { }
    public UsernameNotAvailableExceptionException(string message, System.Exception inner) : base(message, inner) { }
    protected UsernameNotAvailableExceptionException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}