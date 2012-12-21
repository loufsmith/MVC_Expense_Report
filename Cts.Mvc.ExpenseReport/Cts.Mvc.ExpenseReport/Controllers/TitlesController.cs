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
    public class TitlesController : Controller
    {
        private ExpenseReportContext db = new ExpenseReportContext();

        //
        // GET: /Titles/

        public ActionResult Index()
        {
            return View(db.Titles.ToList());
        }

        //
        // GET: /Titles/Details/5

        public ActionResult Details(int id = 0)
        {
            Titles titles = db.Titles.Find(id);
            if (titles == null)
            {
                return HttpNotFound();
            }
            return View(titles);
        }

        //
        // GET: /Titles/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Titles/Create

        [HttpPost]
        public ActionResult Create(Titles titles)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Titles.Add(titles);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.  Please try again.  If the problem persists, then contact your system administrator.");
            }

            return View(titles);
        }

        //
        // GET: /Titles/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Titles titles = db.Titles.Find(id);
            if (titles == null)
            {
                return HttpNotFound();
            }
            return View(titles);
        }

        //
        // POST: /Titles/Edit/5

        [HttpPost]
        public ActionResult Edit(Titles titles)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(titles).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.  Please try again.  If the problem persists, then contact your system administrator.");
            }
            return View(titles);
        }

        //
        // GET: /Titles/Delete/5

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            //Titles titles = db.Titles.Find(id);
            //if (titles == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(titles);
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Please try again.  If the problem persists contact your system administrator";
            }
            return View(db.Titles.Find(id));
        }

        //
        // POST: /Titles/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var entries = db.Employees.Where(x => x.TitlesID == id).Count();

                if (entries > 0)
                {
                    ViewBag.ErrorMessage = "Unable to delete Title. Please remove all Employee entries related to this title and try again.";
                    return View(db.Titles.Find(id));
                }
                else
                {
                    Titles itemToDelete = new Titles() { TitlesID = id };
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