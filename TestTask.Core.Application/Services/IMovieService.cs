using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Core.Application.DTOs;

namespace TestTask.Core.Application.Services
{
    public interface IMovieService
    {
        Task<GetPaginationDto<GetMovieDto>> GetPagedMovieListAsync(int pageIndex,
           int pageSize,
           string name);
        Task<GetPaginationDto<GetMovieDto>> GetPagedMovieByUserIdAsync(int pageIndex,
          int pageSize,
          Guid userId);
        
    }
}
