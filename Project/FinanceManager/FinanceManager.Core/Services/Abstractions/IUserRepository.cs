using FinanceManager.Core.Models;

namespace FinanceManager.Core.Services.Abstractions;
public interface IUserRepository
{
    Task<User?> GetById(long id);

    Task<User?> GetByTelegramId(long telegramId);

    void Add(User user);

    void Update(User user);

    void Delete(User user);

    Task Delete(long id);
}
