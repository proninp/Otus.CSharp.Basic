using FinanceManager.Core.Models;

namespace FinanceManager.Core.DataTransferObjects.ViewModels;
public class TransactionDto
{
    public long Id { get; init; }

    public long UserId { get; init; }
    
    public long AccoutId { get; init; }

    public long? CategoryId { get; init; }

    public DateTime Date { get; init; }

    public decimal Amount { get; init; }

    public string? Description { get; init; }
}

public static class TransactionMappings
{
    public static TransactionDto ToDto(this Transaction entry)
    {
        return new TransactionDto
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