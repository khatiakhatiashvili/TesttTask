using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Core.Application.Interfaces;
using TestTask.Core.Domain.Entities;

namespace TestTask.Infrastructure.Persistence.Implementations.Repository
{
    internal class WatchListRepository : Repository<WatchList>, IWatchListRepository
    {
        public WatchListRepository(DataContext context) : base(context) { }

        public async Task<bool> IfExistWatchList(Guid userId, Guid movieId)
        {
            return await _context.WatchLists.AnyAsync(z => z.MovieId == movieId && z.UserId == userId && z.DateDeleted == null);
        }
        
    }
}
