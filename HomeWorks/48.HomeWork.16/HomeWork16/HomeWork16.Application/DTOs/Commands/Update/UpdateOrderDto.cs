using HomeWork16.Application.DTOs.Abstractions;
using HomeWork16.Domain.Models;

namespace HomeWork16.Application.DTOs.Commands.Update;
public partial class UpdateOrderDto : BaseDto
{
    public int CustomerId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public Order ToModel() =>
        new Order
        {
            Id = Id,
            CustomerId = CustomerId,
            ProductId = ProductId,
            Quantity = Quantity
        };
}
