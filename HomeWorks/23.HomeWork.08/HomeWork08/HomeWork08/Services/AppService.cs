using HomeWork08.Abstractions;
using HomeWork08.Models;

namespace HomeWork08.Services;
public class AppService
{
    private readonly IEmployeeManager _employeeManager;
    private readonly IEntityPrinter<Employee> _printer;
    private readonly BinaryTree<Employee> _tree;
    private readonly MenuService _menu;

    public AppService(IEmployeeManager employeeManager,
        IEntityPrinter<Employee> printerProvider,
        BinaryTree<Employee> tree,
        MenuService menu)
    {
        _employeeManager = employeeManager;
        _printer = printerProvider;
        _tree = tree;
        _menu = menu;
    }

    public void Run()
    {
        var choices = Enum.GetValues<WorkMode>()
                .ToDictionary(workmode => workmode, workmode => workmode.GetDescription());

        _menu.Restart += ManageEmployees;
        _menu.FindEmployee += FindEmployee;

        while (true)
        {
            if (!_menu.SelectMenu(choices))
                return;
        }
    }

    private void ManageEmployees(object? sender, EventArgs e)
    {
        _tree.Clear();

        foreach (var employee in _employeeManager.GetEmployee())
            _tree.Add(employee);

        _printer.PrintTitle("Обход дерева:");
        _tree.InOrderTraversal();
    }

    private void FindEmployee(object? sender, EventArgs e)
    {
        _printer.PrintTitle("Поиск элемента:");
        var salaryToFind = _employeeManager.GetSalary();
        var seekEmployee = _tree.Find(employee => employee.CompareTo(salaryToFind));
        _printer.ShowInfo(seekEmployee);
    }
}
