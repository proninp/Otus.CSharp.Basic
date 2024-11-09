namespace FinanceManager.Core.Models;
public class Category
{
    public long Id { get; init; }

    public long UserId { get; init; }

    public string? Title { get; set; }

    public long? ParentCategoryId { get; set; }

    public Category? ParentCategory { get; set; }

    public ICollection<Category>? SubCategories { get; }

    public Category(long userId, string? title = null, long? parentCategoryId = null)
    {
        UserId = userId;
        Title = title;
        ParentCategoryId = parentCategoryId;
    }
}
