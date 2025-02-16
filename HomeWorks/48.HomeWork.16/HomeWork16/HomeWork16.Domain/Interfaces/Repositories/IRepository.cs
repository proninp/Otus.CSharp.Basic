using HomeWork16.Domain.Models.Abstractions;

namespace HomeWork16.Domain.Interfaces.Repositories;
public interface IRepository<T>
    where T : BaseModel
{
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<IEnumerable<T>> GetAsync(CancellationToken cancellationToken);
    Task<T> AddAsync(T model, CancellationToken cancellationToken);

    Task<T> UpdateAsync(T model, CancellationToken cancellationToken);

    Task DeleteAsync(int id, CancellationToken cancellationToken);
}