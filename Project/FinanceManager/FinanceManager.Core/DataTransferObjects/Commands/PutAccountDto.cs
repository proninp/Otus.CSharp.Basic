using FinanceManager.Core.Models;

namespace FinanceManager.Core.DataTransferObjects.Commands;
public class PutAccountDto
{
    public long Id { get; init; }

    public long UserId { get; init; }
    
    public int AccountTypeId { get; init; }

    public int CurrencyId { get; init; }

    public string? Title { get; set; }

    public decimal Balance { get; set; }

    public bool IsDefault { get; set; }

    public bool IsArchived { get; set; }
}
