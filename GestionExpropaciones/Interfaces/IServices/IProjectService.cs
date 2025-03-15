using GestionExpropaciones.Models;

namespace GestionExpropaciones.Interfaces.IServices;

public interface IProjectService
{
    Task<ProjectModel?> GetProject_ByIdAsync(int idProject);
    Task<List<ProjectModel>> GetProjectListAsync();
    Task<PageResponseModel<ProjectModel>> GetProjectList_Pagination_SearchAsync(int pageNumber, string searchTerm);
    Task<bool> Create_ProjectAsync(ProjectModel project);
    Task<bool> Edit_ProjectAsync(ProjectModel project);
    Task<bool> Delete_ProjectAsync(int idProject);
}
