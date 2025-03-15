using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace GestionExpropaciones.Middleware;

public class EmailDomainMiddleware
{
    private readonly RequestDelegate _next;

    public EmailDomainMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.User.Identity.IsAuthenticated)
        {
            var email = context.User.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(email))
            {
                await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                context.Response.Redirect("/Auth/Login");
                return;
            }

            if (!email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
            {
                await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                context.Response.Redirect("/Auth/Login");
                return;
            }
        }

        await _next(context);
    }
}

public static class EmailDomainMiddlewareExtensions
{
    public static IApplicationBuilder UseEmailDomainMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<EmailDomainMiddleware>();
    }
}
