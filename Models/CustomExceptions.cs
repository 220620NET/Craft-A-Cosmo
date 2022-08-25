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

public class NoProductsMatchThisDescription : Exception
{
    public NoProductsMatchThisDescription() { }
    public NoProductsMatchThisDescription(string message) : base(message) { }
    public NoProductsMatchThisDescription(string message, System.Exception inner) : base(message, inner) { }
    protected NoProductsMatchThisDescription(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

public class NoNegatives : Exception
{
    public NoNegatives() { }
    public NoNegatives(string message) : base(message) { }
    public NoNegatives(string message, System.Exception inner) : base(message, inner) { }
    protected NoNegatives(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

public class IncorrectEntry : Exception
{
    public IncorrectEntry() { }
    public IncorrectEntry(string message) : base(message) { }
    public IncorrectEntry(string message, System.Exception inner) : base(message, inner) { }
    protected IncorrectEntry(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

public class CategoryNotFound : Exception
{
    public CategoryNotFound() { }
    public CategoryNotFound(string message) : base(message) { }
    public CategoryNotFound(string message, System.Exception inner) : base(message, inner) { }
    protected CategoryNotFound(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}