using HomeWork08.Models;
using Spectre.Console;

namespace HomeWork08;
public class EmployeeProvider
{
    public Employee? GetEmployee()
    {
        var name = AnsiConsole.Ask<string>("Введите [green]имя сотрудника[/] (или нажмите [red]Enter[/] для завершения):");
        if (string.IsNullOrWhiteSpace(name))
        {
            return default;
        }
        var salary = AnsiConsole.Ask<int>($"Введите [green]зарплату[/] для сотрудника [yellow]{name}[/]:");

        return new Employee { Name = name, Salary = salary };
    }
}
