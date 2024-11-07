using FinanceManager.Core.DataTransferObjects.ViewModels;

namespace FinanceManager.Core.Services;
public sealed class FinanceService(TransactionManager transactionManager)
{
    public async Task<FinanceViewModel> GetFinanceData()
    {
        var transactions = await transactionManager.GetTransactions();
        // TODO accounts
        // TODO categories
        
        return new FinanceViewModel
        {
            Transactions = transactions,
        };
    }
}
