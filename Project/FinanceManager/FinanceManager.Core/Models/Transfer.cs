using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceManager.Core.Models;
public class Transfer
{
    public long Id { get; set; }

    public DateTime Date { get; set; } = DateTime.UtcNow;

    public int FromAccountId { get; set; }

    public int ToAccountId { get; set; }

    public long UserId { get; set; }

    public decimal FromAmount { get; set; }

    public decimal ToAmount { get; set; }

    public string Description { get; set; } = string.Empty;

    public Account FromAccount { get; set; }

    public Account ToAccount { get; set; }

    public User User { get; set; }
}
