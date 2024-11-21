namespace HomeWork08.Models;
public class Employee : IComparable<Employee>
{
    public required string Name { get; init; }

    public required int Salary { get; init; }

    public int CompareTo(Employee? other)
    {
        if (other is null || other.Salary < Salary) return 1;
        if (other.Salary > Salary) return -1;
        return 0;
    }
}
