using GestionExpropaciones.Models;

namespace GestionExpropaciones.Interfaces.IServices;

public interface IExpropiatedPropertyService
{
    Task<PageResponseModel<ExpropiatedPropertyModel>> GetExpropiatedPropertyList_Pagination_SearchAsync(int pageNumber, string searchTerm);
}
