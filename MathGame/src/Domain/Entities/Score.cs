using System.ComponentModel.DataAnnotations.Schema;

namespace MathGame.src.Domain.Entities;

[Table("Scores")]
public class Score : BaseEntity<Guid>
{
    public Score() { }
    public int Value { get; private set; }

    public Score(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Score cannot be negative.");
        }
        Value = value;
    }

    public Score Add(int points)
    {
        return new Score(Value + points);
    }

    public Score Deduct(int points)
    {
        return new Score(Math.Max(Value - points, 0));
    }

    public override bool Equals(object? obj)
    {
        if (obj is Score other)
        {
            return Value == other.Value;
        }
        return false;
    }

    public override int GetHashCode() => Value.GetHashCode();
}
