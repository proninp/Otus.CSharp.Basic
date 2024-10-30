using FinanceManager.Core.Models;
using FinanceManager.Core.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Infrastructure.Data.Repositories;
public sealed class ExpenseRepository(AppDbContext context) : IExpenseRepository
{
    public async Task<Expense?> GetById(long id)
    {
        return await context
            .Expenses
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<TResult[]> GetAll<TResult>(Func<Expense, TResult> selector)
    {
        return await context
            .Expenses
            .AsNoTracking()
            .OrderBy(e => e.Date)
            .Select(x => selector(x))
            .ToArrayAsync();
    }
    
    public void Add(Expense expense)
    {
        context.Add(expense);
    }

    public void Delete(Expense expense)
    {
        context.Expenses.Remove(expense);
    }

    public void Update(Expense expense)
    {
        context.Expenses.Update(expense);
    }
}
