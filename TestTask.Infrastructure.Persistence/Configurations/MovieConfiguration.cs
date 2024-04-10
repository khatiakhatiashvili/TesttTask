using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Core.Domain.Entities;

namespace TestTask.Infrastructure.Persistence.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movie");
            {
                builder.HasKey(x => x.Id);
           
                builder.HasOne(d => d.WatchList)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(p => p.WatchListId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                builder.HasQueryFilter(x => !x.DateDeleted.HasValue);
            }
        }
    }
}
