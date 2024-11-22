using System.Collections;
using HomeWork08.Models;

namespace HomeWork08;
public interface IEmployeeManager
{
    public IEnumerable<Employee> GetEmployee();

    public int GetSalary();
}