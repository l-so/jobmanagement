using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Job.WebMvc.Controllers
{
    public class DisplayDocumentController : Controller
    {
        public ActionResult TravelExpense(string id)
        {
            Models.DisplayDocument.DisplayTravelExpenseModel model = new Models.DisplayDocument.DisplayTravelExpenseModel();
            model.loadData(id);
            return View(model);
        }

        public ActionResult ExpensePaymentRefound(string id)
        {
            Models.DisplayDocument.DisplayExpensePaymentRefoundModel model = new Models.DisplayDocument.DisplayExpensePaymentRefoundModel();
            model.loadData(id);
            return View(model);
        }
    }
}