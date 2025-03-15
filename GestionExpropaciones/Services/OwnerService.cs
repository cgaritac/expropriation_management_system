using GestionExpropaciones.Models;
using GestionExpropaciones.Interfaces.IRepositories;
using GestionExpropaciones.Interfaces.IServices;
using GestionExpropaciones.Common;

namespace GestionExpropaciones.Services;

public class OwnerService(IOwnerRepository ownerRepository, IUserService userService) : IOwnerService
{
    private readonly IOwnerRepository _ownerRepository = ownerRepository;
    private readonly IUserService _userservice = userService;

    public async Task<OwnerModel?> GetOwner_ByIdAsync(int idOwner)
    {
        return await _ownerRepository.GetOwner_ByIdAsync(idOwner);
    }

    public async Task<List<OwnerModel>> GetOwnerListAsync()
    {
        return await _ownerRepository.GetOwnerListAsync();
    }

    public async Task<PageResponseModel<OwnerModel>> GetOwnerList_Pagination_SearchAsync(int pageNumber, string searchTerm)
    {
        var ownerList = await _ownerRepository.GetOwnerList_Pagination_SearchAsync(pageNumber, searchTerm);
        var Count = await _ownerRepository.GetOwner_TotalCountAsync(searchTerm);

        var pageResponse = new PageResponseModel<OwnerModel>(
            items: ownerList,
            totalCount: Count,
            page: pageNumber,
            pageSize: Constants.PageSize
        );

        return pageResponse;
    }

    public async Task<bool> Create_OwnerAsync(OwnerModel owner)
    {
        var user = _userservice.GetUserEmail();

        owner.SetCreationInfo(user);

        return await _ownerRepository.Create_OwnerAsync(owner);
    }

    public async Task<bool> Edit_OwnerAsync(OwnerModel owner)
    {
        return await _ownerRepository.Edit_OwnerAsync(owner);
    }

    public async Task<bool> Delete_OwnerAsync(int idOwner)
    {
        return await _ownerRepository.Delete_OwnerAsync(idOwner);
    }
}
