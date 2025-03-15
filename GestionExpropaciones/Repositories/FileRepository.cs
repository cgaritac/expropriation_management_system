using GestionExpropaciones.Common.Exceptions;
using GestionExpropaciones.Interfaces.IRepositories;
using GestionExpropaciones.Models;
using GestionExpropaciones.Common;
using GestionExpropaciones.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionExpropaciones.Repositories;

public class FileRepository(AppDbContext context) : IFileRepository
{
    private readonly AppDbContext _context = context;

    public async Task Verify_ExistingFileAsync(FileModel file)
    {
        var existingFile = await _context.Files
            .FirstOrDefaultAsync(f => f.Number == file.Number);

        if (existingFile != null)
            throw new RepositoryException(Constants.FileNumberExistanceError);
    }

    public async Task<FileModel?> GetFile_ByIdAsync(int idFile)
    {
        var file = await _context.Files
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Id == idFile && f.Is_Active);

        return file;
    }

    public async Task<List<FileModel>> GetFileList_Pagination_SearchAsync(int pageNumber, string searchTerm)
    {
        var query = _context.Files
            .Where(f => f.Is_Active);
            

        query = Apply_SearchFilter(query, searchTerm);

        var fileList = await query
            .OrderDescending()
            .Skip((pageNumber - 1) * Constants.PageSize)
            .Take(Constants.PageSize)
            .ToListAsync();        

            return fileList;
    }

    public async Task<int> GetFile_TotalCountAsync(string searchTerm)
    {
        var query = _context.Files
            .Where(f => f.Is_Active);

        query = Apply_SearchFilter(query, searchTerm);
            
        var totalCount = await query.CountAsync();

        return totalCount;
    }

    public IQueryable<FileModel> Apply_SearchFilter(IQueryable<FileModel> query, string searchTerm)
    {
        if (!string.IsNullOrEmpty(searchTerm))
        {
            searchTerm = searchTerm.ToLower();

            query = query.Where(f => 
                f.Is_Active &&
                (f.Id.ToString().Contains(searchTerm) ||
                f.Number.Contains(searchTerm) ||
                f.Start_Date.ToString().Contains(searchTerm)) //Falta incluir la fecha final, el status y la fase
            );
        }

        return query;
    }

    public async Task<bool> Create_FileAsync(FileModel file)
    {
        try
        {
            await Verify_ExistingFileAsync(file);

            await _context.AddAsync(file);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new RepositoryException(Constants.CreationError, ex);
        }
    }

    public async Task<bool> Edit_FileAsync(FileModel file)
    {
        try
        {
            var rowsAffected = await _context.Files
                .Where(f => f.Id == file.Id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(f => f.Fase, file.Fase)
                    .SetProperty(f => f.Status, file.Status)
                    .SetProperty(f => f.Start_Date, file.Start_Date)
                    .SetProperty(f => f.Finish_Date, file.Finish_Date)
                    .SetProperty(f => f.Project_Number, file.Project_Number)
                    .SetProperty(f => f.Section, file.Section)
                    .SetProperty(f => f.Km, file.Km)
                    .SetProperty(f => f.Comments, file.Comments));

            return rowsAffected > 0;
        }
        catch (Exception ex)
        {
            throw new RepositoryException(Constants.EditError, ex);
        }
    }

    public async Task<bool> Delete_FileAsync(int idFile)
    {
        try
        {
            var fileToDelete = await GetFile_ByIdAsync(idFile);

            if (fileToDelete == null)
                throw new RepositoryException(Constants.NoFileToDeleteError);

            _context.Files.Remove(fileToDelete);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex) 
        {
            throw new RepositoryException(Constants.DeletionError, ex);
        }
    }
}