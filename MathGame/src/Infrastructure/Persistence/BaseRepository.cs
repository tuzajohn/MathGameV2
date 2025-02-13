global using MathGame.src.Infrastructure.Common.CustomExceptions;
global using MathGame.src.Domain.Common;
using SQLite;
using System.Collections.Immutable;
using System.Threading;
using MathGame.src.Infrastructure.Common.Helpers;

namespace MathGame.src.Infrastructure.Persistence;

public class BaseRepository<T, TIdType> : IBaseRepository<T, TIdType> where T : BaseEntity<TIdType>, new()
    where TIdType : new()
{
    protected readonly SQLiteAsyncConnection Context;

    public BaseRepository(SQLiteAsyncConnection context)
    {
        Context = context;
    }

    public async Task CreateAsync(T entity)
    {
        entity.CreatedOn = DateTimeOffset.UtcNow;
        await Context.RunInTransactionAsync(conn =>
        {
            var result = conn.Insert(entity);

            if (result < 1)
            {
                throw new NotAddedException(new MessageResponse("Failed to add new record", -1));
            }
        });
    }

    public async Task UpdateAsync(T entity)
    {
        entity.UpdatedOn = DateTimeOffset.UtcNow;

        await Context.RunInTransactionAsync(conn =>
        {
            TryCatchHelper.Try(() =>
            {
                var result = conn.Update(entity);
                if (result < 1)
                {
                    throw new NotAddedException(new MessageResponse("Failed to update record", -1));
                }
            });
        });
    }

    public async Task DeleteAsync(T entity)
    {
        entity.DeletedOn = DateTimeOffset.UtcNow;
        entity.IsDeleted = true;
        await Context.RunInTransactionAsync(conn =>
        {
            TryCatchHelper.Try(() =>
            {
                var result = conn.Delete(entity);
                if (result < 1)
                {
                    throw new NotAddedException(new MessageResponse("Failed to delete record", -1));
                }
            });
        });
    }

    public async Task<T?> GetAsync(TIdType id)
    {
        var result = await Context.FindAsync<T>(id);

        return result;
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
    {
        var query = Context.Table<T>();

        query = query.Where(x => !x.IsDeleted.HasValue || !x.IsDeleted.Value);

        if (filter != null)
        {
            query = query.Where(filter);
        }

        return await query.ToListAsync();

    }

    public async Task<TCustom> GetFromRawSQLAsync<TCustom>(string query, params object[] param)
        where TCustom : class, new()
    {
        return await Context.ExecuteScalarAsync<TCustom>(query, param);
    }
}