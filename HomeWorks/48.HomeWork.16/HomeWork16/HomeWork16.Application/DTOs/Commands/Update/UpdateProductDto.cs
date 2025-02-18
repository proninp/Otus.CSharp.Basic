using HomeWork16.Application.DTOs.Abstractions;
using HomeWork16.Domain.Models;

namespace HomeWork16.Application.DTOs.Commands.Update;
public partial class UpdateProductDto : BaseDto
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int StockQuantity { get; set; }

    public decimal Price { get; set; }

    public Product ToModel() =>
        new Product
        {
            Id = Id,
            Name = Name,
            Description = Description,
            StockQuantity = StockQuantity,
            Price = Price
        };
}