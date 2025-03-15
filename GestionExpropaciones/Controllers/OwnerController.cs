using GestionExpropaciones.Common.Exceptions;
using GestionExpropaciones.Models;
using GestionExpropaciones.Interfaces.IServices;
using GestionExpropaciones.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GestionExpropaciones.Controllers;

[Authorize]
public class OwnerController(IOwnerService ownerService) : Controller
{
    private readonly IOwnerService _ownerService = ownerService;

    // GET: OwnerController
    public ActionResult Index()
    {
        return View();
    }

    // GET: OwnerController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    [HttpGet]
    public ActionResult Create(int fileId)
    {
        ViewBag.FileId = fileId;

        return View(new OwnerModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(OwnerModel owner)
    {
        if (!ModelState.IsValid)
        {
            return View(owner);
        }

        try
        {
            await _ownerService.Create_OwnerAsync(owner);

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

    // GET: OwnerController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: OwnerController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: OwnerController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: OwnerController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
