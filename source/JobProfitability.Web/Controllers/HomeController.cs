using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using JobManagement.WebMvc.Identity;

namespace JobManagement.WebMvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index(int? anno, int? mese)
        {
            
            Models.Home.HomeIndexModel model = new Models.Home.HomeIndexModel();
            int mh = (anno.HasValue ? anno.Value : System.DateTime.Now.Year) * 100 + (mese.HasValue ? mese.Value : System.DateTime.Now.Month);
            model.LoadModelData(User.Identity.GetPeople(), mh);
            return View(model);
        }

        public ActionResult DayEdit(DateTime id)
        {

            Models.Home.HomeDayEditModel model = new Models.Home.HomeDayEditModel();
            model.LoadModelData(User.Identity.GetPeople(), id);
            return View(model);
        }
    }
}