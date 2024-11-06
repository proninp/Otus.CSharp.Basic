using FinanceManager.Core.Models;
using FinanceManager.Core.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Infrastructure.Data.Repositories;
public sealed class EntryRepository(AppDbContext context) : IEntryRepository
{
    public async Task<Entry?> GetById(long id)
    {
        return await context
            .Entry
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<TResult[]> GetAll<TResult>(Func<Entry, TResult> selector)
    {
        return await context
            .Entry
            .AsNoTracking()
            .OrderBy(e => e.Date)
            .Select(x => selector(x))
            .ToArrayAsync();
    }

    public void Add(Entry expense)
    {
        context.Add(expense);
    }

    public void Delete(Entry entry)
    {
        context.Entry.Remove(entry);
    }

    public void Update(Entry entry)
    {
        context.Entry.Update(entry);
    }
}
