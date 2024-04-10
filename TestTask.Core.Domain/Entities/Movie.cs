using TestTask.Core.Domain.Basics;

namespace TestTask.Core.Domain.Entities
{
    public class Movie : AuditableEntity
    {
        public string Name { get; set; }
        public string ReleaseYear { get; set; }

        public virtual WatchList? WatchList { get; set; }
        public Guid? WatchListId { get; set; }

    }
}
