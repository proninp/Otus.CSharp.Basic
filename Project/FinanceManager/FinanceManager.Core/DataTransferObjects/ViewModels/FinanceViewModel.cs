using FinanceManager.Core.Models;

namespace FinanceManager.Core.DataTransferObjects.ViewModels;
public sealed class FinanceViewModel
{
    public EntryDto[] Entries { get; set; }

    public AccountDto[] Accounts { get; set; }

    public CategoryDto[] Categories { get; set; }
}
