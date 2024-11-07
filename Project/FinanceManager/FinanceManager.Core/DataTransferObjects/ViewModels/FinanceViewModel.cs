using FinanceManager.Core.Models;

namespace FinanceManager.Core.DataTransferObjects.ViewModels;
public sealed class FinanceViewModel
{
    public TransactionDto[] Transactions { get; init; }

    public AccountDto[] Accounts { get; init; }

    public CategoryDto[] Categories { get; init; }
}
