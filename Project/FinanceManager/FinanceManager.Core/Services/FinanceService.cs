using FinanceManager.Core.DataTransferObjects.ViewModels;

namespace FinanceManager.Core.Services;
public sealed class FinanceService(EntryManager entryManager)
{
    public async Task<FinanceViewModel> GetFinanceData()
    {
        var entries = await entryManager.GetEntry();
        // TODO accounts
        // TODO categories
        
        return new FinanceViewModel
        {
            Entries = entries,
        };
    }
}
