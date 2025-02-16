using HomeWork16.Domain.Models.Abstractions;

namespace HomeWork16.Domain;

public sealed class Product : BaseModel
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int StockQuantity { get; set; }

    public decimal Price { get; set; }
}
