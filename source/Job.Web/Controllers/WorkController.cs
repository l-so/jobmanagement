
using Job.WebMvc.Identity;
using System;
using System.Web.Mvc;

namespace Job.WebMvc.Controllers
{
    public class WorkController : Controller
    {
        // GET: Work
        public ActionResult Index(string filterYear, string filterMonth, string filterPeople)
        {
            Models.Work.WorkIndexModel model = new Models.Work.WorkIndexModel();
            model.FilterYear = string.IsNullOrWhiteSpace(filterYear) ? DateTime.Now.Year : int.Parse(filterYear);
            model.FilterMonth = string.IsNullOrWhiteSpace(filterMonth) ? DateTime.Now.Month : int.Parse(filterMonth);
            model.FilterPeopleId = string.IsNullOrWhiteSpace(filterPeople) ? User.Identity.GetPeople().PeopleId : int.Parse(filterPeople);
            model.LoadModelData();
            return View(model);
        }
        [HttpPost]
        public ActionResult EditWeek(string peopleId, string weekStartDay)
        {
            Models.Work.WorkEditWeekModel model = new Models.Work.WorkEditWeekModel();
            model.LoadModelData(peopleId, weekStartDay);
            return View(model);
        }
    }
}