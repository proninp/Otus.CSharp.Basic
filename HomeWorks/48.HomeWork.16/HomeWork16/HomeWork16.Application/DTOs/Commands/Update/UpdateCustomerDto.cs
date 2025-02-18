using HomeWork16.Application.DTOs.Abstractions;
using HomeWork16.Domain.Models;

namespace HomeWork16.Application.DTOs.Commands.Update;
public partial class UpdateCustomerDto : BaseDto
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Age { get; set; }

    public Customer ToModel() =>
        new Customer
        {
            Id = Id,
            FirstName = FirstName,
            LastName = LastName,
            Age = Age
        };
}
