using FinanceManager.Core.DataTransferObjects;
using FinanceManager.Core.Models;
using FinanceManager.Core.Services.Abstractions;

namespace FinanceManager.Core.Services;
public class ExpenseManager(IExpenseRepository expenseRepository, IUnitOfWork unitOfWork)
{

    public async Task<ExpenseDto?> GetById(long id)
    {
        return (await expenseRepository.GetById(id))?.ToDto();
    }
    
    public async Task<ExpenseDto[]> GetExpenses()
    {
        return await expenseRepository.GetAll(x => x.ToDto());
    }

    public async Task PutExpense(PutExpenseDto command)
    {
        if (command.Id == 0)
        {
            expenseRepository.Add(command.ToModel());
        }
        else
        {
            var expense = await GetByIdWithNullCheck(command.Id);
            expense.Amount = command.Amount;
            expense.Description = command.Description;
        }
        await unitOfWork.Commit();
    }

    public async Task DeleteExpense(long id)
    {
        var expense = await GetByIdWithNullCheck(id);
        expenseRepository.Delete(expense);
        await unitOfWork.Commit();
    }

    private async Task<Expense> GetByIdWithNullCheck(long id)
    {
        var expense = await expenseRepository.GetById(id);
        if (expense is null)
            throw new ArgumentException($"Expense with id {id} was not found");
        return expense;
    }
}
