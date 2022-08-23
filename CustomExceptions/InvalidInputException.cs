using System.Runtime.Serialization;

namespace CustomExceptions;

[System.Serializable]
public class InvalidInputExceptionException : System.Exception
{
    public InvalidInputExceptionException() { }
    public InvalidInputExceptionException(string message) : base(message) { }
    public InvalidInputExceptionException(string message, System.Exception inner) : base(message, inner) { }
    protected InvalidInputExceptionException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}