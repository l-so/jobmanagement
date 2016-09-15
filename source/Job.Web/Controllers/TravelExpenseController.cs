using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Job.WebMvc.Identity;

namespace Job.WebMvc.Controllers
{
    [Authorize]
    public class TravelExpenseController : Controller
    {
        // GET: TravelExpense
        public ActionResult Index(int? filterMonth, int? filterYear, int? filterPeopleId, string status)
        {
            Models.TravelExpense.TravelExpenseIndexModel model = new Models.TravelExpense.TravelExpenseIndexModel();
            EFDataModel.Person p = User.Identity.GetPeople();
            if (!filterPeopleId.HasValue) 
                filterPeopleId = p.PeopleId;
            model.LoadData(filterMonth, filterYear, filterPeopleId, status);
            return View(model);
        }

        public ActionResult Edit(string id, string tefm, string tefy, string tefp, string tes)
        {
            Models.TravelExpense.TravelExpenseEditModel model = new Models.TravelExpense.TravelExpenseEditModel();
            model.LoadData(id);
            model.TEFilterMonth = string.IsNullOrWhiteSpace(tefm) ? System.DateTime.Now.Month : int.Parse(tefm);
            model.TEFilterYear = string.IsNullOrWhiteSpace(tefy) ? System.DateTime.Now.Year : int.Parse(tefy); ;
            model.TEFilterPeopleId = string.IsNullOrWhiteSpace(tefp) ? System.DateTime.Now.Year : this.User.Identity.GetPeople().PeopleId; 
            if (model.TravelExpense.Status == EFDataModel.TravelExpenses.STATUS_BOZZA)
            {
                return View(model);
            } else  {
                return RedirectToAction("TravelExpense", "DisplayDocument", new { id = id});
            }
        }
        
        [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)] // will disable caching 
        public ActionResult TravelExpenseEditHeaderModal(string id, int? peopleId, int? year, byte? month, string status)
        {
            Models.TravelExpense.TravelExpenseEditHeaderModalModel model = new Models.TravelExpense.TravelExpenseEditHeaderModalModel();
            int a = (year.HasValue ? year.Value : DateTime.Now.Year);
            int m = (month.HasValue ? month.Value : DateTime.Now.Month);
            int p = (peopleId.HasValue ? peopleId.Value : this.User.Identity.GetPeople().PeopleId);
            model.TEFilterMonth = m;
            model.TEFilterYear = a;
            model.TEFilterPeopleId = p;
            model.TEFilterStatus = status;
            model.LoadData(id, p, new DateTime(a,m,DateTime.DaysInMonth(a,m)));
            return PartialView(model);
        }

        public ActionResult PostTravelExpenses(string id)
        {
            int y = int.Parse(id.Substring(0, 4));
            int m = int.Parse(id.Substring(4, 2));
            int p = int.Parse(id.Substring(6));
            Models.TravelExpense.TravelExpensePostTravelExpensesModel model = new Models.TravelExpense.TravelExpensePostTravelExpensesModel();
            return View(model);
        }
    }
}