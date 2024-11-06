using FinanceManager.Core.Models;

namespace FinanceManager.Core.DataTransferObjects.ViewModels;
public class CategoryDto
{
    public long Id { get; set; }

    public long? ParentCategoryId { get; set; }

    public string? Title { get; set; }
}

public static class CategoryMappings
{
    public static CategoryDto ToDto(this Category category)
    {
        return new CategoryDto
        {
            Id = category.Id,
            Title = category.Title,
            ParentCategoryId = category.ParentCategoryId,
        };
    }
}
