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
    [Authorize(Roles = "Admin, Accountant")]
    public class ExpenseCategoriesController : Controller
    {
        private ExpenseReportContext db = new ExpenseReportContext();

        //
        // GET: /ExpenseCategories/

        public ActionResult Index()
        {
            return View(db.ExpenseCategories.ToList());
        }

        //
        // GET: /ExpenseCategories/Details/5

        public ActionResult Details(int id = 0)
        {
            ExpenseCategories expensecategories = db.ExpenseCategories.Find(id);
            if (expensecategories == null)
            {
                return HttpNotFound();
            }
            return View(expensecategories);
        }

        //
        // GET: /ExpenseCategories/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ExpenseCategories/Create

        [HttpPost]
        public ActionResult Create(ExpenseCategories expensecategories)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.ExpenseCategories.Add(expensecategories);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.  Please try again.  If the problem persists, then contact your system administrator.");
            }

            return View(expensecategories);
        }

        //
        // GET: /ExpenseCategories/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ExpenseCategories expensecategories = db.ExpenseCategories.Find(id);
            if (expensecategories == null)
            {
                return HttpNotFound();
            }
            return View(expensecategories);
        }

        //
        // POST: /ExpenseCategories/Edit/5

        [HttpPost]
        public ActionResult Edit(ExpenseCategories expensecategories)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(expensecategories).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.  Please try again.  If the problem persists, then contact your system administrator.");
            }
            return View(expensecategories);
        }

        //
        // GET: /ExpenseCategories/Delete/5

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            //ExpenseCategories expensecategories = db.ExpenseCategories.Find(id);
            //if (expensecategories == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(expensecategories);
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Please try again.  If the problem persists contact your system administrator";
            }
            return View(db.ExpenseCategories.Find(id));
        }

        //
        // POST: /ExpenseCategories/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var entries = db.Entries.Where(x => x.ExpenseCategoriesID == id).Count();

                if (entries > 0)
                {
                    ViewBag.ErrorMessage = "Unable to delete Expense Category. Please remove all Expense Report entries related to this category and try again.";
                    return View(db.ExpenseCategories.Find(id));
                }
                else
                {

                    ExpenseCategories itemToDelete = new ExpenseCategories() { ExpenseCategoriesID = id };
                    db.Entry(itemToDelete).State = EntityState.Deleted;
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