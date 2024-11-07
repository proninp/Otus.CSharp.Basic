using FinanceManager.Core.Models;

namespace FinanceManager.Core.DataTransferObjects.Commands;
public class PutCategoryDto
{
    public long Id { get; init; }

    public string? Title { get; set; }

    public long? ParentCategoryId { get; set; }
}
