using AutoMapper;
using FluentValidation;
using MediatR;
using TestTask.Core.Application.Commons;
using TestTask.Core.Application.DTOs;
using TestTask.Core.Application.Interfaces;
using TestTask.Core.Application.Services;

namespace TestTask.Core.Application.Features.UserProfiles.Commands
{

    public record CreateWatchListCommand
    {
        public class Request : IRequest<GetWatchListDto>
        {
          public Guid UserId { get; set; }
          public Guid MovieId { get; set; }          

        }       
        public sealed class Handler : IRequestHandler<Request, GetWatchListDto>
        {     
            private readonly IUserService _userService;
            private readonly IMapper _mapper;
            public Handler(  IUserService userService, IMapper mapper)
            {             
                _userService = userService;
                _mapper = mapper;
            }
            public async Task<GetWatchListDto> Handle(Request request, CancellationToken cancellationToken)
            {
                var newWatchList = await _userService.CreateWatchListAsync(request.UserId,request.MovieId);

                return _mapper.Map<GetWatchListDto>(newWatchList);
            }
        }

        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.UserId)
                  .NotEmpty().WithMessage(" მომხმარებლის Id ველი ცარიელიაა");
                RuleFor(x => x.MovieId)
                  .NotEmpty().WithMessage("ფილმის Id ველი ცარიელია");
            }
        }
    }

}
