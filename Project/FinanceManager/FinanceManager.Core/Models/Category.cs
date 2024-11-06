namespace FinanceManager.Core.Models;
public class Category
{
    public long Id { get; set; }

    public string? Title { get; set; }

    public long? ParentCategoryId { get; set; }

    public Category? ParentCategory { get; set; }
}
