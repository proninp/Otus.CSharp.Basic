namespace FinanceManager.Core.DataTransferObjects.Abstractions;
public abstract class EntryDto
{
    public long Id { get; set; }

    public int AccoutId { get; set; }

    public int CategoryId { get; set; }

    public long UserId { get; set; }

    public required DateTime Date { get; set; }

    public string Description { get; set; } = string.Empty;

    public required decimal Amount { get; set; }
}
