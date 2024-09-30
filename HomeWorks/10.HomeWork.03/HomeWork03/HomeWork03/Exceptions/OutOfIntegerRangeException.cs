namespace HomeWork03.Exceptions;
public class OutOfIntegerRangeException : Exception
{
    public OutOfIntegerRangeException(string? message) : base(message) { }
    public OutOfIntegerRangeException(string? message, Exception innerException) : base(message, innerException) { }
}
