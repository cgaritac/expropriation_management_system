using GestionExpropaciones.Data;
using GestionExpropaciones.Interfaces.IRepositories;
using GestionExpropaciones.Models;
using Microsoft.EntityFrameworkCore;
using GestionExpropaciones.Common;
using GestionExpropaciones.Common.Exceptions;

namespace GestionExpropaciones.Repositories;

public class OwnerRepository(AppDbContext context) : IOwnerRepository
{
    private readonly AppDbContext _context = context;

    public async Task Verify_ExistingOwnerAsync(OwnerModel project)
    {
        var existingOwner = await _context.Owners
            .FirstOrDefaultAsync(f => f.Identification_Number == project.Identification_Number);

        if (existingOwner != null)
            throw new RepositoryException(Constants.OwnerNumberExistanceError);
    }

    public async Task<OwnerModel?> GetOwner_ByIdAsync(int idOwner)
    {
        var owner = await _context.Owners
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Id == idOwner && f.Is_Active);

        return owner;
    }

    public async Task<List<OwnerModel>> GetOwnerListAsync()
    {
        var ownerList = await _context.Owners
            .Where(f => f.Is_Active)
            .ToListAsync();

        return ownerList;
    }

    public async Task<List<OwnerModel>> GetOwnerList_Pagination_SearchAsync(int pageNumber, string searchTerm)
    {
        var query = _context.Owners
            .Where(f => f.Is_Active);


        query = Apply_SearchFilter(query, searchTerm);

        var ownerList = await query
            .OrderDescending()
            .Skip((pageNumber - 1) * Constants.PageSize)
            .Take(Constants.PageSize)
            .ToListAsync();

        return ownerList;
    }

    public async Task<int> GetOwner_TotalCountAsync(string searchTerm)
    {
        var query = _context.Owners
            .Where(f => f.Is_Active);

        query = Apply_SearchFilter(query, searchTerm);

        var totalCount = await query.CountAsync();

        return totalCount;
    }

    public IQueryable<OwnerModel> Apply_SearchFilter(IQueryable<OwnerModel> query, string searchTerm)
    {
        if (!string.IsNullOrEmpty(searchTerm))
        {
            searchTerm = searchTerm.ToLower();

            query = query.Where(f =>
                f.Is_Active &&
                (f.Id.ToString().Contains(searchTerm) ||
                f.Identification_Number.Contains(searchTerm)) //Falta incluir la fecha final, el status y la fase
            );
        }

        return query;
    }

    public async Task<bool> Create_OwnerAsync(OwnerModel owner)
    {
        try
        {
            await Verify_ExistingOwnerAsync(owner);

            await _context.AddAsync(owner);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new RepositoryException(Constants.CreationError, ex);
        }
    }

    public async Task<bool> Edit_OwnerAsync(OwnerModel owner)
    {
        try
        {
            var rowsAffected = await _context.Owners
                .Where(f => f.Id == owner.Id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(f => f.Identification_Number, owner.Identification_Number)
                    .SetProperty(f => f.Owner_Type, owner.Owner_Type)
                    .SetProperty(f => f.First_Name, owner.First_Name)
                    .SetProperty(f => f.Last_Name1, owner.Last_Name1)
                    .SetProperty(f => f.Last_Name2, owner.Last_Name2)
                    .SetProperty(f => f.Phone1, owner.Phone1)
                    .SetProperty(f => f.Phone2, owner.Phone2)
                    .SetProperty(f => f.Email1, owner.Email1)
                    .SetProperty(f => f.Email12, owner.Email12)
                    .SetProperty(f => f.Address, owner.Address)
                    .SetProperty(f => f.Comments, owner.Comments));

            return rowsAffected > 0;
        }
        catch (Exception ex)
        {
            throw new RepositoryException(Constants.EditError, ex);
        }
    }

    public async Task<bool> Delete_OwnerAsync(int idOwner)
    {
        try
        {
            var ownerToDelete = await GetOwner_ByIdAsync(idOwner);

            if (ownerToDelete == null)
                throw new RepositoryException(Constants.NoOwnerToDeleteError);

            _context.Owners.Remove(ownerToDelete);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new RepositoryException(Constants.DeletionError, ex);
        }
    }
}
