using FinanceManager.Core.Models.Abstractions;

namespace FinanceManager.Core.DataTransferObjects.Abstractions;
public abstract class PutEntryDto
{
    public long Id { get; init; }

    public required decimal Amount { get; set; }

    public string Description { get; set; } = string.Empty;

    public abstract Entry ToModel();
}
