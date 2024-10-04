using HomeWork03.Abstractions;
using System.Text;

namespace HomeWork03.Services;
public sealed class QuadEquationPrinter : IEquationPrinter
{
    private ConsoleHelper _consoleHelper;

    public QuadEquationPrinter(ConsoleHelper consoleHelper)
    {
        _consoleHelper = consoleHelper;
    }

    public void PrintEquationInput(OutputManager manager)
    {
        _consoleHelper.PrintColoredLine(manager.EquationLine.Text, manager.EquationLine.Position, manager.EquationLine.Color);

        foreach (var line in manager.Lines)
        {
            var lineText = new StringBuilder();
            lineText.Append(line.IsSelected ? "> " : "  ");
            lineText.Append($"{line.Prefix}: ");
            lineText.Append(line.Text);
            _consoleHelper.PrintColoredLine(lineText.ToString(), line.Position, line.Color);
        }
    }

    public void PrintEquationOutput(int consoleTopPosition, double? x1, double? x2)
    {
        _consoleHelper.ClearBelow(consoleTopPosition);

        var separator = new string('-', 50);
        var color = ConsoleColor.White;

        _consoleHelper.SetToPosition(consoleTopPosition);
        _consoleHelper.ColoredPrint(separator, color);

        if (x1.HasValue && x2.HasValue)
        {
            _consoleHelper.ColoredPrint($"x1 = {x1}; x2 = {x2}", color);
        }
        else if (x1.HasValue)
        {
            _consoleHelper.ColoredPrint($"x = {x1}", color);
        }
    }
}
