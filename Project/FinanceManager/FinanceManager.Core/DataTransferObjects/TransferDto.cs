using FinanceManager.Core.Models.Entries;

namespace FinanceManager.Core.DataTransferObjects;
public class TransferDto
{
    public long Id { get; set; }

    public DateTime Date { get; set; }

    public int FromAccountId { get; set; }

    public int ToAccountId { get; set; }

    public long UserId { get; set; }

    public decimal FromAmount { get; set; }

    public decimal ToAmount { get; set; }

    public string Description { get; set; }
}

public static class TransferMappings
{
    public static TransferDto ToDto(this Transfer transfer)
    {
        return new TransferDto
        {
            Id = transfer.Id,
            Date = transfer.Date,
            FromAccountId = transfer.FromAccountId,
            ToAccountId = transfer.ToAccountId,
            UserId = transfer.UserId,
            FromAmount = transfer.FromAmount,
            ToAmount = transfer.ToAmount,
            Description = transfer.Description
        };
    }
}
