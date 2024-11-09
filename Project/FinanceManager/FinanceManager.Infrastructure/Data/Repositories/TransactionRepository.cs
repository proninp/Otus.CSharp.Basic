using FinanceManager.Core.Models;
using FinanceManager.Core.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Infrastructure.Data.Repositories;
public sealed class TransactionRepository(AppDbContext context) : ITransactionRepository
{
    public async Task<Transaction?> GetById(long id)
    {
        return await context
            .Transactions
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<TResult[]> GetAll<TResult>(Func<Transaction, TResult> selector)
    {
        return await context
            .Transactions
            .AsNoTracking()
            .OrderBy(t => t.Date)
            .Select(x => selector(x))
            .ToArrayAsync();
    }

    public void Add(Transaction transaction)
    {
        context.Add(transaction);
    }

    public void Update(Transaction transaction)
    {
        context.Transactions.Update(transaction);
    }

    public void Delete(Transaction transaction)
    {
        context.Transactions.Remove(transaction);
    }

    public async Task Delete(long id)
    {
        var transaction = await context.Transactions.FirstOrDefaultAsync(t => t.Id == id);
        if (transaction is not null)
        {
            Delete(transaction);
        }
    }
}
