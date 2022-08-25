namespace CustomExceptions;


public class ResourceNotFound : Exception
{
    public ResourceNotFound() { }
    public ResourceNotFound(string message) : base(message) { }
    public ResourceNotFound(string message, System.Exception inner) : base(message, inner) { }
    protected ResourceNotFound(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

    public class ProductNotAvailableException : Exception
    {
        public ProductNotAvailableException()
        {
        }

        public ProductNotAvailableException(string? message) : base(message)
        {
        }

        public ProductNotAvailableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
            protected ProductNotAvailableException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
