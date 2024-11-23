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

    public void Print(string text)
    {
        AnsiConsole.MarkupLine(text);
    }

    public string Prompt(string promptTitle, IEnumerable<string> choices)
    {
        var actionText = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(promptTitle)
                    .AddChoices(choices));

        return actionText;
    }

    public void NewLine()
    {
        AnsiConsole.WriteLine();
    }
}