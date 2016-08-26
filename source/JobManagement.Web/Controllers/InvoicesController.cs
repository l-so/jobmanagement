using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobManagement.WebMvc.Controllers
{
    public class InvoicesController : Controller
    {
        // GET: Invoices
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
    }
}