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
    public class BusinessReasonsController : Controller
    {
        private ExpenseReportContext db = new ExpenseReportContext();

        //
        // GET: /BusinessReasons/

        public ActionResult Index()
        {
            return View(db.BusinessReasons.ToList());
        }

        //
        // GET: /BusinessReasons/Details/5

        public ActionResult Details(int id = 0)
        {
            BusinessReasons businessreasons = db.BusinessReasons.Find(id);
            if (businessreasons == null)
            {
                return HttpNotFound();
            }
            return View(businessreasons);
        }

        //
        // GET: /BusinessReasons/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /BusinessReasons/Create

        [HttpPost]
        public ActionResult Create(BusinessReasons businessreasons)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.BusinessReasons.Add(businessreasons);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.  Please try again.  If the problem persists, then contact your system administrator.");
            }

            return View(businessreasons);
        }

        //
        // GET: /BusinessReasons/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BusinessReasons businessreasons = db.BusinessReasons.Find(id);
            if (businessreasons == null)
            {
                return HttpNotFound();
            }
            return View(businessreasons);
        }

        //
        // POST: /BusinessReasons/Edit/5

        [HttpPost]
        public ActionResult Edit(BusinessReasons businessreasons)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(businessreasons).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.  Please try again.  If the problem persists, then contact your system administrator.");
            }
            return View(businessreasons);
        }

        //
        // GET: /BusinessReasons/Delete/5

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Please try again.  If the problem persists contact your system administrator";
            }

            return View(db.BusinessReasons.Find(id));
        }

        //
        // POST: /BusinessReasons/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var entries = db.Entries.Where(x => x.BusinessReasonsID == id).Count();

                if (entries > 0)
                {
                    ViewBag.ErrorMessage = "Unable to delete Business Reason. Please remove all Expense Report entries related to this reason and try again.";
                    return View(db.BusinessReasons.Find(id));
                }
                else
                {
                    BusinessReasons itemToDelete = db.BusinessReasons.Find(id);
                    db.BusinessReasons.Remove(itemToDelete);
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