using HomeWork16.Domain.Models;

namespace HomeWork16.Application.DTOs.Commands.Create;
public sealed class CreateProductDto
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int StockQuantity { get; set; }

    public decimal Price { get; set; }

    public Product ToModel() =>
        new Product
        {
            Name = Name,
            Description = Description,
            StockQuantity = StockQuantity,
            Price = Price
        };
}