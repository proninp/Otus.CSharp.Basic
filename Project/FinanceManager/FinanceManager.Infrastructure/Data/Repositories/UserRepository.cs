using FinanceManager.Core.Models;
using FinanceManager.Core.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Infrastructure.Data.Repositories;
public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<User?> GetById(long id)
    {
        return await context
            .Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetByTelegramId(long telegramId)
    {
        return await context
            .Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.TelegramId == telegramId);
    }

    public void Add(User user)
    {
        context.Add(user);
    }

    public void Update(User user)
    {
        context.Users.Update(user);
    }

    public void Delete(User user)
    {
        context.Remove(user);
    }

    public async Task Delete(long id)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user is not null)
        {
            Delete(user);
        }
    }
}
