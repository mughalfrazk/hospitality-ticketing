using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resource = Application.Features.Competition;

namespace Web.Controllers;

[Authorize]
[ApiController, Route("api/v1")]
public class CompetitionController(ISender mediator) : ControllerBase
{
    [HttpGet]
    [Route("competition")]
    public async Task<IActionResult> GetAll()
    {
        var response = await mediator.Send(new Resource.GetAll.Request());
        return Ok(response);
    }

    [HttpGet]
    [Route("competition/{competitionId}")]
    public async Task<IActionResult> GetById([FromRoute] int competitionId)
    {
        var response = await mediator.Send(new Resource.GetById.Request(competitionId));
        return Ok(response);
    }

    [HttpPost]
    [Route("competition")]
    public async Task<IActionResult> Create([FromBody] Resource.Create.Request request)
    {
        var response = await mediator.Send(new Resource.Create.Request(request));
        return Ok(response);
    }

    [HttpPatch]
    [Route("competition/{competitionId}")]
    public async Task<IActionResult> Update([FromBody] Resource.Update.Request request, [FromRoute] int competitionId)
    {
        var response = await mediator.Send(new Resource.Update.Request(request, competitionId));
        return Ok(response);
    }

    [HttpDelete]
    [Route("competition/{competitionId}")]
    public async Task<IActionResult> Delete([FromRoute] int competitionId)
    {
        var response = await mediator.Send(new Resource.Delete.Request(competitionId));
        return Ok(response);
    }
}