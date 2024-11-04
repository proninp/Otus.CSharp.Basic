using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Core.Models;
public class Account
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public decimal Balance { get; set; }

    public bool IsDefault { get; set; }

    public bool IsArchived { get; set; }

    [Required]
    public required short AccountTypeId { get; set; }
    
    [Required]
    public required AccountType AccountType { get; set; }

    [Required]
    public required short CurrencyId { get; set; }

    [Required]
    public required Currency Currency { get; set; }

    [Required]
    public required long UserId { get; set; }

    [Required]
    public required User User { get; set; }
}
