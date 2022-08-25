namespace CustomExceptions;
public class CartNotFoundException : System.Exception
{
    public CartNotFoundException() { }
    public CartNotFoundException(string message) : base(message) { }
    public CartNotFoundException(string message, System.Exception inner) : base(message, inner) { }
    protected CartNotFoundException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
public class ItemNotFoundException : System.Exception
{
    public ItemNotFoundException() { }
    public ItemNotFoundException(string message) : base(message) { }
    public ItemNotFoundException(string message, System.Exception inner) : base(message, inner) { }
    protected ItemNotFoundException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

public class UserNotFoundException : System.Exception
{
    public UserNotFoundException() { }
    public UserNotFoundException(string message) : base(message) { }
    public UserNotFoundException(string message, System.Exception inner) : base(message, inner) { }
    protected UserNotFoundException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}