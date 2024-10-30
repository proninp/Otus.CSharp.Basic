using FinanceManager.Core.Models;

namespace FinanceManager.Core.Services;
public sealed class FinanceService(ExpenseManager expenseManager, IncomeManager incomeManager)
{
    public async Task<FinanceViewModel> GetFinanceData()
    {
        var expenses = await expenseManager.GetExpenses();
        var incomes = await incomeManager.GetIncomes();
        
        return new FinanceViewModel
        {
            Expenses = expenses,
            Incomes = incomes,
        };
    }
}
