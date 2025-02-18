using HomeWork16.Domain.Models;
using LinqToDB.Mapping;

namespace HomeWork16.Infrastructure.Configurations;
public sealed class CustomerMappingSchema : MappingSchema
{
    public CustomerMappingSchema()
    {
        var builder = new FluentMappingBuilder(this);

        builder.Entity<Customer>()
            .HasTableName("customers")

            .Property(c => c.Id)
                .IsPrimaryKey()
                .IsIdentity()
                .HasColumnName("id")

            .Property(c => c.FirstName)
                .HasColumnName("firstname")
                .HasLength(50)
                .IsNotNull()

            .Property(c => c.LastName)
                .HasColumnName("lastname")
                .HasLength(50)
                .IsNotNull()

            .Property(c => c.Age)
                .HasColumnName("age")
                .IsNotNull()

            .Build();
    }
}