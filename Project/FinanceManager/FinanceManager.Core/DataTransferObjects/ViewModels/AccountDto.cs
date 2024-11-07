using FinanceManager.Core.Models;

namespace FinanceManager.Core.DataTransferObjects.ViewModels;
public class AccountDto
{
    public long Id { get; init; }

    public short AccountTypeId { get; init; }

    public short CurrencyId { get; init; }

    public string? Title { get; set; }

    public decimal Balance { get; set; }

    public bool IsDefault { get; set; }

    public bool IsArchived { get; set; }
}

public static class AccountMappings
{
    public static AccountDto ToDto(this Account account)
    {
        return new AccountDto
        {
            Id = account.Id,
            Title = account.Title,
            AccountTypeId = account.AccountTypeId,
            CurrencyId = account.CurrencyId,
            Balance = account.Balance,
            IsDefault = account.IsDefault,
            IsArchived = account.IsArchived,
        };
    }
}
