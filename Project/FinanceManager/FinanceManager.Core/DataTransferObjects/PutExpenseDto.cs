using FinanceManager.Core.DataTransferObjects.Abstractions;
using FinanceManager.Core.Models.Entries;

namespace FinanceManager.Core.DataTransferObjects;
public sealed class PutExpenseDto : PutEntryDto
{
    public override Expense ToModel()
    {
        return new Expense
        {
            Id = Id,
            Amount = Amount,
            Description = Description,
            AccountId = AccountId,
            CategoryId = CategoryId,
            UserId = UserId,
        };
    }
}
