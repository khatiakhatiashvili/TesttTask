using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestTask.Core.Application.DTOs;
using TestTask.Core.Application.Features.Movies.Queries;
using TestTask.Core.Application.Features.WatchLists.Queries;

namespace TestTask.Presentation.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MoviesController(IMediator mediator) =>
          _mediator = mediator; 

        #region  ფილმების სია
        /// <summary>
        ///   ფილმების სია
        /// </summary>    

        [HttpGet("Movies")]
        public async Task<GetPaginationDto<GetMovieDto>> Movies([FromQuery] GetMovieQuery.Request request) =>      
             await _mediator.Send(request);

        #endregion
        [HttpGet("MovieByUserIdAsync")]
        public async Task<GetPaginationDto<GetMovieDto>> MovieByUserIdAsync([FromQuery] GetMoviesByUserIdQuery.Request request) =>
          await _mediator.Send(request);

        

    }
}
