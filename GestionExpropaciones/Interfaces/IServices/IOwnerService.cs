using GestionExpropaciones.Models;

namespace GestionExpropaciones.Interfaces.IServices;

public interface IOwnerService
{
    Task<OwnerModel?> GetOwner_ByIdAsync(int idOwner);
    Task<List<OwnerModel>> GetOwnerListAsync();
    Task<PageResponseModel<OwnerModel>> GetOwnerList_Pagination_SearchAsync(int pageNumber, string searchTerm);
    Task<bool> Create_OwnerAsync(OwnerModel owner);
    Task<bool> Edit_OwnerAsync(OwnerModel owner);
    Task<bool> Delete_OwnerAsync(int idOwner);
}
