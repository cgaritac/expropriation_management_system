using GestionExpropaciones.Models;

namespace GestionExpropaciones.Interfaces.IServices;

public interface IOwnerPropertyService
{
    Task<PageResponseModel<OwnerPropertyModel>> GetOwnerPropertyList_Pagination_SearchAsync(int pageNumber, string searchTerm);
}
