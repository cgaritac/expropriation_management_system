using Microsoft.AspNetCore.Mvc;
using GestionExpropaciones.Interfaces.IServices;

namespace GestionExpropaciones.Controllers;

public class MenuController(IFileService fileService, IProjectService projectService, IOwnerService ownerService, IPaperWorkService paperWorkService, IOwnerPropertyService ownerPropertyService, IAppraisalService appraisalService, IExpropiatedPropertyService expropiatedPropertyService) : Controller
{
    private readonly IFileService _fileService = fileService;
    private readonly IProjectService _projectService = projectService;
    private readonly IOwnerService _ownerService = ownerService;
    private readonly IPaperWorkService _paperWorkService = paperWorkService;
    private readonly IOwnerPropertyService _ownerPropertyService = ownerPropertyService;
    private readonly IAppraisalService _appraisalService = appraisalService;
    private readonly IExpropiatedPropertyService _expropiatedPropertyService = expropiatedPropertyService;

    [HttpGet]
    public async Task<IActionResult> Index(int id, int pageNumber = 1, string searchTerm = "")
    {
        ViewBag.PageNumber = pageNumber;
        ViewBag.SearchTerm = searchTerm;

        var file = await _fileService.GetFile_ByIdAsync(id);        

        if (file == null)
        {
            return NotFound();
        }

        var projectList = await _projectService.GetProjectListAsync();

        ViewBag.ProjectList = projectList;

        var ownerResponse = await _ownerService.GetOwnerList_Pagination_SearchAsync(pageNumber, searchTerm);

        ViewBag.Owners = ownerResponse.Items;
        ViewBag.OwnerTotalPages = ownerResponse.TotalPages;
        ViewBag.OwnerTotalCount = ownerResponse.TotalCount;

        var ownerPropertyResponse = await _ownerPropertyService.GetOwnerPropertyList_Pagination_SearchAsync(pageNumber, searchTerm);

        ViewBag.OwnerProperties = ownerPropertyResponse.Items;
        ViewBag.OwnerPropertyTotalPages = ownerPropertyResponse.TotalPages;
        ViewBag.OwnerPropertyTotalCount = ownerPropertyResponse.TotalCount;

        var paperWorkResponse = await _paperWorkService.GetPaperWorkList_Pagination_SearchAsync(pageNumber, searchTerm);

        ViewBag.PaperWorks = paperWorkResponse.Items;
        ViewBag.PaperWorkTotalPages = paperWorkResponse.TotalPages;
        ViewBag.PaperWorkTotalCount = paperWorkResponse.TotalCount;

        var appraisalResponse = await _appraisalService.GetAppraisalList_Pagination_SearchAsync(pageNumber, searchTerm);

        ViewBag.Appraisals = appraisalResponse.Items;
        ViewBag.AppraisalTotalPages = appraisalResponse.TotalPages;
        ViewBag.AppraisalTotalCount = appraisalResponse.TotalCount;

        var expropiatedPropertyResponse = await _expropiatedPropertyService.GetExpropiatedPropertyList_Pagination_SearchAsync(pageNumber, searchTerm);

        ViewBag.ExpropiatedProperties = expropiatedPropertyResponse.Items;
        ViewBag.ExpropiatedPropertyTotalPages = expropiatedPropertyResponse.TotalPages;
        ViewBag.ExpropiatedPropertyTotalCount = expropiatedPropertyResponse.TotalCount;

        return View(file);
    }
}