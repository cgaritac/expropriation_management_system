using GestionExpropaciones.Common.Exceptions;
using GestionExpropaciones.Common;
using GestionExpropaciones.Data;
using GestionExpropaciones.Interfaces.IRepositories;
using GestionExpropaciones.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionExpropaciones.Repositories;

public class ProjectRepository(AppDbContext context) : IProjectRepository
{
    private readonly AppDbContext _context = context;

    public async Task Verify_ExistingProjectAsync(ProjectModel project)
    {
        var existingProject = await _context.Project
            .FirstOrDefaultAsync(f => f.Number == project.Number);

        if (existingProject != null)
            throw new RepositoryException(Constants.ProjectNumberExistanceError);
    }

    public async Task<ProjectModel?> GetProject_ByIdAsync(int idProject)
    {
        var project = await _context.Project
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Id == idProject && f.Is_Active);

        return project;
    }

    public async Task<List<ProjectModel>> GetProjectListAsync()
    {
        var projectList = await _context.Project
            .Where(f => f.Is_Active)
            .ToListAsync(); 

        return projectList;
    }

    public async Task<List<ProjectModel>> GetProjectList_Pagination_SearchAsync(int pageNumber, string searchTerm)
    {
        var query = _context.Project
            .Where(f => f.Is_Active);


        query = Apply_SearchFilter(query, searchTerm);

        var projectList = await query
            .OrderDescending()
            .Skip((pageNumber - 1) * Constants.PageSize)
            .Take(Constants.PageSize)
            .ToListAsync();

        return projectList;
    }

    public async Task<int> GetProject_TotalCountAsync(string searchTerm)
    {
        var query = _context.Project
            .Where(f => f.Is_Active);

        query = Apply_SearchFilter(query, searchTerm);

        var totalCount = await query.CountAsync();

        return totalCount;
    }

    public IQueryable<ProjectModel> Apply_SearchFilter(IQueryable<ProjectModel> query, string searchTerm)
    {
        if (!string.IsNullOrEmpty(searchTerm))
        {
            searchTerm = searchTerm.ToLower();

            query = query.Where(f =>
                f.Is_Active &&
                (f.Id.ToString().Contains(searchTerm) ||
                f.Number.Contains(searchTerm)) //Falta incluir parámetros faltantes
            );
        }

        return query;
    }

    public async Task<bool> Create_ProjectAsync(ProjectModel project)
    {
        try
        {
            await Verify_ExistingProjectAsync(project);

            await _context.AddAsync(project);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new RepositoryException(Constants.CreationError, ex);
        }
    }

    public async Task<bool> Edit_ProjectAsync(ProjectModel project)
    {
        try
        {
            var rowsAffected = await _context.Project
                .Where(f => f.Id == project.Id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(f => f.Number, project.Number)
                    .SetProperty(f => f.Name, project.Name)
                    .SetProperty(f => f.Comments, project.Comments));

            return rowsAffected > 0;
        }
        catch (Exception ex)
        {
            throw new RepositoryException(Constants.EditError, ex);
        }
    }

    public async Task<bool> Delete_ProjectAsync(int idProject)
    {
        try
        {
            var projectToDelete = await GetProject_ByIdAsync(idProject);

            if (projectToDelete == null)
                throw new RepositoryException(Constants.NoOwnerToDeleteError);

            _context.Project.Remove(projectToDelete);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new RepositoryException(Constants.DeletionError, ex);
        }
    }
}
