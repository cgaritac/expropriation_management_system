using GestionExpropaciones.Interfaces.IRepositories;
using GestionExpropaciones.Interfaces.IServices;
using GestionExpropaciones.Models;
using GestionExpropaciones.Common;

namespace GestionExpropaciones.Services;

public class ProjectService(IProjectRepository projectRepository, IUserService userService) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IUserService _userservice = userService;

    public async Task<ProjectModel?> GetProject_ByIdAsync(int idProject)
    {
        return await _projectRepository.GetProject_ByIdAsync(idProject);
    }

    public async Task<List<ProjectModel>> GetProjectListAsync()
    {        
        return await _projectRepository.GetProjectListAsync();
    }

    public async Task<PageResponseModel<ProjectModel>> GetProjectList_Pagination_SearchAsync(int pageNumber, string searchTerm)
    {
        var projectList = await _projectRepository.GetProjectList_Pagination_SearchAsync(pageNumber, searchTerm);
        var Count = await _projectRepository.GetProject_TotalCountAsync(searchTerm);

        var pageResponse = new PageResponseModel<ProjectModel>(
            items: projectList,
            totalCount: Count,
            page: pageNumber,
            pageSize: Constants.PageSize
        );

        return pageResponse;
    }

    public async Task<bool> Create_ProjectAsync(ProjectModel project)
    {
        var user = _userservice.GetUserEmail();

        project.SetCreationInfo(user);

        return await _projectRepository.Create_ProjectAsync(project);
    }

    public async Task<bool> Edit_ProjectAsync(ProjectModel project)
    {
        return await _projectRepository.Edit_ProjectAsync(project);
    }

    public async Task<bool> Delete_ProjectAsync(int idProject)
    {
        return await _projectRepository.Delete_ProjectAsync(idProject);
    }
}
