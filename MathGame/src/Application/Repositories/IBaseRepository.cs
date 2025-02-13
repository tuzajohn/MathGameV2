using SQLite;

namespace MathGame.src.Application.Repositories;

public interface IBaseRepository<T, TIdType> where T : BaseEntity<TIdType>, new()
    where TIdType : new()
{
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T?> GetAsync(TIdType id);
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);

    Task<TCustom> GetFromRawSQLAsync<TCustom>(string query, params object[] param)
        where TCustom: class, new();

}
