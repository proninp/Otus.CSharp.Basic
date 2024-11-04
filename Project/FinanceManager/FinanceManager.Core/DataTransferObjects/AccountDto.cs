using FinanceManager.Core.Models;

namespace FinanceManager.Core.DataTransferObjects;
public class AccountDto
{
    public long Id { get; set; }

    public string Title { get; set; }

    public short AccountTypeId { get; set; }

    public short CurrencyId { get; set; }

    public long UserId { get; set; }

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
            UserId = account.UserId,
            Balance = account.Balance,
            IsDefault = account.IsDefault,
            IsArchived = account.IsArchived,
        };
    }
}
