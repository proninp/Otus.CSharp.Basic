using FinanceManager.Core.DataTransferObjects;

namespace FinanceManager.Core.Models;
public sealed class FinanceViewModel
{
    public ExpenseDto[] Expenses { get; set; }

    public IncomeDto[] Incomes { get; set; }
}
