using HomeWork08.Abstractions;
using HomeWork08.Models;
using Spectre.Console;

namespace HomeWork08.Services;
public class EmployeeManager : IEmployeeManager
{
    private readonly List<Employee> _dataSeeder = new List<Employee>()
    {
        new Employee { Name = "Mark", Salary = 100_000 },
        new Employee { Name = "Nolan", Salary = 150_000 },
        new Employee { Name = "Alan", Salary = 170_000 },
        new Employee { Name = "Oliver", Salary = 50_000 },
        new Employee { Name = "Cecil", Salary = 120_000 },
    };

    public IEnumerable<Employee> GetEmployee()
    {
        foreach (var emp in _dataSeeder)
            yield return emp;

        var name = AnsiConsole.Prompt(
            new TextPrompt<string>("Введите [green]имя сотрудника[/] (или нажмите [red]Enter[/] для завершения):")
            .AllowEmpty());
        if (string.IsNullOrWhiteSpace(name))
            yield break;

        var salary = AnsiConsole.Ask<uint>($"Введите [green]зарплату[/] для сотрудника [yellow]{name}[/]:");

        yield return new Employee { Name = name, Salary = salary };
    }

    public uint GetSalary()
    {
        var salary = AnsiConsole.Ask<uint>($"Введите [green]зарплату[/] для поиска сотрудника:");
        return salary;
    }
}
