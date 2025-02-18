using HomeWork16.Domain.Models;
using HomeWork16.Infrastructure.Configurations;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;

namespace HomeWork16.Infrastructure.Data;
public class DatabaseContext : DataConnection
{
    public DatabaseContext(DataOptions<DatabaseContext> options)
        : base(options.Options)
    {
        AddMappingSchema(GetCombinedMappingSchema());
    }

    public ITable<Customer> Customers => this.GetTable<Customer>();

    public ITable<Product> Products => this.GetTable<Product>();

    public ITable<Order> Orders => this.GetTable<Order>();

    private static MappingSchema GetCombinedMappingSchema()
    {
        var appMappingSchema = new MappingSchema(
            [
                new CustomerMappingSchema(),
                new ProductMappingSchema(),
                new OrderMappingSchema(),
            ]);
        return appMappingSchema;
    }
}