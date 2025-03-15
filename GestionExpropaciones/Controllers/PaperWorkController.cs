using GestionExpropaciones.Interfaces.IServices;
using GestionExpropaciones.Common;
using GestionExpropaciones.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GestionExpropaciones.Controllers;

public class PaperWorkController : Controller
{
    // GET: LegalDataController
    public ActionResult Index()
    {
        return View();
    }

    // GET: LegalDataController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: LegalDataController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: LegalDataController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
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

    // GET: LegalDataController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: LegalDataController/Edit/5
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

    // GET: LegalDataController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: LegalDataController/Delete/5
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
