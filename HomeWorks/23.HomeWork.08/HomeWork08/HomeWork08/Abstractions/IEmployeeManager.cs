using HomeWork08.Models;

namespace HomeWork08.Abstractions;
public interface IEmployeeManager
{
    IEnumerable<Employee> GetEmployee();

    uint GetSalary();
}