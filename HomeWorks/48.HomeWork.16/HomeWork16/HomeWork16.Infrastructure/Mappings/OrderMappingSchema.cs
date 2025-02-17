using HomeWork16.Domain.Models;
using LinqToDB.Mapping;

namespace HomeWork16.Infrastructure.Configurations;
public sealed class OrderMappingSchema : MappingSchema
{
    public OrderMappingSchema()
    {
        var builder = new FluentMappingBuilder(this);

        builder.Entity<Order>()
            .HasTableName("orders")

            .Property(o => o.Id)
                .IsPrimaryKey()
                .IsIdentity()
                .HasColumnName("id")

            .Property(o => o.CustomerId)
                .HasColumnName("customerid")
                .IsNotNull()

            .Property(o => o.ProductId)
                .HasColumnName("productid")
                .IsNotNull()

            .Property(o => o.Quantity)
                .HasColumnName("quantity")
                .IsNotNull()

            .Association(o => o.Customer, o => o.CustomerId, c => c.Id)
            .Association(o => o.Product, o => o.ProductId, p => p.Id)

            .Build();
    }
}