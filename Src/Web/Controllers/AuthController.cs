using MediatR;
using Microsoft.AspNetCore.Mvc;

using Auth = Application.Features.Auth;

namespace Web.Controllers;

[ApiController, Route("api/v1")]
public class AuthController(ISender mediator) : ControllerBase
{
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] Auth.Login.Request request)
    {
        var response = await mediator.Send(new Auth.Login.Request(request));
        return Ok(response);
    }
    
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Login([FromBody] Auth.Register.Request request)
    {
        var response = await mediator.Send(new Auth.Register.Request(request));
        return Ok(response);
    }
}