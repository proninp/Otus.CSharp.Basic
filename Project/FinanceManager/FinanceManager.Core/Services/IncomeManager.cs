using FinanceManager.Core.DataTransferObjects;
using FinanceManager.Core.Models;
using FinanceManager.Core.Services.Abstractions;

namespace FinanceManager.Core.Services;
public sealed class IncomeManager(IIncomeRepository incomeRepository, IUnitOfWork unitOfWork)
{

    public async Task<IncomeDto?> GetById(long id)
    {
        return (await incomeRepository.GetById(id))?.ToDto();
    }

    public async Task<IncomeDto[]> GetIncomes()
    {
        return await incomeRepository.GetAll(x => x.ToDto());
    }

    public async Task PutIncome(PutIncomeDto command)
    {
        if (command.Id == 0)
        {
            incomeRepository.Add(command.ToModel());
        }
        else
        {
            var income = await GetByIdWithNullCheck(command.Id);
            income!.Amount = command.Amount;
            income.Description = command.Description;
        }
        await unitOfWork.Commit();
    }

    public async Task DeleteIncome(long id)
    {
        var income = await GetByIdWithNullCheck(id);
        incomeRepository.Delete(income);
        await unitOfWork.Commit();
    }

    private async Task<Income> GetByIdWithNullCheck(long id)
    {
        var income = await incomeRepository.GetById(id);
        if (income is null)
            throw new ArgumentException($"Income with id {id} was not found");
        return income;
    }
}
