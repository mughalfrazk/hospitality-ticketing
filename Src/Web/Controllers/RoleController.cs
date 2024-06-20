using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resource = Application.Features.Role;

namespace Web.Controllers;

// [Authorize]
[ApiController, Route("api/v1")]
public class RoleController(ISender mediator) : ControllerBase
{
    [HttpGet]
    [Route("role")]
    public async Task<IActionResult> GetAll()
    {
        var response = await mediator.Send(new Resource.GetAll.Request());
        return Ok(response);
    }
}