using HomeWork16.Application.DTOs.Abstractions;
using HomeWork16.Domain.Models;

namespace HomeWork16.Application.DTOs.ViewModels;
public sealed class OrderDto : BaseDto
{
    public int Quantity { get; set; }

    public OrderCustomerDto Customer { get; set; } = null!;

    public ProductDto Product { get; set; } = null!;
}

public static class OrderMappings
{
    public static OrderDto ToDto(this Order order)
    {
        return new OrderDto
        {
            Id = order.Id,
            Quantity = order.Quantity,
            Customer = new OrderCustomerDto
            {
                Id = order.Customer.Id,
                FirstName = order.Customer.FirstName,
                LastName = order.Customer.LastName,
                Age = order.Customer.Age,
            },
            Product = new ProductDto
            {
                Id = order.Product.Id,
                Name = order.Product.Name,
                Description = order.Product.Description,
                StockQuantity = order.Product.StockQuantity,
                Price = order.Product.Price
            }
        };
    }
}