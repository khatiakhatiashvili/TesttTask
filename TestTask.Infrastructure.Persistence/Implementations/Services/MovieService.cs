using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestTask.Core.Application.DTOs;
using TestTask.Core.Application.Interfaces;
using TestTask.Core.Application.Services;

namespace TestTask.Infrastructure.Persistence.Implementations.Services
{
    public class MovieService: IMovieService
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public MovieService(IMapper mapper, IUnitOfWork unit)
        {
            _unit = unit;
            _mapper = mapper;           
        }

        public async Task<GetPaginationDto<GetMovieDto>> GetPagedMovieByUserIdAsync(int pageIndex, int pageSize, Guid userId)
        {
            var pagedMovies= await _unit.MovieRepository.GetPagedMovieByUserIdAsync(pageIndex, pageSize, userId);

            return _mapper.Map<GetPaginationDto<GetMovieDto>>(pagedMovies);
        }

        public async Task<GetPaginationDto<GetMovieDto>> GetPagedMovieListAsync(int pageIndex, int pageSize, string name)
        {
            var pagedMovies = await _unit.MovieRepository.GetPagedMovieListAsync(pageIndex, pageSize, name);

            return _mapper.Map<GetPaginationDto<GetMovieDto>>(pagedMovies);
        }
    }
}
