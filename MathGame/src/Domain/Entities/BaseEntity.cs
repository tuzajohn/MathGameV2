using SQLite;

namespace MathGame.src.Domain.Entities
{
    public class BaseEntity<T> where T : new()
    {
        [PrimaryKey]
        public virtual T Id { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }

        public Guid? CreatedById { get; set; }

        public Guid? UpdatedById { get; set; }

        public Guid? DeletedById { get; set; }
    }

}
