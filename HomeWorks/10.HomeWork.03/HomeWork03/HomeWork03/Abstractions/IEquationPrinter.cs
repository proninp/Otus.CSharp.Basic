using HomeWork03.Services;

namespace HomeWork03.Abstractions;
public interface IEquationPrinter
{
    public void PrintEquationInput(OutputManager manager);

    public void PrintEquationOutput(int consoleTopPosition, double? x1, double? x2);
}
