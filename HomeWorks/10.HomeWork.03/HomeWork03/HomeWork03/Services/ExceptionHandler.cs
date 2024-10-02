using HomeWork03.Models;
using System.Text;

namespace HomeWork03.Services;
public class ExceptionHandler
{
    public string GetFormatedData(string message, string output)
    {
        var separator = new string('-', 50);

        return new StringBuilder(separator)
            .Append(Environment.NewLine)
            .Append(message)
            .Append(Environment.NewLine)
            .Append(separator)
            .Append(Environment.NewLine)
            .Append(output)
            .ToString();
    }

    public ConsoleColor GetConsoleColor(Severity severity) =>
        severity switch
        {
            Severity.Warning => ConsoleColor.Yellow,
            Severity.Exception => ConsoleColor.DarkGreen,
            Severity.Fatal => ConsoleColor.DarkRed,
            _ => Console.BackgroundColor
        };
}
