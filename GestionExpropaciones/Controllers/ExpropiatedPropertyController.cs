using GestionExpropaciones.Interfaces.IServices;
using GestionExpropaciones.Common;
using GestionExpropaciones.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GestionExpropaciones.Controllers;

public class ExpropiatedPropertyController : Controller
{
    // GET: ExpropiatedPropertyController
    public ActionResult Index()
    {
        return View();
    }

    // GET: ExpropiatedPropertyController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: ExpropiatedPropertyController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: ExpropiatedPropertyController/Create
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

    // GET: ExpropiatedPropertyController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: ExpropiatedPropertyController/Edit/5
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

    // GET: ExpropiatedPropertyController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: ExpropiatedPropertyController/Delete/5
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
