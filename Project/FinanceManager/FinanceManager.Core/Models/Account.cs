using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Core.Models;
public sealed class Account
{
    public long Id { get; init; }

    public long UserId { get; init; }
    
    public int AccountTypeId { get; init; }

    public int CurrencyId { get; init; }

    public string? Title { get; set; }

    public decimal Balance { get; set; }

    public bool IsDefault { get; set; }

    public bool IsArchived { get; set; }

    public AccountType AccountType { get; }

    public Currency Currency { get; }

    public Account(long userId, int accountTypeId, int currencyId, string? title = null, decimal balance = 0, bool isDefault = false, bool isArchived = false)
    {
        UserId = userId;
        AccountTypeId = accountTypeId;
        CurrencyId = currencyId;
        Title = title;
        Balance = balance;
        IsDefault = isDefault;
        IsArchived = isArchived;
    }
}
