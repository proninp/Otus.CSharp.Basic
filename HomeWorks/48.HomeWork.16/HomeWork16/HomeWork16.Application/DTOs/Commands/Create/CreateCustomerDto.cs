using HomeWork16.Domain.Models;

namespace HomeWork16.Application.DTOs.Commands.Create;
public sealed class CreateCustomerDto
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Age { get; set; }

    public Customer ToModel() =>
        new Customer
        {
            FirstName = FirstName,
            LastName = LastName,
            Age = Age
        };
}