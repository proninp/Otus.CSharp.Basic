using FinanceManager.Core.Models;
using FinanceManager.Core.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Infrastructure.Data.Repositories;
public sealed class IncomeRepository(AppDbContext context) : IIncomeRepository
{
    public async Task<Income?> GetById(long id)
    {
        return await context
            .Incomes
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<TResult[]> GetAll<TResult>(Func<Income, TResult> selector)
    {
        return await context
            .Incomes
            .AsNoTracking()
            .OrderBy(e => e.Date)
            .Select(x => selector(x))
            .ToArrayAsync();
    }

    public void Add(Income income)
    {
        context.Add(income);
    }

    public void Update(Income income)
    {
        context.Update(income);
    }

    public void Delete(Income income)
    {
        context.Remove(income);
    }
}
