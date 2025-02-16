namespace HomeWork16.Domain.Options;
public sealed class AppSettings
{
    public required string DbConnectionString { get; set; }

    public required string ProviderName { get; set; }
}