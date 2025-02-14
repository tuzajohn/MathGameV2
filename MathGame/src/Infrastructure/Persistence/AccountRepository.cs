using SQLite;

namespace MathGame.src.Infrastructure.Persistence;

public class AccountRepository : BaseRepository<Account, Guid>, IAccountRepository
{
    public AccountRepository(SQLiteAsyncConnection context) : base(context)
    {

    }

    public async Task<MessageResponse<Account>> Login(string email, string password)
    {
        var accounts = await GetAllAsync(q => q.Email == email && q.Password == password);

        if (accounts == null)
            return new MessageResponse<Account>("Email or password is invalid", -1, null);

        return new MessageResponse<Account>("Account found", 0, accounts[0]);
    }
}
