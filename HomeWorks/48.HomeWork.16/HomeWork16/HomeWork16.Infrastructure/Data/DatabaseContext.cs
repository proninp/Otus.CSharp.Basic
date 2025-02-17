using HomeWork16.Domain;
using HomeWork16.Domain.Models;
using HomeWork16.Domain.Options;
using HomeWork16.Infrastructure.Configurations;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;
using LinqToDB.Metadata;
using Microsoft.Extensions.Options;

namespace HomeWork16.Infrastructure.Data;
public class DatabaseContext : DataConnection
{
    public DatabaseContext(IOptionsSnapshot<AppSettings> options, IMetadataReader metadataReader)
        : base(options.Value.ProviderName, options.Value.DbConnectionString, GetCombinedMappingSchema())
    {
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