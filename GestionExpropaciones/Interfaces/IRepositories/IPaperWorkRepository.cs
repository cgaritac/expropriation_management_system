using GestionExpropaciones.Models;

namespace GestionExpropaciones.Interfaces.IRepositories;

public interface IPaperWorkRepository
{
    Task<List<PaperWorkModel>> GetPaperWorkList_Pagination_SearchAsync(int pageNumber, string searchTerm);
    Task<int> GetPaperWork_TotalCountAsync(string searchTerm);
}
