using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Core.Models;
public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public bool Expense { get; set; } = true;

    public bool Income { get; set; }

    public int ParentCategoryId { get; set; }

    public Category? ParentCategory { get; set; }
}
