namespace FinanceManager.Core.Services.Abstractions;
public interface IRepository<T>
{
    void Add(T item);

    void Delete(T item);

    void Update(T item);

    Task<TResult[]> GetAll<TResult>(Func<T, TResult> selector);

    Task<T?> GetById(long id);
}