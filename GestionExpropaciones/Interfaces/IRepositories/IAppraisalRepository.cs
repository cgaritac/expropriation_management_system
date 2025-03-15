using GestionExpropaciones.Models;

namespace GestionExpropaciones.Interfaces.IRepositories;

public interface IAppraisalRepository
{
    Task<List<AppraisalModel>> GetAppraisalList_Pagination_SearchAsync(int pageNumber, string searchTerm);
    Task<int> GetAppraisal_TotalCountAsync(string searchTerm);
}
