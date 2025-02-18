using HomeWork16.Application.DTOs.Abstractions;

namespace HomeWork16.Application.DTOs.ViewModels;
public sealed class OrderCustomerDto : BaseDto
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Age { get; set; }
}