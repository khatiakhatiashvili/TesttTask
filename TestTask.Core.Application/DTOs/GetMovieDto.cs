namespace TestTask.Core.Application.DTOs
{
    public class GetMovieDto
    {
        public  Guid Id { get; set; }
        public string Name { get; set; }
        public string ReleaseYear { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime? DateUpdated { get; set; }
        public virtual DateTime? DateDeleted { get; set; }

    }
}
