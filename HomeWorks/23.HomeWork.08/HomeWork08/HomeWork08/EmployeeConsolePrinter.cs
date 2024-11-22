using HomeWork08.Abstractions;
using HomeWork08.Models;
using Spectre.Console;

namespace HomeWork08;
public class EmployeeConsolePrinter : IEntityPrinter<Employee>
{
    public void PrintTitle(string text)
    {
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine($"[bold]{text}[/]");
    }

    public void ShowInfo(Employee? value)
    {
        if (value is not null)
            AnsiConsole.MarkupLine($"- [yellow]{value.Name}[/]: {value.Salary} руб.");
        else
            AnsiConsole.MarkupLine($"- [red]Такой сотрудник не найден.[/]");
    }
}
