using HomeWork03.Models;

namespace HomeWork03.Abstractions;
public interface IEquationValidator
{
    public int[] Validate(Coefficient[] coefficients);
}
