namespace FinanceManager.Core.Models;
public class User
{
    public long Id { get; }

    public long TelegramId { get; }

    public string? Name { get; set; }

    public ICollection<Account> Accounts { get; } = Array.Empty<Account>();

    public ICollection<Category> Categories { get; } = Array.Empty<Category>();

    public ICollection<Transaction> Expenses { get; } = Array.Empty<Transaction>();

    protected User() { }

    public User(long telegramId, string? name = null)
    {
        TelegramId = telegramId;
        Name = name;
    }

    public void AddAccount(Account account)
    {
        Accounts.Add(account);
    }
}
