using FinanceManager.Core.DataTransferObjects.Abstractions;
using FinanceManager.Core.Models.Entries;

namespace FinanceManager.Core.DataTransferObjects;
public sealed class IncomeDto : EntryDto
{

}

public static class IncomeMappings
{
    public static IncomeDto ToDto(this Income income)
    {
        return new IncomeDto
        {
            Id = income.Id,
            Amount = income.Amount,
            Description = income.Description,
            Date = income.Date.ToLocalTime(),
            AccoutId = income.AccountId,
            CategoryId = income.CategoryId,
            UserId = income.UserId,
        };
    }
}