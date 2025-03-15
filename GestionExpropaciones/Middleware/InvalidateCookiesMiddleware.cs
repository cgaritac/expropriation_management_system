using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;

namespace GestionExpropaciones.Middleware;

public class InvalidateCookiesMiddleware
{
    private readonly RequestDelegate _next;

    public InvalidateCookiesMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Cookies.ContainsKey(".AspNetCore.Cookies"))
        {
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            context.Response.Cookies.Delete(".AspNetCore.Cookies");
        }

        await _next(context);
    }
}

public static class InvalidateCookiesMiddlewareExtensions
{
    public static IApplicationBuilder UseInvalidateCookiesMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<InvalidateCookiesMiddleware>();
    }
}
