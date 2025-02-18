using System.Linq.Expressions;
using HomeWork16.Domain.Models.Abstractions;
using LinqToDB;

namespace HomeWork16.Domain.Interfaces.Repositories;
public interface IRepository<T>
    where T : BaseModel
{
    Task<TView?> GetByIdAsync<TView>(
        int id,
        Func<T, TView> selector,
        Func<IQueryable<T>, ILoadWithQueryable<T, object>>? include = null,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<TView>> GetAsync<TView>(
        Func<T, TView> selector,
        Func<IQueryable<T>, ILoadWithQueryable<T, object>>? include = null,
        Expression<Func<T, bool>>? predicate = null,
        CancellationToken cancellationToken = default);

    Task<T> AddAsync(T model, CancellationToken cancellationToken);

    Task<int> UpdateAsync(T model, CancellationToken cancellationToken);

    Task<int> DeleteAsync(int id, CancellationToken cancellationToken);
}