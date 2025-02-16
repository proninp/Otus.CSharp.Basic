using HomeWork16.Domain.Models.Abstractions;

namespace HomeWork16.Domain.Models;
public sealed class Order : BaseModel
{
    public int CustomerId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public Customer Customer { get; set; } = null!;

    public Product Product { get; set; } = null!;
}