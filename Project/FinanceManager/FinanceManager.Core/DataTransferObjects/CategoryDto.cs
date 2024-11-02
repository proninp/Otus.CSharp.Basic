using FinanceManager.Core.Models;

namespace FinanceManager.Core.DataTransferObjects;
public class CategoryDto
{
    public long Id { get; set; }

    public string Title { get; set; }

    public bool Expense { get; set; }

    public bool Income { get; set; }

    public long ParentCategoryId { get; set; }

}

public static class CategoryMappings
{
    public static CategoryDto ToDto(this Category category)
    {
        return new CategoryDto
        {
            Id = category.Id,
            Title = category.Title,
            Expense = category.Expense,
            Income = category.Income,
            ParentCategoryId = category.ParentCategoryId,
        };
    }
}
