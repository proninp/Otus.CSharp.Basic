using HomeWork08.Abstractions;
using HomeWork08.Models;
using Spectre.Console;

namespace HomeWork08.Services;
public class EmployeeConsolePrinter : ConsolePrinterBase, IEntityPrinter<Employee>
{
    public void ShowInfo(Employee? value)
    {
        if (value is not null)
            AnsiConsole.MarkupLine($"- [yellow]{value.Name}[/]: {value.Salary} $");
        else
            AnsiConsole.MarkupLine($"- [red]Такой сотрудник не найден.[/]");
    }
}
