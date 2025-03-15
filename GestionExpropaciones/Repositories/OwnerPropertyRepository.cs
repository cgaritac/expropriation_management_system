using GestionExpropaciones.Data;
using GestionExpropaciones.Interfaces.IRepositories;
using GestionExpropaciones.Models;
using Microsoft.EntityFrameworkCore;
using GestionExpropaciones.Common;

namespace GestionExpropaciones.Repositories;

public class OwnerPropertyRepository(AppDbContext context) : IOwnerPropertyRepository
{
    private readonly AppDbContext _context = context;

    public async Task<List<OwnerPropertyModel>> GetOwnerPropertyList_Pagination_SearchAsync(int pageNumber, string searchTerm)
    {
        var query = _context.OwnerProperties
            .Where(f => f.Is_Active);


        query = Apply_SearchFilter(query, searchTerm);

        var ownerPropertyList = await query
            .OrderDescending()
            .Skip((pageNumber - 1) * Constants.PageSize)
            .Take(Constants.PageSize)
            .ToListAsync();

        return ownerPropertyList;
    }

    public async Task<int> GetOwnerProperty_TotalCountAsync(string searchTerm)
    {
        var query = _context.OwnerProperties
            .Where(f => f.Is_Active);

        query = Apply_SearchFilter(query, searchTerm);

        var totalCount = await query.CountAsync();

        return totalCount;
    }

    public IQueryable<OwnerPropertyModel> Apply_SearchFilter(IQueryable<OwnerPropertyModel> query, string searchTerm)
    {
        if (!string.IsNullOrEmpty(searchTerm))
        {
            searchTerm = searchTerm.ToLower();

            query = query.Where(f =>
                f.Is_Active &&
                (f.Id.ToString().Contains(searchTerm) ||
                f.CadastralMap_Number.Contains(searchTerm)) //Falta incluir la fecha final, el status y la fase
            );
        }

        return query;
    }
}
