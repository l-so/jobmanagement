using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Job.WebMvc.Identity;

namespace Job.WebMvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index(string filterYear, string filterMonth, string filterPeople)
        {
            Models.Home.HomeIndexModel model = new Models.Home.HomeIndexModel();
            model.FilterYear = string.IsNullOrWhiteSpace(filterYear) ? DateTime.Now.Year : int.Parse(filterYear);
            model.FilterMonth = string.IsNullOrWhiteSpace(filterMonth) ? DateTime.Now.Month : int.Parse(filterMonth);
            int p = string.IsNullOrWhiteSpace(filterPeople) ? User.Identity.GetPeople().PeopleId : int.Parse(filterPeople);
            
            int mh = model.FilterYear * 100 + model.FilterMonth;
            model.LoadModelData(p, mh);
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