using HomeWork16.Domain.Models;

namespace HomeWork16.Application.DTOs.Commands.Create;
public sealed class CreateOrderDto
{
    public int CustomerId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public Order ToModel() =>
        new Order
        {
            CustomerId = CustomerId,
            ProductId = ProductId,
            Quantity = Quantity
        };
}