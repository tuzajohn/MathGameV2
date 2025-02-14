using SQLite;

namespace MathGame.src.Domain.Entities;

[Table("Accounts")]
public class Account : BaseEntity<Guid>
{
    public string? Password { get; set; }
    public string? Email { get; set; }
    public Account() { }

    public Account(string email, string password)
    {
        Id = Guid.NewGuid();
        Password = password;
        Email = email;
    }
}
