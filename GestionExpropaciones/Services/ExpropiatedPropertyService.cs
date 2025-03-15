using GestionExpropaciones.Models;
using GestionExpropaciones.Interfaces.IRepositories;
using GestionExpropaciones.Interfaces.IServices;
using GestionExpropaciones.Common;

namespace GestionExpropaciones.Services;

public class ExpropiatedPropertyService(IExpropiatedPropertyRepository expropiatedPropertyRepository, IUserService userService) : IExpropiatedPropertyService
{
    private readonly IExpropiatedPropertyRepository _expropiatedPropertyRepository = expropiatedPropertyRepository;
    private readonly IUserService _userservice = userService;

    public async Task<PageResponseModel<ExpropiatedPropertyModel>> GetExpropiatedPropertyList_Pagination_SearchAsync(int pageNumber, string searchTerm)
    {
        var expropiatedPropertyList = await _expropiatedPropertyRepository.GetExpropiatedPropertyList_Pagination_SearchAsync(pageNumber, searchTerm);
        var Count = await _expropiatedPropertyRepository.GetExpropiatedProperty_TotalCountAsync(searchTerm);

        var pageResponse = new PageResponseModel<ExpropiatedPropertyModel>(
            items: expropiatedPropertyList,
            totalCount: Count,
            page: pageNumber,
            pageSize: Constants.PageSize
        );

        return pageResponse;
    }
}
