using FinanceManager.Core.Models.Abstractions;

namespace FinanceManager.Core.DataTransferObjects.Abstractions;
public abstract class PutEntryDto
{
    public long Id { get; set; }

    public int AccountId { get; set; }

    public int CategoryId { get; set; }

    public long UserId { get; set; }

    public required decimal Amount { get; set; }

    public string Description { get; set; } = string.Empty;

    public abstract Entry ToModel();
}
