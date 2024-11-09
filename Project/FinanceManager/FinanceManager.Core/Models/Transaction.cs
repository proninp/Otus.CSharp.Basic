namespace FinanceManager.Core.Models;

public sealed class Transaction
{
    public long Id { get; init; }

    public long UserId { get; init; }

    public long AccountId { get; set; }

    public DateTime Date { get; set; }

    public long? CategoryId { get; set; }

    public decimal Amount { get; set; }

    public string? Description { get; set; }

    public User User { get; }

    public Account Account { get; set; }

    public Category? Category { get; set; }

    protected Transaction() { }

    public Transaction(long userId, long accountId, long? categoryId = null, DateTime? date = null, decimal amount = 0, string? description = null)
    {
        UserId = userId;
        AccountId = accountId;
        CategoryId = categoryId;
        Date = date ?? DateTime.UtcNow;
        Amount = amount;
        Description = description;
    }
}
