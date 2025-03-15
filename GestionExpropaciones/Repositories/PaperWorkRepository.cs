using GestionExpropaciones.Data;
using GestionExpropaciones.Interfaces.IRepositories;
using GestionExpropaciones.Common;
using GestionExpropaciones.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionExpropaciones.Repositories;

public class PaperWorkRepository(AppDbContext context) : IPaperWorkRepository
{
    private readonly AppDbContext _context = context;

    public async Task<List<PaperWorkModel>> GetPaperWorkList_Pagination_SearchAsync(int pageNumber, string searchTerm)
    {
        var query = _context.PaperWorks
            .Where(f => f.Is_Active);


        query = Apply_SearchFilter(query, searchTerm);

        var paperWorkList = await query
            .OrderDescending()
            .Skip((pageNumber - 1) * Constants.PageSize)
            .Take(Constants.PageSize)
            .ToListAsync();

        return paperWorkList;
    }

    public async Task<int> GetPaperWork_TotalCountAsync(string searchTerm)
    {
        var query = _context.PaperWorks
            .Where(f => f.Is_Active);

        query = Apply_SearchFilter(query, searchTerm);

        var totalCount = await query.CountAsync();

        return totalCount;
    }

    public IQueryable<PaperWorkModel> Apply_SearchFilter(IQueryable<PaperWorkModel> query, string searchTerm)
    {
        if (!string.IsNullOrEmpty(searchTerm))
        {
            searchTerm = searchTerm.ToLower();

            query = query.Where(f =>
                f.Is_Active &&
                (f.Id.ToString().Contains(searchTerm) ||
                f.Document_Number.Contains(searchTerm)) //Falta incluir la fecha final, el status y la fase
            );
        }

        return query;
    }
}
