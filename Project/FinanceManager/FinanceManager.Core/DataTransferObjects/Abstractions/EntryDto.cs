namespace FinanceManager.Core.DataTransferObjects.Abstractions;
public abstract class EntryDto
{
    public long Id { get; init; }

    public required decimal Amount { get; set; }

    public required DateTime Date { get; set; }

    public string Description { get; set; } = string.Empty;
}
