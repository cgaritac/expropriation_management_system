using GestionExpropaciones.Interfaces.IServices;
using GestionExpropaciones.Common;
using GestionExpropaciones.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GestionExpropaciones.Controllers;

public class AppraisalController : Controller
{
    // GET: FinanceDataController
    public ActionResult Index()
    {
        return View();
    }

    // GET: FinanceDataController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: FinanceDataController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: FinanceDataController/Create
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

    // GET: FinanceDataController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: FinanceDataController/Edit/5
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

    // GET: FinanceDataController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: FinanceDataController/Delete/5
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
