using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobManagement.WebMvc.Identity;

namespace JobManagement.WebMvc.Controllers
{
    [Authorize]
    public class TravelExpenseController : Controller
    {
        // GET: TravelExpense
        public ActionResult Index(int? filterMonth, int? filterYear, int? filterPeopleId)
        {
            Models.TravelExpense.TravelExpenseIndexModel model = new Models.TravelExpense.TravelExpenseIndexModel();
            EFDataModel.Person p = User.Identity.GetPeople();
            if (!filterPeopleId.HasValue) 
                filterPeopleId = p.PeopleId;
            model.LoadData(filterMonth, filterYear, filterPeopleId);
            return View(model);
        }

        public ActionResult Edit(string id, int tefm, int tefy, int tefp)
        {
            Models.TravelExpense.TravelExpenseEditModel model = new Models.TravelExpense.TravelExpenseEditModel();
            model.LoadData(id);
            model.TEFilterMonth = tefm;
            model.TEFilterYear = tefy;
            model.TEFilterPeopleId = tefp;
            return View(model);
        }
        
        [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)] // will disable caching 
        public ActionResult TravelExpenseEditHeaderModal(string id, int? peopleId, int? year, byte? month)
        {
            Models.TravelExpense.TravelExpenseEditHeaderModalModel model = new Models.TravelExpense.TravelExpenseEditHeaderModalModel();
            int a = (year.HasValue ? year.Value : DateTime.Now.Year);
            int m = (month.HasValue ? month.Value : DateTime.Now.Month);
            int p = (peopleId.HasValue ? peopleId.Value : this.User.Identity.GetPeople().PeopleId);
            model.TEFilterMonth = m;
            model.TEFilterYear = a;
            model.TEFilterPeopleId = p;
            model.LoadData(id, p, new DateTime(a,m,DateTime.DaysInMonth(a,m)));
            return PartialView(model);
        }

        public ActionResult GLPost(string id)
        {
            JobManagement.WebMvc.Models.TravelExpense.TravelExpenseGLPostModel model = new Models.TravelExpense.TravelExpenseGLPostModel();
            return View(model);
        }
    }
}