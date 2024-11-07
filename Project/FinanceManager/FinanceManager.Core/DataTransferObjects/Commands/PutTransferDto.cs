using FinanceManager.Core.Models;

namespace FinanceManager.Core.DataTransferObjects.Commands;
public class PutTransferDto
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
