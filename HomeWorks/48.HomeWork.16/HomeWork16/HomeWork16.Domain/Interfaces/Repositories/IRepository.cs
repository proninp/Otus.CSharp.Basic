using HomeWork16.Domain.Models.Abstractions;
using LinqToDB;

namespace HomeWork16.Domain.Interfaces.Repositories;
public interface IRepository<T>
    where T : BaseModel
{
    Task<T?> GetByIdAsync(
        int id,
        Func<IQueryable<T>, ILoadWithQueryable<T, object>>? include = null,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<T>> GetAsync(
        Func<IQueryable<T>, ILoadWithQueryable<T, object>>? include = null,
        CancellationToken cancellationToken = default);

    Task<T> AddAsync(T model, CancellationToken cancellationToken);

    Task<int> UpdateAsync(T model, CancellationToken cancellationToken);

    Task<int> DeleteAsync(int id, CancellationToken cancellationToken);
}