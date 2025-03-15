using GestionExpropaciones.Data;
using GestionExpropaciones.Interfaces.IRepositories;
using GestionExpropaciones.Common;
using GestionExpropaciones.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionExpropaciones.Repositories;

public class AppraisalRepository(AppDbContext context) : IAppraisalRepository
{
    private readonly AppDbContext _context = context;

    public async Task<List<AppraisalModel>> GetAppraisalList_Pagination_SearchAsync(int pageNumber, string searchTerm)
    {
        var query = _context.Appraisals
            .Where(f => f.Is_Active);


        query = Apply_SearchFilter(query, searchTerm);

        var appraisalList = await query
            .OrderDescending()
            .Skip((pageNumber - 1) * Constants.PageSize)
            .Take(Constants.PageSize)
            .ToListAsync();

        return appraisalList;
    }

    public async Task<int> GetAppraisal_TotalCountAsync(string searchTerm)
    {
        var query = _context.Appraisals
            .Where(f => f.Is_Active);

        query = Apply_SearchFilter(query, searchTerm);

        var totalCount = await query.CountAsync();

        return totalCount;
    }

    public IQueryable<AppraisalModel> Apply_SearchFilter(IQueryable<AppraisalModel> query, string searchTerm)
    {
        if (!string.IsNullOrEmpty(searchTerm))
        {
            searchTerm = searchTerm.ToLower();

            query = query.Where(f =>
                f.Is_Active &&
                (f.Id.ToString().Contains(searchTerm) ||
                f.Appraisal_Number.Contains(searchTerm)) //Falta incluir la fecha final, el status y la fase
            );
        }

        return query;
    }
}
