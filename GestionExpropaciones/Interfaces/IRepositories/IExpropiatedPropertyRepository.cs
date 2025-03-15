using GestionExpropaciones.Models;

namespace GestionExpropaciones.Interfaces.IRepositories;

public interface IExpropiatedPropertyRepository
{
    Task<List<ExpropiatedPropertyModel>> GetExpropiatedPropertyList_Pagination_SearchAsync(int pageNumber, string searchTerm);
    Task<int> GetExpropiatedProperty_TotalCountAsync(string searchTerm);
}
