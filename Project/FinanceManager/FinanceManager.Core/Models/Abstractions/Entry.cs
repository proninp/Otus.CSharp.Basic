using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Core.Models.Abstractions;

public abstract class Entry
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public DateTime Date { get; set; } = DateTime.UtcNow;

    public int AccountId { get; set; }

    public int CategoryId { get; set; }

    public long UserId { get; set; }

    public decimal Amount { get; set; }

    public string Description { get; set; } = string.Empty;

    public Account Account { get; set; }

    public Category Category { get; set; }

    public User User { get; set; }
}
