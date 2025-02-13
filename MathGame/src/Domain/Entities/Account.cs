using SQLite;

namespace MathGame.src.Domain.Entities;

[Table("Accounts")]
public class Account : BaseEntity<Guid>
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public Account() { }
    public Account(string username, string password, string email)
    {
        Id = Guid.NewGuid();
        Username = username;
        Password = password;
        Email = email;
    }
}
