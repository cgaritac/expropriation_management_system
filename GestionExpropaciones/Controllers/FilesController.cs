using System.Diagnostics;
using GestionExpropaciones.Models;
using GestionExpropaciones.Interfaces.IServices;
using GestionExpropaciones.Common;
using GestionExpropaciones.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GestionExpropaciones.Controllers;

public class FilesController(IFileService fileService, IProjectService projectService) : Controller
{
    private readonly IFileService _fileService = fileService;
    private readonly IProjectService _projectService = projectService;

    [Authorize]
    [HttpGet]
    public async Task<ActionResult> Index(int pageNumber = 1, string searchTerm = "")
    {
        var response = await _fileService.GetFileList_Pagination_SearchAsync(pageNumber, searchTerm);

        ViewBag.PageNumber = pageNumber;
        ViewBag.TotalPages = response.TotalPages; 
        ViewBag.SearchTerm = searchTerm;
        ViewBag.TotalCount = response.TotalCount;

        return View(response.Items);
    }

    [HttpGet]
    public async Task<ActionResult> Create()
    {
        var projectList = await _projectService.GetProjectListAsync();

        ViewBag.ProjectList = projectList;

        return View(new FileModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(FileModel file)
    {
        if (!ModelState.IsValid)
        {
            return View(file);
        }

        try
        {
            await _fileService.Create_FileAsync(file);
            
            TempData["ToastMessage"] = "success";
            TempData["ToastText"] = Constants.FileCreationSuccess;

            return RedirectToAction(nameof(Index));
        }
        catch (RepositoryException rex)
        {
            TempData["ToastMessage"] = "error";
            TempData["ToastText"] = rex.Message;

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex) 
        {                
            TempData["ToastMessage"] = "error";
            TempData["ToastText"] = Constants.FileCreationError + ex.Message;

            return RedirectToAction(nameof(Index));
        }                      
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit([FromForm] FileModel file)
    {
        try
        {
            await _fileService.Edit_FileAsync(file);

            TempData["ToastMessage"] = "success";
            TempData["ToastText"] = Constants.FileEditSuccess;

            return RedirectToAction(nameof(Index));
        }
        catch (RepositoryException rex)
        {
            TempData["ToastMessage"] = "error";
            TempData["ToastText"] = rex.Message;

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            TempData["ToastMessage"] = "error";
            TempData["ToastText"] = Constants.FileEditError + ex.Message;

            return RedirectToAction(nameof(Index));
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _fileService.Delete_FileAsync(id);

            TempData["ToastMessage"] = "success";
            TempData["ToastText"] = Constants.FileDeletionSuccess;

            return RedirectToAction(nameof(Index));
        }
        catch (RepositoryException rex)
        {
            TempData["ToastMessage"] = "error";
            TempData["ToastText"] = rex.Message;

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            TempData["ToastMessage"] = "error";
            TempData["ToastText"] = Constants.FileDeletionError + ex.Message;

            return RedirectToAction(nameof(Index));
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
