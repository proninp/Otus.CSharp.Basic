using FinanceManager.Core.Models;

namespace FinanceManager.Core.DataTransferObjects.ViewModels;
public class AccountDto
{
    public long Id { get; init; }

    public long UserId { get; init; }

    public int AccountTypeId { get; init; }

    public int CurrencyId { get; init; }

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
            UserId = account.UserId,
            Title = account.Title,
            AccountTypeId = account.AccountTypeId,
            CurrencyId = account.CurrencyId,
            Balance = account.Balance,
            IsDefault = account.IsDefault,
            IsArchived = account.IsArchived,
        };
    }
}
