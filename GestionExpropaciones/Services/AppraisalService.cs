using GestionExpropaciones.Models;
using GestionExpropaciones.Interfaces.IRepositories;
using GestionExpropaciones.Interfaces.IServices;
using GestionExpropaciones.Common;

namespace GestionExpropaciones.Services;

public class AppraisalService(IAppraisalRepository appraisalRepository, IUserService userService) : IAppraisalService
{
    private readonly IAppraisalRepository _appraisalRepository = appraisalRepository;
    private readonly IUserService _userservice = userService;

    public async Task<PageResponseModel<AppraisalModel>> GetAppraisalList_Pagination_SearchAsync(int pageNumber, string searchTerm)
    {
        var appraisalList = await _appraisalRepository.GetAppraisalList_Pagination_SearchAsync(pageNumber, searchTerm);
        var Count = await _appraisalRepository.GetAppraisal_TotalCountAsync(searchTerm);

        var pageResponse = new PageResponseModel<AppraisalModel>(
            items: appraisalList,
            totalCount: Count,
            page: pageNumber,
            pageSize: Constants.PageSize
        );

        return pageResponse;
    }
}
