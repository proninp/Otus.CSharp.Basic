namespace FinanceManager.Core.Models;
public class Account
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public AccountType Type { get; set; }

    public int CurrencyId { get; set; }

    public double CurrentBalance { get; set; }

    public bool IsDefault { get; set; }

    public bool IsArchived { get; set; }

    public Currency Currency { get; set; }
}
