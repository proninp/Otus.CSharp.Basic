﻿namespace HomeWork03.Exceptions;
public class EquasionTypeException : Exception
{
    public EquasionTypeException() : base() { }

    public EquasionTypeException(string? message) : base(message) { }

    public EquasionTypeException(string? message, Exception? innerException) : base(message, innerException) { }
}
