using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resource = Application.Features.Country;

namespace Web.Controllers;

// [Authorize]
[ApiController, Route("api/v1")]
public class CountryController(ISender mediator) : ControllerBase
{
    [HttpGet]
    [Route("country")]
    public async Task<IActionResult> GetAll()
    {
        var response = await mediator.Send(new Resource.GetAll.Request());
        return Ok(response);
    }

    [HttpPost]
    [Route("country")]
    public async Task<IActionResult> Create([FromBody] Resource.Create.Request request)
    {
        var response = await mediator.Send(new Resource.Create.Request(request));
        return Ok(response);
    }

    // [HttpDelete]
    // [Route("country/{countryId}")]
    // public async Task<IActionResult> Delete([FromRoute] int countryId)
    // {
    //     var response = await mediator.Send(new Resource.Delete.Request(countryId));
    //     return Ok(response);
    // }
}