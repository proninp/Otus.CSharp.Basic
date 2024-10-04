using HomeWork03.Abstractions;
using HomeWork03.Exceptions;
using HomeWork03.Infrastructure;

namespace HomeWork03.Services;
public sealed class QuadEquationSolver : IEquationSolver
{
    private IExceptionHandler _exceptionHandler;

    public QuadEquationSolver(IExceptionHandler exceptionHandler)
    {
        _exceptionHandler = exceptionHandler;
    }

    public (double? x1, double? x2) Solve(int a, int b, int c)
    {
        if (a == 0)
        {
            var ex = new ArgumentException(Messages.Exceptions.IncorrectFirstArgument);
            _exceptionHandler.CollectExceptionData(ex, a, b, c);
            throw ex;
        }

        var discriminant = b * b - 4 * a * c;
        double? x1 = null;
        double? x2 = null;
        if (discriminant > 0)
        {
            x1 = (-b + Math.Sqrt(discriminant)) / 2.0 / a;
            x2 = (-b - Math.Sqrt(discriminant)) / 2.0 / a;
        }
        else if (discriminant == 0)
        {
            x1 = -b / 2.0 / a;
        }
        else
        {
            var ex = new NoRealValuesException(Messages.Exceptions.NoRealValuesText);
            _exceptionHandler.CollectExceptionData(ex, a, b, c);
            throw ex;
        }
        return (x1, x2);
    }
}