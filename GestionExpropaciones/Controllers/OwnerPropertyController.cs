using GestionExpropaciones.Interfaces.IServices;
using GestionExpropaciones.Common;
using GestionExpropaciones.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GestionExpropaciones.Controllers;

public class OwnerPropertyController : Controller
{
    // GET: CadastralMapController
    public ActionResult Index()
    {
        return View();
    }

    // GET: CadastralMapController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: CadastralMapController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: CadastralMapController/Create
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

    // GET: CadastralMapController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: CadastralMapController/Edit/5
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

    // GET: CadastralMapController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: CadastralMapController/Delete/5
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
