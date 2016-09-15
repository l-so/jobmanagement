using System.Web.Mvc;
using Job.WebMvc.Identity;

namespace Job.WebMvc.Controllers
{
    public class PersonController : Controller
    {
        public ActionResult Index()
        {
            Models.Person.PersonIndexModel model = new Models.Person.PersonIndexModel();
            model.LoadModelData(null);
            return View(model);
        }

        public ActionResult ModalPeoplePayment(string id)
        {
            Models.Person.ModalPeoplePaymentModel model = new Models.Person.ModalPeoplePaymentModel();
            int p = this.User.Identity.GetPeople().PeopleId;
            model.loadModelData(p.ToString());
            return PartialView(model);
        }

        public ActionResult ExpenseRefoundList(string filterYear, string filterMonth, string filterPeopleId)
        {
            Models.Person.ExpenseRefoundIndexModel model = new Models.Person.ExpenseRefoundIndexModel();
            model.LoggedPeople = User.Identity.GetPeople();
            model.FilterYear = string.IsNullOrWhiteSpace(filterYear) ? System.DateTime.Now.Year : int.Parse(filterYear);
            model.FilterMonth = string.IsNullOrWhiteSpace(filterMonth) ? System.DateTime.Now.Month : int.Parse(filterMonth);
            model.FilterPeopleId = string.IsNullOrWhiteSpace(filterPeopleId) ? model.LoggedPeople.PeopleId : int.Parse(filterPeopleId);
            model.loadData(model.FilterYear,model.FilterMonth,model.FilterPeopleId);
            return View(model);
        }
        public ActionResult ModalExpenseRefoundEdit(string id)
        {
            Models.Person.ModalExpenseRefoundEditModel model = new Models.Person.ModalExpenseRefoundEditModel();
            model.LoggedPeople = User.Identity.GetPeople();
            model.loadData(id);
            return PartialView(model);
        }
    }
}