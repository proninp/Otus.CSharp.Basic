using System.Linq.Expressions;
using HomeWork16.Domain.Interfaces.Repositories;
using HomeWork16.Domain.Models.Abstractions;
using HomeWork16.Infrastructure.Data;
using LinqToDB;

namespace HomeWork16.Infrastructure.Repositories;
public sealed class Repository<T> : IRepository<T>
    where T : BaseModel
{
    private readonly DatabaseContext _db;
    private readonly ITable<T> _table;

    public Repository(DatabaseContext db)
    {
        _db = db;
        _table = _db.GetTable<T>();
    }

    public async Task<IEnumerable<TView>> GetAsync<TView>(
        Func<T, TView> selector,
        Func<IQueryable<T>, ILoadWithQueryable<T, object>>? include = null,
        Expression<Func<T, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        var query = _table.AsQueryable();

        if (include is not null)
            query = include(query);

        if (predicate is not null)
            query = query.Where(predicate);

        return await query
            .Select(x => selector(x))
            .ToListAsync(cancellationToken);
    }

    public async Task<TView?> GetByIdAsync<TView>(
        int id,
        Func<T, TView> selector,
        Func<IQueryable<T>, ILoadWithQueryable<T, object>>? include = null,
        CancellationToken cancellationToken = default)
    {
        var query = _table.AsQueryable()
            .Where(x => x.Id == id);

        if (include is not null)
            query = include(query);

        return await query
            .Select(x => selector(x))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<T> AddAsync(T model, CancellationToken cancellationToken)
    {
        model.Id = await _db.InsertWithInt32IdentityAsync(model, token: cancellationToken);
        return model;
    }

    public async Task<int> UpdateAsync(T model, CancellationToken cancellationToken)
    {
        return await _db.UpdateAsync<T>(model, token: cancellationToken);
    }

    public async Task<int> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        return await _table
            .Where(x => x.Id == id)
            .DeleteAsync(cancellationToken);
    }
}