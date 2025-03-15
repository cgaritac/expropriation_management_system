using GestionExpropaciones.Models;
using GestionExpropaciones.Interfaces.IRepositories;
using GestionExpropaciones.Interfaces.IServices;
using GestionExpropaciones.Common;
using GestionExpropaciones.Repositories;

namespace GestionExpropaciones.Services;

public class PaperWorkService(IPaperWorkRepository paperWorkRepository, IUserService userService) : IPaperWorkService
{
    private readonly IPaperWorkRepository _paperWorkRepository = paperWorkRepository;
    private readonly IUserService _userservice = userService;

    public async Task<PageResponseModel<PaperWorkModel>> GetPaperWorkList_Pagination_SearchAsync(int pageNumber, string searchTerm)
    {
        var paperWorkList = await _paperWorkRepository.GetPaperWorkList_Pagination_SearchAsync(pageNumber, searchTerm);
        var Count = await _paperWorkRepository.GetPaperWork_TotalCountAsync(searchTerm);

        var pageResponse = new PageResponseModel<PaperWorkModel>(
            items: paperWorkList,
            totalCount: Count,
            page: pageNumber,
            pageSize: Constants.PageSize
        );

        return pageResponse;
    }
}
