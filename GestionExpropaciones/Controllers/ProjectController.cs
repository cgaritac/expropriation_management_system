using GestionExpropaciones.Common.Exceptions;
using GestionExpropaciones.Common;
using GestionExpropaciones.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GestionExpropaciones.Interfaces.IServices;

namespace GestionExpropaciones.Controllers;

[Authorize]
public class ProjectController(IProjectService projectService) : Controller
{
    private readonly IProjectService _projectService = projectService;

    [HttpGet]
    public async Task<ActionResult> Index(int pageNumber = 1, string searchTerm = "")
    {
        var response = await _projectService.GetProjectList_Pagination_SearchAsync(pageNumber, searchTerm);

        ViewBag.PageNumber = pageNumber;
        ViewBag.TotalPages = response.TotalPages;
        ViewBag.SearchTerm = searchTerm;
        ViewBag.TotalCount = response.TotalCount;

        return View(response.Items);
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View(new ProjectModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(ProjectModel project)
    {
        if (!ModelState.IsValid)
        {
            return View(project);
        }

        try
        {
            await _projectService.Create_ProjectAsync(project);

            TempData["ToastMessage"] = "success";
            TempData["ToastText"] = Constants.ProjectCreationSuccess;

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
            TempData["ToastText"] = Constants.ProjectCreationError + ex.Message;

            return RedirectToAction(nameof(Index));
        }
    }

    public async Task<ActionResult> Edit(int id)
    {
        var project = await _projectService.GetProject_ByIdAsync(id);

        return View(project);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit([FromForm] ProjectModel project)
    {
        try
        {
            await _projectService.Edit_ProjectAsync(project);

            TempData["ToastMessage"] = "success";
            TempData["ToastText"] = Constants.ProjectEditSuccess;

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
            TempData["ToastText"] = Constants.ProjectEditError + ex.Message;

            return RedirectToAction(nameof(Index));
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _projectService.Delete_ProjectAsync(id);

            TempData["ToastMessage"] = "success";
            TempData["ToastText"] = Constants.ProjectDeletionSuccess;

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
            TempData["ToastText"] = Constants.ProjectDeletionError + ex.Message;

            return RedirectToAction(nameof(Index));
        }
    }
}
