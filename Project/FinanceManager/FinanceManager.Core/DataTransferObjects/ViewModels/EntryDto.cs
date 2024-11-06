using FinanceManager.Core.Models;

namespace FinanceManager.Core.DataTransferObjects.ViewModels;
public class EntryDto
{
    public long Id { get; init; }

    public long UserId { get; init; }
    
    public long AccoutId { get; init; }

    public long? CategoryId { get; init; }

    public DateTime? Date { get; init; }

    public string? Description { get; init; }

    public decimal Amount { get; init; }

}

public static class EntryMappings
{
    public static EntryDto ToDto(this Entry entry)
    {
        return new EntryDto
        {
            Id = entry.Id,
            UserId = entry.UserId,
            AccoutId = entry.AccountId,
            CategoryId = entry.CategoryId,
            Date = entry.Date,
            Amount = entry.Amount,
            Description = entry.Description,
        };
    }
}