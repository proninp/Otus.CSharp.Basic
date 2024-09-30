namespace HomeWork03.Exceptions;
public class NoRealValuesException : Exception
{
    public NoRealValuesException(string? message) : base(message) { }
    public NoRealValuesException(string? message, Exception innerException) : base(message, innerException) { }
}
