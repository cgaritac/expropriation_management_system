using GestionExpropaciones.Models;

namespace GestionExpropaciones.Interfaces.IRepositories;

public interface IProjectRepository
{
    Task<ProjectModel?> GetProject_ByIdAsync(int idProject);
    Task<List<ProjectModel>> GetProjectListAsync();
    Task<List<ProjectModel>> GetProjectList_Pagination_SearchAsync(int pageNumber, string searchTerm);
    Task<int> GetProject_TotalCountAsync(string searchTerm);
    Task<bool> Create_ProjectAsync(ProjectModel project);
    Task<bool> Edit_ProjectAsync(ProjectModel project);
    Task<bool> Delete_ProjectAsync(int idProject);
}
