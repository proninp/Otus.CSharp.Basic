using HomeWork03.Abstractions;
using HomeWork03.Models;


namespace HomeWork03.Services;
public sealed class QuadEquationValidator : IEquationValidator
{
    private IExceptionHandler _exceptionHandler;

    public QuadEquationValidator(IExceptionHandler exceptionHandler)
    {
        _exceptionHandler = exceptionHandler;
    }

    public int[] Validate(Coefficient[] coefficients)
    {
        var result = new int[coefficients.Length];
        for (int i = 0; i < coefficients.Length; i++)
        {
            var coefficient = coefficients[i];
            if (!coefficient.IsValidNumber)
            {
                Exception exception = _exceptionHandler.CreateValidationException(coefficient);
                _exceptionHandler.CollectExceptionData(exception, coefficients[0].Value, coefficients[1].Value, coefficients[2].Value);
                throw exception;
            }
            result[i] = coefficient.Number!.Value;
        }
        return result;
    }
}
