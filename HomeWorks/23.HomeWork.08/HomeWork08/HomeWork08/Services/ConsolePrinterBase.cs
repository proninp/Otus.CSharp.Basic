using HomeWork08.Abstractions;
using Spectre.Console;

namespace HomeWork08.Services;
public class ConsolePrinterBase : IPrinter
{
    public void PrintTitle(string text)
    {
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine($"[bold]{text}[/]");
    }

    public void Print(string text) =>
        AnsiConsole.MarkupLine(text);

    public void NewLine() =>
        AnsiConsole.WriteLine();
}