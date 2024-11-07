using FinanceManager.Core.Models;

namespace FinanceManager.Core.DataTransferObjects.ViewModels;
public class TransferDto
{
    public long Id { get; init; }

    public long UserId { get; init; }

    public long FromAccountId { get; set; }

    public long ToAccountId { get; set; }

    public DateTime Date { get; set; }

    public decimal FromAmount { get; set; }

    public decimal ToAmount { get; set; }

    public string? Description { get; set; }
}

public static class TransferMappings
{
    public static TransferDto ToDto(this Transfer transfer)
    {
        return new TransferDto
        {
            Id = transfer.Id,
            UserId = transfer.UserId,
            FromAccountId = transfer.FromAccountId,
            ToAccountId = transfer.ToAccountId,
            Date = transfer.Date,
            FromAmount = transfer.FromAmount,
            ToAmount = transfer.ToAmount,
            Description = transfer.Description
        };
    }
}
