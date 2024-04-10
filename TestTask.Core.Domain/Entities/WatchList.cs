using TestTask.Core.Domain.Basics;

namespace TestTask.Core.Domain.Entities
{
    public class WatchList : AuditableEntity
    {
        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
