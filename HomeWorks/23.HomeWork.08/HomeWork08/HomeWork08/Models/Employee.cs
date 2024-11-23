namespace HomeWork08.Models;
public sealed class Employee : IComparable<Employee>
{
    public required string Name { get; init; }

    public required uint Salary { get; init; }

    public int CompareTo(Employee? other)
    {
        return CompareTo(other?.Salary ?? 0);
    }

    public int CompareTo(uint salary)
    {
        return Comparer<uint>.Default.Compare(Salary, salary);
    }

    public override string? ToString()
    {
        return $"{Name} - {Salary}";
    }
}
