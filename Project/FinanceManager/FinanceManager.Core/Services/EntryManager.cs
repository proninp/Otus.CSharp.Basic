using FinanceManager.Core.DataTransferObjects.Commands;
using FinanceManager.Core.DataTransferObjects.ViewModels;
using FinanceManager.Core.Models;
using FinanceManager.Core.Services.Abstractions;

namespace FinanceManager.Core.Services;
public class EntryManager(IEntryRepository entryRepository, IUnitOfWork unitOfWork)
{

    public async Task<EntryDto?> GetById(long id)
    {
        return (await entryRepository.GetById(id))?.ToDto();
    }

    public async Task<EntryDto[]> GetEntry()
    {
        return await entryRepository.GetAll(x => x.ToDto());
    }

    public async Task PutExpense(PutEntryDto command)
    {
        if (command.Id == 0)
        {
            entryRepository.Add(command.ToModel());
        }
        else
        {
            var expense = await GetByIdWithNullCheck(command.Id);
            expense.Amount = command.Amount;
            expense.Description = command.Description;
        }
        await unitOfWork.Commit();
    }

    public async Task DeleteEntry(long id)
    {
        var entry = await GetByIdWithNullCheck(id);
        entryRepository.Delete(entry);
        await unitOfWork.Commit();
    }

    private async Task<Entry> GetByIdWithNullCheck(long id)
    {
        var entry = await entryRepository.GetById(id);
        if (entry is null)
            throw new ArgumentException($"Expense with id {id} was not found");
        return entry;
    }
}
