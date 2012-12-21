using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cts.Mvc.ExpenseReport.Domain;
using Cts.Mvc.ExpenseReport.DAL;

namespace Cts.Mvc.ExpenseReport.Controllers
{
    public class EntriesController : Controller
    {
        private ExpenseReportContext db = new ExpenseReportContext();

        public ViewResult Index()
        {

            ViewBag.EmployeesList = new SelectList(db.Employees, "EmployeesID", "FullName");
            //return View();
            //EntriesByEmployee(0, DateTime.Today, DateTime.Today);
            var entries = db.Entries.OrderBy(x => x.DateIncurred);
            //return View(db.Entries.AsEnumerable());
            return View(entries.AsEnumerable());
        }

        // GET: /Entries/Details/5
        [HttpGet]
        public ActionResult Details(int id = 0)
        {
            Entries entries = db.Entries.Find(id);
            if (entries == null)
            {
                return HttpNotFound();
            }
            return View(entries);
        }

        //
        // GET: /Entries/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.EmployeesList = new SelectList(db.Employees, "EmployeesID", "FullName");
            ViewBag.ProjectsList = new SelectList(db.Projects, "ProjectsID", "Project");
            ViewBag.ExpenseCategoryList = new SelectList(db.ExpenseCategories, "ExpenseCategoriesID", "Category");
            ViewBag.BusinessReasonList = new SelectList(db.BusinessReasons, "BusinessReasonsID", "Reason");

            Entries entry = new Entries();
            entry.Mileage = 0;
            entry.Amount = 0;
            entry.NumPeople = 0;
            entry.DateIncurred = DateTime.Today;


            return View(entry);
        }

        //
        // POST: /Entries/Create
        [HttpPost]
        public ActionResult Create(Entries entries)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entries.Add(entries);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes.  Please try again.  If the problem persists, then contact your system administrator.");
            }

            return View(entries);
        }

        //
        // GET: /Entries/Edit/5
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            Entries entries = db.Entries.Find(id);
            if (entries == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeesList = new SelectList(db.Employees, "EmployeesID", "FullName", entries.EmployeesID);
            ViewBag.ProjectsList = new SelectList(db.Projects, "ProjectsID", "Project", entries.ProjectsID);
            ViewBag.ExpenseCategoryList = new SelectList(db.ExpenseCategories, "ExpenseCategoriesID", "Category", entries.ExpenseCategoriesID);
            ViewBag.BusinessReasonList = new SelectList(db.BusinessReasons, "BusinessReasonsID", "Reason", entries.BusinessReasonsID);

            return View(entries);
        }

        //
        // POST: /Entries/Edit/5
        [HttpPost]
        public ActionResult Edit(Entries entries)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(entries).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.  Please try again.  If the problem persists, then contact your system administrator.");
            }

            return View(entries);
        }

        //
        // GET: /Entries/Delete/5
        [HttpGet]
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            Entries entries = db.Entries.Find(id);
            //if (entries == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(entries);
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Please try again.  If the problem persists contact your system administrator";
            }

            return View(entries);
        }

        //
        // POST: /Entries/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Entries entries = db.Entries.Find(id);
                    //db.Entries.Remove(entries);
                    Entries entry = new Entries() { EntriesID = id };
                    db.Entry(entry).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                    new System.Web.Routing.RouteValueDictionary
                            {
                                {"id", id},
                                {"saveChangesError", true}
                            });
            }

            return RedirectToAction("Index");
        }

        public PartialViewResult EntriesByEmployee(DateTime? fromDate, DateTime? toDate, int id)
        {
            if (!fromDate.HasValue)
            {
                fromDate = Convert.ToDateTime("1/1/2000");
            }
            if (!toDate.HasValue)
            {
                toDate = Convert.ToDateTime("12/31/3000");
            }
            
            var m = db.Entries
                    .Where(x => x.EmployeesID == id && x.DateIncurred > fromDate && x.DateIncurred < toDate)
                    .OrderBy(r => r.DateIncurred)
                    .ThenBy(r => r.EntriesID)
                    .ToArray();
 
            return PartialView(m);
            
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}