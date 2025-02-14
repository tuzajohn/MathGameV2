namespace MathGame.src.Application.Repositories;

public interface IAccountRepository : IBaseRepository<Account, Guid>
{
    Task<MessageResponse<Account>> Login(string email, string password);
}
