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
    [Authorize(Roles = "*")]
    public class ExpensesController : Controller
    {
        private ExpenseReportContext db = new ExpenseReportContext();

        //
        // GET: /Expenses/

        public ActionResult Index()
        {
            return View(db.Expenses.ToList());
        }

        //
        // GET: /Expenses/Details/5

        public ActionResult Details(int id = 0)
        {
            Expenses expenses = db.Expenses.Find(id);
            if (expenses == null)
            {
                return HttpNotFound();
            }
            return View(expenses);
        }

        //
        // GET: /Expenses/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Expenses/Create

        [HttpPost]
        public ActionResult Create(Expenses expenses)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Expenses.Add(expenses);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.  Please try again.  If the problem persists, then contact your system administrator.");
            }

            return View(expenses);
        }

        //
        // GET: /Expenses/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Expenses expenses = db.Expenses.Find(id);
            if (expenses == null)
            {
                return HttpNotFound();
            }
            return View(expenses);
        }

        //
        // POST: /Expenses/Edit/5

        [HttpPost]
        public ActionResult Edit(Expenses expenses)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(expenses).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.  Please try again.  If the problem persists, then contact your system administrator.");
            }
            return View(expenses);
        }

        //
        // GET: /Expenses/Delete/5

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            //Expenses expenses = db.Expenses.Find(id);
            //if (expenses == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(expenses);
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Please try again.  If the problem persists contact your system administrator";
            }
            return View(db.Expenses.Find(id));
        }

        //
        // POST: /Expenses/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                //Expenses expenses = db.Expenses.Find(id);
                //db.Expenses.Remove(expenses);
                Expenses itemToDelete = new Expenses() { ExpensesID = id };
                db.Entry(itemToDelete).State = EntityState.Deleted;
                db.SaveChanges();
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