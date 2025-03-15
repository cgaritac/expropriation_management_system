using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionExpropaciones.Controllers;

public class ReportsController : Controller
{
    // GET: ReportsController
    public ActionResult Index()
    {
        return View();
    }

    // GET: ReportsController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: ReportsController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: ReportsController/Create
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

    // GET: ReportsController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: ReportsController/Edit/5
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

    // GET: ReportsController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: ReportsController/Delete/5
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
