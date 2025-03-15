using GestionExpropaciones.Models;

namespace GestionExpropaciones.Interfaces.IServices;

public interface IAppraisalService
{
    Task<PageResponseModel<AppraisalModel>> GetAppraisalList_Pagination_SearchAsync(int pageNumber, string searchTerm);
}
