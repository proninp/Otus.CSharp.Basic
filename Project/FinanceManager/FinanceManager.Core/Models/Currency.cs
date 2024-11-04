using FinanceManager.Core.DataTransferObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceManager.Core.Models;
public class Currency
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public required string Title { get; set; }

    public required string CurrencyCode { get; set; }

    public required string CurrencySign { get; set; } = string.Empty;
}