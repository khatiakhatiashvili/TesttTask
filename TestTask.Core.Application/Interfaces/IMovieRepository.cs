using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Core.Application.Commons;
using TestTask.Core.Application.DTOs;
using TestTask.Core.Domain.Entities;

namespace TestTask.Core.Application.Interfaces
{
    public interface IMovieRepository : IRepository<Guid, Movie>
    {
        Task<Pagination<Movie>> GetPagedMovieListAsync(
              int pageIndex,
              int pageSize,
              string? name);
        Task<bool> IfExistMovie(Guid movieId);
        Task<Pagination<GetMovieDto>> GetPagedMovieByUserIdAsync(
              int pageIndex,
              int pageSize,
              Guid userId); 
    }
}
