using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resource = Application.Features.Stadium;

namespace Web.Controllers;

// [Authorize]
[ApiController, Route("api/v1")]
public class StadiumController(ISender mediator) : ControllerBase
{
    [HttpGet]
    [Route("stadium")]
    public async Task<IActionResult> GetAll()
    {
        var response = await mediator.Send(new Resource.GetAll.Request());
        return Ok(response);
    }

    [HttpGet]
    [Route("stadium/{stadiumId}")]
    public async Task<IActionResult> GetById([FromRoute] int stadiumId)
    {
        var response = await mediator.Send(new Resource.GetById.Request(stadiumId));
        return Ok(response);
    }

    [HttpPost]
    [Route("stadium")]
    public async Task<IActionResult> Create([FromBody] Resource.Create.Request request)
    {
        var response = await mediator.Send(new Resource.Create.Request(request));
        return Ok(response);
    }

    [HttpPatch]
    [Route("stadium/{stadiumId}")]
    public async Task<IActionResult> Update([FromBody] Resource.Update.Request request, [FromRoute] int stadiumId)
    {
        var response = await mediator.Send(new Resource.Update.Request(request, stadiumId));
        return Ok(response);
    }

    [HttpDelete]
    [Route("stadium/{stadiumId}")]
    public async Task<IActionResult> Delete([FromRoute] int stadiumId)
    {
        var response = await mediator.Send(new Resource.Delete.Request(stadiumId));
        return Ok(response);
    }
}