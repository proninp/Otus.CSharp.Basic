using FinanceManager.Core.Models;
using FinanceManager.Core.Options;
using FinanceManager.Core.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FinanceManager.Infrastructure.Data;
public sealed class AppDbContext : DbContext, IUnitOfWork
{
    private readonly DbOptions _options;

    public AppDbContext(IOptionsSnapshot<DbOptions> options)
    {
        _options = options.Value;
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountType> AccountTypes { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Transfer> Transfers { get; set; }
    public DbSet<User> Users { get; set; }

    public async Task<int> Commit(CancellationToken cancellationToken = default)
    {
        return await SaveChangesAsync(cancellationToken);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(_options.ConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
