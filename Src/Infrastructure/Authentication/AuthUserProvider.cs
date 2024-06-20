using System.Security.Claims;
using Application.Abstractions;
using Application.Context;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Authentication;

public class AuthUserProvider(IHttpContextAccessor accessor, ITicketingContext ticketingCtx) : IAuthUserProvider
{
    public string GetEmail()
    {
        return accessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? "";
    }
}