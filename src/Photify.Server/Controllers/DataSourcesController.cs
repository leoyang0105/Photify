using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Photify.Application.Commands.DataSources;

namespace Photify.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataSourcesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DataSourcesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddDataSourceCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
