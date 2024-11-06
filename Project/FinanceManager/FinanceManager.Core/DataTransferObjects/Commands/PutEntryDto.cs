using FinanceManager.Core.Models;

namespace FinanceManager.Core.DataTransferObjects.Commands;
public class PutEntryDto
{
    public long Id { get; init; }

    public long UserId { get; }

    public long AccountId { get; set; }

    public DateTime? Date { get; set; }

    public long? CategoryId { get; set; }

    public decimal Amount { get; set; }

    public string? Description { get; set; }

    public Entry ToModel()
    {
        return new Entry(UserId, AccountId, CategoryId, Date, Amount, Description);
    }
}
