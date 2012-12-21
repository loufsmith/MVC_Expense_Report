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
    [Authorize(Roles = "Admin")]
    public class EmployeesController : Controller
    {
        private ExpenseReportContext db = new ExpenseReportContext();

        //
        // GET: /Employees/

        public ActionResult Index(string sortOrder = "Employee")
        {
            var employees = db.Employees.Include(i => i.Titles);


            switch (sortOrder)
            { 
                case "Employee":
                    employees = employees.OrderBy(s => s.LastName)
                        .ThenBy(s => s.FirstName);
                    break;
                case "EmployeeNum":
                    employees = employees.OrderBy(s => s.EmployeesID);
                    break;
            }



            return View(employees);
        }

        //
        // GET: /Employees/Details/5

        public ActionResult Details(int id = 0)
        {
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        //
        // GET: /Employees/Create

        public ActionResult Create()
        {
            ViewBag.TitleList = new SelectList(db.Titles, "TitlesID", "Title");
            return View();
        }

        //
        // POST: /Employees/Create

        [HttpPost]
        public ActionResult Create(Employees employees)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Employees.Add(employees);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.  Please try again.  If the problem persists, then contact your system administrator.");
            }

            return View(employees);
        }

        //
        // GET: /Employees/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.TitleList = new SelectList(db.Titles, "TitlesID", "Title", employees.TitlesID);

            return View(employees);
        }

        //
        // POST: /Employees/Edit/5

        [HttpPost]
        public ActionResult Edit(Employees employees)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(employees).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.  Please try again.  If the problem persists, then contact your system administrator.");
            }
            ViewBag.TitleList = new SelectList(db.Titles, "TitlesID", "Title", employees.TitlesID);
            return View(employees);
        }

        //
        // GET: /Employees/Delete/5
        [HttpGet]
        public ActionResult Delete(int id, bool? saveChangesError)
        {

            //Employees employees = db.Employees.Find(id);
            //if (employees == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(employees);
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Please try again.  If the problem persists contact your system administrator";
            }
            return View(db.Employees.Find(id));
        }

        //
        // POST: /Employees/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var entries = db.Entries.Where(x => x.EmployeesID == id).Count();

                if (entries > 0)
                {
                    ViewBag.ErrorMessage = "Unable to delete Employee. Please remove all Expense Report entries related to this employee and try again.";
                    return View(db.Employees.Find(id));
                }
                else
                {

                    Employees employee = new Employees() { EmployeesID = id };
                    db.Entry(employee).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                    new System.Web.Routing.RouteValueDictionary { 
                        {"id", id},
                        {"saveChangesError", true}
                    });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}