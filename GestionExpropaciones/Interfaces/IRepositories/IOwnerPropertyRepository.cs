using GestionExpropaciones.Models;

namespace GestionExpropaciones.Interfaces.IRepositories;

public interface IOwnerPropertyRepository
{
    Task<List<OwnerPropertyModel>> GetOwnerPropertyList_Pagination_SearchAsync(int pageNumber, string searchTerm);
    Task<int> GetOwnerProperty_TotalCountAsync(string searchTerm);
}
