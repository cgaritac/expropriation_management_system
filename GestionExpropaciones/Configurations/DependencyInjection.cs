using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using GestionExpropaciones.Common;
using GestionExpropaciones.Interceptors;
using Microsoft.EntityFrameworkCore;
using GestionExpropaciones.Data;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace GestionExpropaciones.Configurations;

public static class DependencyInjection
{
    public static IServiceCollection AddDefaultServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AppSettings>(configuration);

        services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AppConnection")).AddInterceptors(new SoftDeleteInterceptor()));

        services.AddSingleton<Constants>();
        services.AddSingleton(sp => sp.GetRequiredService<IOptions<AppSettings>>().Value);

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
        })
        .AddCookie(options =>
        {
            options.LoginPath = "/Auth/Login";
            options.LogoutPath = "/Auth/Logout";
            options.AccessDeniedPath = "/Auth/AccessDenied";
            options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
            options.SlidingExpiration = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        })
        .AddGoogle(options =>
        {
            var appSettings = services.BuildServiceProvider().GetRequiredService<IOptions<AppSettings>>().Value;
            options.ClientId = appSettings.GoogleKeys.ClientId;
            options.ClientSecret = appSettings.GoogleKeys.ClientSecret;
            options.AccessType = "offline";
        });

        services.AddAuthorization();
        services.AddControllersWithViews(options =>
        {
            var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            options.Filters.Add(new AuthorizeFilter(policy));
        });

        return services;
    }
}