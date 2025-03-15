using GestionExpropaciones.Data;
using GestionExpropaciones.Interfaces.IRepositories;
using GestionExpropaciones.Common;
using GestionExpropaciones.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionExpropaciones.Repositories;

public class ExpropiatedPropertyRepository(AppDbContext context) : IExpropiatedPropertyRepository
{
    private readonly AppDbContext _context = context;

    public async Task<List<ExpropiatedPropertyModel>> GetExpropiatedPropertyList_Pagination_SearchAsync(int pageNumber, string searchTerm)
    {
        var query = _context.ExpropiatedProperties
            .Where(f => f.Is_Active);


        query = Apply_SearchFilter(query, searchTerm);

        var expropiatedPropertyList = await query
            .OrderDescending()
            .Skip((pageNumber - 1) * Constants.PageSize)
            .Take(Constants.PageSize)
            .ToListAsync();

        return expropiatedPropertyList;
    }

    public async Task<int> GetExpropiatedProperty_TotalCountAsync(string searchTerm)
    {
        var query = _context.ExpropiatedProperties
            .Where(f => f.Is_Active);

        query = Apply_SearchFilter(query, searchTerm);

        var totalCount = await query.CountAsync();

        return totalCount;
    }

    public IQueryable<ExpropiatedPropertyModel> Apply_SearchFilter(IQueryable<ExpropiatedPropertyModel> query, string searchTerm)
    {
        if (!string.IsNullOrEmpty(searchTerm))
        {
            searchTerm = searchTerm.ToLower();

            query = query.Where(f =>
                f.Is_Active &&
                (f.Id.ToString().Contains(searchTerm) ||
                f.Folio_Number.Contains(searchTerm)) //Falta incluir la fecha final, el status y la fase
            );
        }

        return query;
    }
}
