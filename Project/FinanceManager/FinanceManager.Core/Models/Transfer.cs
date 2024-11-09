namespace FinanceManager.Core.Models;
public class Transfer
{
    public long Id { get; init; }

    public long UserId { get; init; }

    public long FromAccountId { get; set; }

    public long ToAccountId { get; set; }

    public DateTime Date { get; set; }

    public decimal FromAmount { get; set; }

    public decimal ToAmount { get; set; }

    public string? Description { get; set; }

    public User User { get; set; }

    public Account FromAccount { get; set; }

    public Account ToAccount { get; set; }

    protected Transfer() { }

    public Transfer(long userId, long fromAccountId, long toAccountId, DateTime? date, decimal fromAmount = 0, decimal toAmount = 0, string? description = null)
    {
        UserId = userId;
        FromAccountId = fromAccountId;
        ToAccountId = toAccountId;
        Date = date ?? DateTime.UtcNow;
        FromAmount = fromAmount;
        ToAmount = toAmount;
        Description = description;
    }
}
