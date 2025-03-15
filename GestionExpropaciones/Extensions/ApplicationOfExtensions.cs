using Microsoft.EntityFrameworkCore;
using GestionExpropaciones.Data;

namespace GestionExpropaciones.Extensions;

public static class ApplicationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.Migrate();
        }
    }
}
