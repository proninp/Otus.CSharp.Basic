namespace HomeWork08.Models;
public class Employee : IComparable<Employee>
{
    public required string Name { get; init; }

    public required int Salary { get; init; }

    public int CompareTo(Employee? other)
    {
        return CompareTo(other?.Salary ?? -1);
    }

    public int CompareTo(int salary)
    {
        return Comparer<int>.Default.Compare(Salary, salary);
    }

    public override string? ToString()
    {
        return $"{Name} - {Salary}";
    }
}
