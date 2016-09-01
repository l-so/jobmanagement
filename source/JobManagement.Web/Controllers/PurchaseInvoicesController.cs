using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobManagement.WebMvc.Controllers
{
    public class PurchaseInvoicesController : Controller
    {
        // GET: PurchaseInvoices
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(string id,string tecode)
        {

            return View();
        }
        public ActionResult ModalEdit(string id, string jobid)
        {
            Models.PurchaseInvoice.ModalEditPurchaseInvoiceModel model = new Models.PurchaseInvoice.ModalEditPurchaseInvoiceModel();
            model.loadData(id, jobid);
            return PartialView(model);
        }
    }
}