using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestTask.Core.Application.DTOs;
using TestTask.Core.Application.Features.UserProfiles.Commands;

namespace TestTask.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator) =>
          _mediator = mediator;

       


        [HttpPost("CreateWatchList")]

        public async Task<ActionResult<GetWatchListDto>> CreateWatchList([FromBody] CreateWatchListCommand.Request request, CancellationToken cancellationToken = default) => await _mediator.Send(request, cancellationToken);

        //#endregion
      

        //#region ბენეფიციარების სია
        ///// <summary>
        /////   ბენეფიციარების სია
        ///// </summary>    

        //[HttpGet("GetBeneficiaries")]
        //public async Task<GetPaginationDto<GetAllBeneficiaryDto>> GetBeneficiaries([FromQuery] GetAllBeneficiaryQuery.Request request) => await _mediator.Send(request);
        //#endregion


    }
}
