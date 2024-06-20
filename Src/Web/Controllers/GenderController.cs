using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resource = Application.Features.Gender;

namespace Web.Controllers;

// [Authorize]
[ApiController, Route("api/v1")]
public class GenderController(ISender mediator) : ControllerBase
{
    [HttpGet]
    [Route("gender")]
    public async Task<IActionResult> GetAll()
    {
        var response = await mediator.Send(new Resource.GetAll.Request());
        return Ok(response);
    }
}