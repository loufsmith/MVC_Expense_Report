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
    public class ClientsController : Controller
    {
        private ExpenseReportContext db = new ExpenseReportContext();

        //
        // GET: /Clients/

        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        //
        // GET: /Clients/Details/5

        public ActionResult Details(int id = 0)
        {
            Clients clients = db.Clients.Find(id);
            if (clients == null)
            {
                return HttpNotFound();
            }
            return View(clients);
        }

        //
        // GET: /Clients/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Clients/Create

        [HttpPost]
        public ActionResult Create(Clients clients)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Clients.Add(clients);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.  Please try again.  If the problem persists, then contact your system administrator.");
            }

            return View(clients);
        }

        //
        // GET: /Clients/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Clients clients = db.Clients.Find(id);
            if (clients == null)
            {
                return HttpNotFound();
            }
            return View(clients);
        }

        //
        // POST: /Clients/Edit/5

        [HttpPost]
        public ActionResult Edit(Clients clients)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clients).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clients);
        }

        //
        // GET: /Clients/Delete/5

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            //Clients clients = db.Clients.Find(id);
            //if (clients == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(clients);
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Please try again.  If the problem persists contact your system administrator";
            }
            return View(db.Clients.Find(id));
        }

        //
        // POST: /Clients/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var projects = db.Projects.Where(p => p.ClientsID == id).Count();

                if (projects > 0)
                {
                    ViewBag.ErrorMessage = "Unable to delete Client. Please remove all Project entries related to this client and try again.";
                    return View(db.Clients.Find(id));
                }
                else
                {

                    Clients itemToDelete = new Clients() { ClientsID = id };
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