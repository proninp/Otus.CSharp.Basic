using HomeWork03.Models;

namespace HomeWork03.Abstractions;
public interface IEquationFormatter
{
    public string Format(Coefficient[] equation);
}
