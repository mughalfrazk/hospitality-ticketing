using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Team = Application.Features.Team;

namespace Web.Controllers;

// [Authorize]
[ApiController, Route("api/v1")]
public class TeamController(ISender mediator) : ControllerBase
{
    [HttpGet]
    [Route("team")]
    public async Task<IActionResult> GetAll()
    {
        var response = await mediator.Send(new Team.GetAll.Request());
        return Ok(response);
    }

    [HttpGet]
    [Route("team/{teamId}")]
    public async Task<IActionResult> GetById([FromRoute] int teamId)
    {
        var response = await mediator.Send(new Team.GetById.Request(teamId));
        return Ok(response);
    }

    [HttpPost]
    [Route("team")]
    public async Task<IActionResult> Create([FromBody] Team.Create.Request request)
    {
        var response = await mediator.Send(new Team.Create.Request(request));
        return Ok(response);
    }

    [HttpPatch]
    [Route("team/{teamId}")]
    public async Task<IActionResult> Update([FromBody] Team.Update.Request request, [FromRoute] int teamId)
    {
        var response = await mediator.Send(new Team.Update.Request(request, teamId));
        return Ok(response);
    }

    [HttpDelete]
    [Route("team/{teamId}")]
    public async Task<IActionResult> Delete([FromRoute] int teamId)
    {
        var response = await mediator.Send(new Team.Delete.Request(teamId));
        return Ok(response);
    }
}