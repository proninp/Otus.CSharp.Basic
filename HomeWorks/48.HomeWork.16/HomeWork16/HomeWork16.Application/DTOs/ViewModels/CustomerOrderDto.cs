using HomeWork16.Application.DTOs.Abstractions;

namespace HomeWork16.Application.DTOs.ViewModels;
public sealed class CustomerOrderDto : BaseDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}
