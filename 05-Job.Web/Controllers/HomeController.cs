using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _05_Job.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string userName, string userPasswd)
        {
            return RedirectToAction("HomePage");
        }
        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Index");
        }
    }
}