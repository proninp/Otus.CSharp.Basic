using HomeWork08.Abstractions;
using HomeWork08.Models;
using Spectre.Console;

namespace HomeWork08;
public class AppService
{
    private readonly IEmployeeManager _employeeManager;
    private readonly IEntityPrinter<Employee> _printer;
    private readonly BinaryTree<Employee> _tree;

    public AppService(IEmployeeManager employeeManager, IEntityPrinter<Employee> printerProvider, BinaryTree<Employee> tree)
    {
        _employeeManager = employeeManager;
        _printer = printerProvider;
        _tree = tree;
    }

    public void Run()
    {

        while (true)
        {
            var action = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green]Выберите режим работы:[/]")
                    .AddChoices("Начать заново", "Продолжить поиск сотрудника по зарплате", "Выход"));

            switch (action)
            {
                case "Начать заново":
                    AnsiConsole.MarkupLine("[blue]Вы выбрали начать заново.[/]");
                    ManageEmployees();
                    break;

                case "Продолжить поиск сотрудника по зарплате":
                    AnsiConsole.MarkupLine("[yellow]Вы выбрали продолжить поиск.[/]");
                    FindEmployee();
                    break;

                case "Выход":
                    AnsiConsole.MarkupLine("[red]Выход из программы.[/]");
                    return;
            }
        }
    }

    private void ManageEmployees()
    {
        _tree.Clear();

        foreach (var employee in _employeeManager.GetEmployee())
            _tree.Add(employee);

        _printer.PrintTitle("Обход дерева:");
        _tree.InOrderTraversal();
    }

    private void FindEmployee()
    {
        _printer.PrintTitle("Поиск элемента:");
        var salaryToFind = _employeeManager.GetSalary();
        var seekEmployee = _tree.Find(e => e.CompareTo(salaryToFind));
        _printer.ShowInfo(seekEmployee);
    }
}
