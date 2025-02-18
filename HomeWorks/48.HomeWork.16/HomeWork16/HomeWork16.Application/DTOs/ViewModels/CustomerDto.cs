using HomeWork16.Application.DTOs.Abstractions;
using HomeWork16.Domain.Models;

namespace HomeWork16.Application.DTOs.ViewModels;
public sealed class CustomerDto : BaseDto
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Age { get; set; }
}

public static class CustomerMappings
{
    public static CustomerDto ToDto(this Customer customer)
    {
        return new CustomerDto
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Age = customer.Age,
        };
    }
}
