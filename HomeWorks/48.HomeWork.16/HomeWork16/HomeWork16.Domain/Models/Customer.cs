using HomeWork16.Domain.Models.Abstractions;

namespace HomeWork16.Domain.Models;


public sealed class Customer : BaseModel
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Age { get; set; }
}