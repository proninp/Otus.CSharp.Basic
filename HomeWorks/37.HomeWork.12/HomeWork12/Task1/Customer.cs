using Spectre.Console;
using Task1.Interfaces;

namespace Task1;
public sealed class Customer : IOtusObserver
{
    public string Name { get; init; }

    public Customer(string name)
    {
        Name = name;
    }

    public void Update(string message) =>
        AnsiConsole.MarkupLine($"[cyan]{Name}[/]: {message}");
}