using HomeWork16.Domain;
using LinqToDB.Mapping;

namespace HomeWork16.Infrastructure.Configurations;
public sealed class ProductMappingSchema : MappingSchema
{
    public ProductMappingSchema()
    {
        var builder = new FluentMappingBuilder(this);

        builder.Entity<Product>()
            .HasTableName("products")

            .Property(p => p.Id)
                .IsPrimaryKey()
                .IsIdentity()
                .HasColumnName("id")

            .Property(p => p.Name)
                .HasColumnName("name")
                .HasLength(100)
                .IsNotNull()

            .Property(p => p.Description)
                .HasColumnName("description")
                .IsNullable()

            .Property(p => p.StockQuantity)
                .HasColumnName("stockquantity")
                .IsNotNull()

            .Property(p => p.Price)
                .HasColumnName("price")
                .IsNotNull()

            .Build();
    }
}
