namespace FinanceManager.Core.Models.Abstractions;

public abstract class Entry
{
    public long Id { get; set; }
    
    public decimal Amount { get; set; }

    public DateTime Date { get; set; } = DateTime.UtcNow;

    public string Description { get; set; } = string.Empty;
}
