using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Core.Models;
public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public bool Expense { get; set; } = true;

    public bool Income { get; set; }

    public long ParentCategoryId { get; set; }

    public Category? ParentCategory { get; set; }

    [Required]
    public required long UserId { get; set; }
    
    [Required]
    public required User User { get; set; }
}
