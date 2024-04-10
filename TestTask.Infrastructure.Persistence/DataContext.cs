using Microsoft.EntityFrameworkCore;
using TestTask.Core.Domain.Entities;
using TestTask.Infrastructure.Persistence.Configurations;

namespace TestTask.Infrastructure.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
   : base(options)
        { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }    
        public DbSet<User> Users { get; set; }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new WatchListConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
