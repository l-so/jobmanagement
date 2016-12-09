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
        public ActionResult EditModal(string id)
        {
            Models.Person.PersonEditModalModel model = new Models.Person.PersonEditModalModel();
            model.LoadModelData(string.IsNullOrWhiteSpace(id) ? (int?)null : int.Parse(id));
            return PartialView(model);
        }

        // Pagamento ad un socio PartnerPayment
        public ActionResult EditDialogPartnerPayment()
        {
            
            Models.Person.EditDialogPartnerPaymentModel model = new Models.Person.EditDialogPartnerPaymentModel();
            model.People = User.Identity.GetPeople();
            model.LoadModelData();
            return PartialView(model);
        }
        // Pagamento tasse ed INPS al posto del socio PartnerTaxPayment
        public ActionResult EditDialogPartnerTaxPayment()
        {
            Models.Person.EditDialogPartnerTaxPaymentModel model = new Models.Person.EditDialogPartnerTaxPaymentModel();
            model.People = User.Identity.GetPeople();
            model.LoadModelData();
            return PartialView(model);
        }
        // Richiesta rimborsi fatture o altro intestato a ZZSoft
        public ActionResult PaymentRefoundRequestList(string filterMonth, string filterYear, string filterRequestBy)
        {
            Models.Person.PaymentRefoundRequestListModel model = new Models.Person.PaymentRefoundRequestListModel();
            model.FilterMonth = string.IsNullOrWhiteSpace(filterMonth) ? System.DateTime.Now.Month : int.Parse(filterMonth);
            model.FilterYear = string.IsNullOrWhiteSpace(filterYear) ? System.DateTime.Now.Year : int.Parse(filterYear);
            // Prendere il PeopleLoggato dalla cache
            model.FilterRequestById = string.IsNullOrWhiteSpace(filterRequestBy) ? User.Identity.GetPeople().PeopleId : int.Parse(filterRequestBy);
            model.LoadModelData();
            return View(model);
        }

        public ActionResult EditDialogPrePaymentRefound(string id)
        {
            Models.Person.EditDialogPrePaymentRefoundModel model = new Models.Person.EditDialogPrePaymentRefoundModel();
            model.People = User.Identity.GetPeople();
            model.LoadModelData(id);
            return PartialView(model);
        }
    }
}