using GestionExpropaciones.Models;

namespace GestionExpropaciones.Interfaces.IRepositories;

public interface IOwnerRepository
{
    Task<OwnerModel?> GetOwner_ByIdAsync(int idOwner);
    Task<List<OwnerModel>> GetOwnerListAsync();
    Task<List<OwnerModel>> GetOwnerList_Pagination_SearchAsync(int pageNumber, string searchTerm);
    Task<int> GetOwner_TotalCountAsync(string searchTerm);
    Task<bool> Create_OwnerAsync(OwnerModel owner);
    Task<bool> Edit_OwnerAsync(OwnerModel owner);
    Task<bool> Delete_OwnerAsync(int idOwner);
}
