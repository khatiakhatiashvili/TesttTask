namespace TestTask.Core.Domain.Basics
{
    public abstract class AuditableEntity : BaseEntity
    {
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime? DateUpdated { get; set; }
        public virtual DateTime? DateDeleted { get; set; }
    }
}
