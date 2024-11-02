using FinanceManager.Core.Models;

namespace FinanceManager.Core.DataTransferObjects;
public class AccountDto
{
    public int Id { get; set; }

    public string Title { get; set; }

    public AccountType Type { get; set; }

    public int CurrencyId { get; set; }

    public double CurrentBalance { get; set; }

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
            Type = account.Type,
            CurrencyId = account.CurrencyId,
            CurrentBalance = account.CurrentBalance,
            IsDefault = account.IsDefault,
            IsArchived = account.IsArchived,
        };
    }
}
