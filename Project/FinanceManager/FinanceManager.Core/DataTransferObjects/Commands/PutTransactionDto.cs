using FinanceManager.Core.Models;

namespace FinanceManager.Core.DataTransferObjects.Commands;
public class PutTransactionDto
{
    public long Id { get; init; }

    public long UserId { get; init; }

    public long AccountId { get; set; }

    public long? CategoryId { get; set; }

    public DateTime Date { get; set; }

    public decimal Amount { get; set; }

    public string? Description { get; set; }

    public Transaction ToModel()
    {
        return new Transaction(UserId, AccountId, CategoryId, Date, Amount, Description);
    }
}
