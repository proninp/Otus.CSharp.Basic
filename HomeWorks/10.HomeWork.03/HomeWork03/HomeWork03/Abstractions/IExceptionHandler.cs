using HomeWork03.Models;
using HomeWork03.Services;

namespace HomeWork03.Abstractions;
public interface IExceptionHandler
{
    public void Handle(Exception ex, OutputManager manager);

    public void CollectExceptionData<T>(Exception ex, params T[] coefficients);

    public Exception CreateValidationException(Coefficient coefficient);
}
