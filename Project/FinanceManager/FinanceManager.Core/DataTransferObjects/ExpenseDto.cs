using FinanceManager.Core.DataTransferObjects.Abstractions;
using FinanceManager.Core.Models;

namespace FinanceManager.Core.DataTransferObjects;
public sealed class ExpenseDto : EntryDto
{

}

public static class ExpenseMappings
{
    public static ExpenseDto ToDto(this Expense expense)
    {
        return new ExpenseDto 
        { 
            Id = expense.Id,
            Amount = expense.Amount,
            Description = expense.Description,
            Date = expense.Date.ToLocalTime(), 
            AccoutId = expense.AccountId,
            CategoryId = expense.CategoryId,
        };
    }
}