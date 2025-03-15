using GestionExpropaciones.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GestionExpropaciones.Interceptors;

public class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        if (eventData.Context is null) return result;

        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if ((entry.Entity is FileModel) && entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                entry.CurrentValues["Is_Active"] = false;

                var context = eventData.Context;
                var fileId = (int)entry.CurrentValues["Id"];
                var owners = context.Set<OwnerModel>().Where(o => o.FileId == fileId).ToList();

                foreach (var owner in owners)
                {
                    owner.SetSoftDelete();
                    context.Entry(owner).State = EntityState.Modified;
                }
            }

            if ((entry.Entity is ProjectModel) && entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                entry.CurrentValues["Is_Active"] = false;
            }
        }

        return result;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        return new ValueTask<InterceptionResult<int>>(SavingChanges(eventData, result));
    }
}