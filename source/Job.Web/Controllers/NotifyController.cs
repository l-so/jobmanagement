using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Job.WebMvc.Controllers
{
    public class NotifyController : Controller
    {
        // GET: Notify
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NotifyError()
        {
            return PartialView();
        }
    }
}