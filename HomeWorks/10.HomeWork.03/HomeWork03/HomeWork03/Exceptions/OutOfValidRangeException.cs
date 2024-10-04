namespace HomeWork03.Exceptions;
public class OutOfValidRangeException : Exception
{
    public OutOfValidRangeException() : base() { }

    public OutOfValidRangeException(string? message) : base(message) { }

    public OutOfValidRangeException(string? message, Exception innerException) : base(message, innerException) { }
}
