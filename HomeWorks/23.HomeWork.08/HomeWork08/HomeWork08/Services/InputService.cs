using HomeWork08.Abstractions;
using Spectre.Console;

namespace HomeWork08.Services;
public class InputService : IInputService
{
    public T Ask<T>(string question) =>
        AnsiConsole.Ask<T>(question);

    public string Prompt(string text)
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>(text)
            .AllowEmpty());
    }

    public string Prompt(string promptTitle, IEnumerable<string> choices)
    {
        var actionText = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(promptTitle)
                    .AddChoices(choices));
        return actionText;
    }
}
