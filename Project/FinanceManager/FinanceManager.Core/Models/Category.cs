namespace FinanceManager.Core.Models;
public class Category
{
    public long Id { get; }

    public string? Title { get; set; }

    public long? ParentCategoryId { get; set; }

    public Category? ParentCategory { get; set; }

    public ICollection<Category>? SubCategories { get; set; }

    public Category(string? title = null, long? parentCategoryId = null)
    {
        Title = title;
        ParentCategoryId = parentCategoryId;
    }
}
