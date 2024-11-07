namespace FinanceManager.Core.Models;
public sealed class Account
{
    public long Id { get; }

    public short AccountTypeId { get; }

    public short CurrencyId { get; }

    public string? Title { get; set; }

    public decimal Balance { get; set; }

    public bool IsDefault { get; set; }

    public bool IsArchived { get; set; }

    public AccountType AccountType { get; }

    public Currency Currency { get; }

    public Account(short accountTypeId, short currencyId, string? title = null, decimal balance = 0, bool isDefault = false, bool isArchived = false)
    {
        AccountTypeId = accountTypeId;
        CurrencyId = currencyId;
        Title = title;
        Balance = balance;
        IsDefault = isDefault;
        IsArchived = isArchived;
    }
}
