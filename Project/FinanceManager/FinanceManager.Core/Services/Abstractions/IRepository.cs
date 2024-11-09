namespace FinanceManager.Core.Services.Abstractions;

public interface IRepository<T>
{
    Task<T?> GetById(long id);

    Task<TResult[]> GetAll<TResult>(Func<T, TResult> selector);

    void Add(T item);
    
    void Update(T item);

    void Delete(T item);

    Task Delete(long id);
}