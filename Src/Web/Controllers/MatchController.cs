using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resource = Application.Features.Match;

namespace Web.Controllers;

// [Authorize]
[ApiController, Route("api/v1")]
public class MatchController(ISender mediator) : ControllerBase
{
    [HttpGet]
    [Route("match")]
    public async Task<IActionResult> GetAll()
    {
        var response = await mediator.Send(new Resource.GetAll.Request());
        return Ok(response);
    }

    [HttpGet]
    [Route("match/{matchId}")]
    public async Task<IActionResult> GetById([FromRoute] int stadiumId)
    {
        var response = await mediator.Send(new Resource.GetById.Request(stadiumId));
        return Ok(response);
    }

    [HttpPost]
    [Route("match")]
    public async Task<IActionResult> Create([FromBody] Resource.Create.Request request)
    {
        var response = await mediator.Send(new Resource.Create.Request(request));
        return Ok(response);
    }

    [HttpPatch]
    [Route("match/{matchId}")]
    public async Task<IActionResult> Update([FromBody] Resource.Update.Request request, [FromRoute] int stadiumId)
    {
        var response = await mediator.Send(new Resource.Update.Request(request, stadiumId));
        return Ok(response);
    }

    [HttpDelete]
    [Route("match/{matchId}")]
    public async Task<IActionResult> Delete([FromRoute] int stadiumId)
    {
        var response = await mediator.Send(new Resource.Delete.Request(stadiumId));
        return Ok(response);
    }
}