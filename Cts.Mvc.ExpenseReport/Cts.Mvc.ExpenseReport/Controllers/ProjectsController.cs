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
    public class ProjectsController : Controller
    {
        private ExpenseReportContext db = new ExpenseReportContext();

        //
        // GET: /Projects/

        //[Authorize(Roles="Admin")]
        //[HandleError(ExceptionType=typeof(TypeLoadException), View="Error")]
        [HttpGet]
        public ActionResult Index(string sortOrder = "Project")
        {
            var projects = db.Projects.Include(c => c.Clients);

            switch (sortOrder)
            { 
                case "Project":
                    projects = projects.OrderBy(p => p.Project);
                    break;
                case "ProjectID":
                    projects = projects.OrderBy(p => p.ProjectsID);
                    break;
                case "Client":
                    projects = projects.OrderBy(p => p.Clients);
                    break;
            }

            return View(projects);
        }

        //
        // GET: /Projects/Details/5
        [HttpGet]
        public ActionResult Details(int id = 0)
        {
            Projects projects = db.Projects.Find(id);
            if (projects == null)
            {
                return HttpNotFound();
            }
            return View(projects);
        }

        //
        // GET: /Projects/Create

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ClientsList = new SelectList(db.Clients, "ClientsID", "Client");
            return View();
        }

        //
        // POST: /Projects/Create

        [HttpPost, ActionName("Create")]
        public ActionResult Create(Projects projects)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Projects.Add(projects);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.  Please try again.  If the problem persists, then contact your system administrator.");
            }

            return View(projects);
        }

        //
        // GET: /Projects/Edit/5

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            Projects projects = db.Projects.Find(id);
            if (projects == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.ClientsList = new SelectList(db.Clients, "ClientsID", "Client", projects.ClientsID);

            return View(projects);
        }

        //
        // POST: /Projects/Edit/5

        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(Projects projects)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(projects).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.  Please try again.  If the problem persists, then contact your system administrator.");
            }

            ViewBag.ClientsList = new SelectList(db.Clients, "ClientsID", "Client", projects.ClientsID);

            return View(projects);
        }

        //
        // GET: /Projects/Delete/5

        [HttpGet]
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            //Projects projects = db.Projects.Find(id);
            //if (projects == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(projects);
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Please try again.  If the problem persists contact your system administrator";
            }
            return View(db.Projects.Find(id));
        }

        //
        // POST: /Projects/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var entries = db.Entries.Where(x => x.ProjectsID == id).Count();

                if (entries > 0)
                {
                    ViewBag.ErrorMessage = "Unable to delete Project. Please remove all Expense Report entries related to this project and try again.";
                    return View(db.Projects.Find(id));
                }
                else
                {

                    Projects itemToDelete = new Projects() { ProjectsID = id };
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