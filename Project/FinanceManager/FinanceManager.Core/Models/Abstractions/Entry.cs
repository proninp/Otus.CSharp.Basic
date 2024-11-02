using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Core.Models.Abstractions;

public abstract class Entry
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    
    public decimal Amount { get; set; }

    public DateTime Date { get; set; } = DateTime.UtcNow;

    public string Description { get; set; } = string.Empty;

    public int AccountId { get; set; }

    public int CategoryId { get; set; }

    public Account Account { get; set; }

    public Category Category { get; set; }
}
