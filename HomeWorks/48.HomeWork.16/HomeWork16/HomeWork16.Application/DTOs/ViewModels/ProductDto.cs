using HomeWork16.Application.DTOs.Abstractions;
using HomeWork16.Domain.Models;

namespace HomeWork16.Application.DTOs.ViewModels;
public sealed class ProductDto : BaseDto
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int StockQuantity { get; set; }

    public decimal Price { get; set; }
}

public static class ProductMappings
{
    public static ProductDto ToDto(this Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            StockQuantity = product.StockQuantity,
            Price = product.Price,
        };
    }
}