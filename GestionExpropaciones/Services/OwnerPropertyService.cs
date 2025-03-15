using GestionExpropaciones.Models;
using GestionExpropaciones.Interfaces.IRepositories;
using GestionExpropaciones.Interfaces.IServices;
using GestionExpropaciones.Common;
using GestionExpropaciones.Repositories;

namespace GestionExpropaciones.Services;

public class OwnerPropertyService(IOwnerPropertyRepository ownerPropertyRepository, IUserService userService) : IOwnerPropertyService
{
    private readonly IOwnerPropertyRepository _ownerPropertyRepository = ownerPropertyRepository;
    private readonly IUserService _userservice = userService;

    public async Task<PageResponseModel<OwnerPropertyModel>> GetOwnerPropertyList_Pagination_SearchAsync(int pageNumber, string searchTerm)
    {
        var ownerPropertyList = await _ownerPropertyRepository.GetOwnerPropertyList_Pagination_SearchAsync(pageNumber, searchTerm);
        var Count = await _ownerPropertyRepository.GetOwnerProperty_TotalCountAsync(searchTerm);

        var pageResponse = new PageResponseModel<OwnerPropertyModel>(
            items: ownerPropertyList,
            totalCount: Count,
            page: pageNumber,
            pageSize: Constants.PageSize
        );

        return pageResponse;
    }
}
