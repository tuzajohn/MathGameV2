using System.ComponentModel.DataAnnotations.Schema;

namespace MathGame.src.Domain.Entities;

[Table("Players")]
public class Player : BaseEntity<Guid>
{
    public Guid AccountId { get; set; }
    public string? Name { get; set; }

    public Player() { }
    public Player(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}