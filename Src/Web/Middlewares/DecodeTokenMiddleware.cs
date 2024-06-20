namespace Web.Middlewares;

public class DecodeTokenMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext ctx)
    {
        var isAuthenticated = ctx.User.Identity?.IsAuthenticated ?? false;
        if (isAuthenticated)
        {
        }

        await next(ctx);
    }
}