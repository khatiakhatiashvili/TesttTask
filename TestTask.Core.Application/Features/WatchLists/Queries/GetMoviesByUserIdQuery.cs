using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Core.Application.DTOs;
using TestTask.Core.Application.Services;

namespace TestTask.Core.Application.Features.WatchLists.Queries
{
    public class GetMoviesByUserIdQuery
    {
        public sealed record Request : IRequest<GetPaginationDto<GetMovieDto>>
        {

            public int PageIndex { get; set; } = 1;
            public int PageSize { get; set; } = 20;
            public Guid UserId { get; set; }

        }
        public class Handler : IRequestHandler<Request, GetPaginationDto<GetMovieDto>>
        {
          
            private readonly IMapper _mapper;
            private readonly IMovieService _movieService;
            public Handler(IMapper mapper,  IMovieService movieService)
            {
            
                _mapper = mapper;
                _movieService = movieService;
            }

            public async Task<GetPaginationDto<GetMovieDto>> Handle(Request request, CancellationToken cancellationToken)
            {
                var pagedMovies = await _movieService.GetPagedMovieByUserIdAsync(request.PageIndex,
                           request.PageSize,
                           request.UserId);
                return _mapper.Map<GetPaginationDto<GetMovieDto>>(pagedMovies);

            }

        }
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.UserId)
                  .NotEmpty().WithMessage(" მომხმარებლის Id ველი ცარიელიაა");
             
            }
        }
    }
}
