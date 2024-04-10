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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.UserName).IsRequired();

                builder.HasOne(d => d.WatchList)
                     .WithMany(p => p.Users)
                     .HasForeignKey(p => p.WatchListId)
                     .OnDelete(DeleteBehavior.ClientSetNull);

                builder.HasQueryFilter(x=>!x.DateDeleted.HasValue);
            }
        }
    }
}
