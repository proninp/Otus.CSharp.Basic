namespace FinanceManager.Core.Models;
public sealed class Account
{
    public long Id { get; }

    public string? Title { get; set; }

    public decimal Balance { get; set; }

    public bool IsDefault { get; set; }

    public bool IsArchived { get; set; }

    public short AccountTypeId { get; }

    public AccountType AccountType { get; }

    public short CurrencyId { get; }

    public Currency Currency { get; }

    protected Account() { }

    public Account(short accountTypeId, short currencyId, string? title = null)
    {
        AccountTypeId = accountTypeId;
        CurrencyId = currencyId;
        Title = title;
    }
}
