using Microsoft.EntityFrameworkCore;
using TestTask.Core.Application.Commons;
using TestTask.Core.Application.DTOs;
using TestTask.Core.Application.Interfaces;
using TestTask.Core.Domain.Entities;
using XAct;

namespace TestTask.Infrastructure.Persistence.Implementations.Repository
{
    internal class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(DataContext context) : base(context) { }

        public async Task<Pagination<GetMovieDto>> GetPagedMovieByUserIdAsync(int pageIndex, int pageSize, Guid userId)
        {
            var watchList = await _context.WatchLists.Where(x=>x.UserId == userId).ToListAsync();          

            var query = (from w in watchList
                                  join m in _context.Movies
                                     on w.MovieId equals m.Id
                                     select new GetMovieDto
                                     {
                                         Id = m.Id,
                                         Name = m.Name,
                                         ReleaseYear = m.ReleaseYear,
                                         DateCreated = m.DateCreated,
                                     }).ToList().AsQueryable();

            return await Pagination<GetMovieDto>.CreateAsync(query, pageIndex, pageSize);
        }

        public async Task<Pagination<Movie>> GetPagedMovieListAsync(int pageIndex, int pageSize, string? name)
        {
            var movieList = await _context.Movies.ToListAsync();
          
            var query = movieList.AsQueryable();
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(x => x.Name.Contains(name));
            }

            return await Pagination<Movie>.CreateAsync(query, pageIndex, pageSize);
        }

        public async Task<bool> IfExistMovie(Guid movieId)
        {
            return await _context.Movies.AnyAsync(z => z.Id == movieId);
        }
    }
}
