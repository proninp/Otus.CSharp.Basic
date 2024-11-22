using HomeWork08.Abstractions;
using HomeWork08.Models;

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
        
        foreach(var employee in _employeeManager.GetEmployee())
            _tree.Add(employee);

        _printer.PrintTitle("Обход дерева:");
        _tree.SymmetricTraverse();

        _printer.PrintTitle("Поиск элемента:");
        var salaryToFind = _employeeManager.GetSalary();
        var seekEmployee = _tree.Get(e => e.CompareTo(salaryToFind));
        _printer.ShowInfo(seekEmployee);
    }
}
