using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Users = Application.Features.Users;

namespace Web.Controllers;

[Authorize]
[ApiController, Route("api/v1")]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [Route("profile/{userId}")]
    public async Task<IActionResult> GetProfile([FromRoute] int userId)
    {
        var response = await mediator.Send(new Users.Profile.GetById.Request(userId));
        return Ok(response);
    }
}