using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cts.Mvc.ExpenseReport.Controllers
{
    [Authorize(Roles = "Admin, Accountant, User")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "CTS Expense Report";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
