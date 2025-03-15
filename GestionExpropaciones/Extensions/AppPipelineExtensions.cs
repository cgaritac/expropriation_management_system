using GestionExpropaciones.Middleware;

namespace GestionExpropaciones.Extensions;

public static class AppPipelineExtensions
{
    public static IApplicationBuilder ConfigureAppPipeline(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            app.UseExceptionHandler("/Files/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        //app.UseInvalidateCookiesMiddleware();
        app.UseRouting();        
        app.UseEmailDomainMiddleware();

        app.UseAuthentication();
        app.UseAuthorization();

       
     
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Files}/{action=Index}/{id?}");
        });

        return app;
    }
}