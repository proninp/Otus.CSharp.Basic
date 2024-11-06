using FinanceManager.Core.Options;
using FinanceManager.Core.Services;
using FinanceManager.Core.Services.Abstractions;
using FinanceManager.Infrastructure.Data;
using FinanceManager.Infrastructure.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DbOptions>(configuration.GetSection(nameof(DbOptions)));
        services.AddDbContext<IUnitOfWork, AppDbContext>();
        services.AddScoped<EntryManager>();
        services.AddScoped<IEntryRepository, EntryRepository>();
        services.AddScoped<FinanceService>();
        services.AddHostedService<AppInitializer>();

        return services;
    }
}
