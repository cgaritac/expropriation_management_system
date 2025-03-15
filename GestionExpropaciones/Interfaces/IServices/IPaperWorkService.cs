

using GestionExpropaciones.Models;

namespace GestionExpropaciones.Interfaces.IServices;

public interface IPaperWorkService
{
    Task<PageResponseModel<PaperWorkModel>> GetPaperWorkList_Pagination_SearchAsync(int pageNumber, string searchTerm);
}
