using FinanceManager.Core.DataTransferObjects.Commands;
using FinanceManager.Core.DataTransferObjects.ViewModels;
using FinanceManager.Core.Models;
using FinanceManager.Core.Services.Abstractions;

namespace FinanceManager.Core.Services;
public class TransactionManager(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork)
{

    public async Task<TransactionDto?> GetById(long id)
    {
        return (await transactionRepository.GetById(id))?.ToDto();
    }

    public async Task<TransactionDto[]> GetTransactions()
    {
        return await transactionRepository.GetAll(x => x.ToDto());
    }

    public async Task PutExpense(PutTransactionDto command)
    {
        if (command.Id == 0)
        {
            transactionRepository.Add(command.ToModel());
        }
        else
        {
            var transaction = await GetTransactionById(command.Id);
            transaction.AccountId = command.AccountId;
            transaction.CategoryId = command.CategoryId;
            transaction.Date = command.Date;
            transaction.Amount = command.Amount;
            transaction.Description = command.Description;
        }
        await unitOfWork.Commit();
    }

    public async Task DeleteEntry(long id)
    {
        var entry = await GetTransactionById(id);
        transactionRepository.Delete(entry);
        await unitOfWork.Commit();
    }

    private async Task<Transaction> GetTransactionById(long id)
    {
        var entry = await transactionRepository.GetById(id);
        if (entry is null)
            throw new ArgumentException($"Expense with id {id} was not found");
        return entry;
    }
}
