using System.Linq;
using System.Web.Mvc;
using SlarkInc.DAL;
using System;
using PagedList;
using SlarkInc.Models;
using System.Data;

namespace SlarkInc.Controllers
{
    public class CompanyController : Controller
    {
        private CompanyContext db = new CompanyContext();
        public ViewResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "first_desc" : "";
            ViewBag.LastNameSortParm = sortOrder == "last" ? "last_desc" : "last";
            if(searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var workers = from w in db.Workers
                        select w;
            if (!string.IsNullOrEmpty(searchString))
            {
                workers = workers.Where(w => w.FirstName.Contains(searchString)
                                        || w.LastName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "first_desc":
                    workers = workers.OrderByDescending(w => w.FirstName);
                    break;
                case "last_desc":
                    workers = workers.OrderByDescending(w => w.LastName);
                    break;
                case "last":
                    workers = workers.OrderBy(w => w.LastName);
                    break;
                default:
                    workers = workers.OrderBy(w => w.FirstName);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(workers.ToPagedList(pageNumber,pageSize));
        }

        public ViewResult Create()
        {
            return View();
        }

[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create([Bind(Include = "FirstName, LastName, Sex, Rating")] Worker worker)
{
    try
    {
        if (ModelState.IsValid)
        {
            db.Workers.Add(worker);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    catch (DataException /* dex */)
    {
        ModelState.AddModelError("","Unable to save changes.Try again, and if the problem persists see your system administrator.");
    }
    return View(worker);
}
	}
}