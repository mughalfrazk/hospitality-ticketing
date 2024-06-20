using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resource = Application.Features.City;

namespace Web.Controllers;

// [Authorize]
[ApiController, Route("api/v1")]
public class CityController(ISender mediator) : ControllerBase
{
    [HttpGet]
    [Route("city")]
    public async Task<IActionResult> GetAll()
    {
        var response = await mediator.Send(new Resource.GetAll.Request());
        return Ok(response);
    }

    [HttpPost]
    [Route("city")]
    public async Task<IActionResult> Create([FromBody] Resource.Create.Request request)
    {
        var response = await mediator.Send(new Resource.Create.Request(request));
        return Ok(response);
    }

    // [HttpDelete]
    // [Route("city/{cityId}")]
    // public async Task<IActionResult> Delete([FromRoute] int cityId)
    // {
    //     var response = await mediator.Send(new Resource.Delete.Request(cityId));
    //     return Ok(response);
    // }
}