using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobManagement.WebMvc.Controllers
{
    public class PurchasesController : Controller
    {
        // GET: Purchases
        public ActionResult Index()
        {
            return View();
        }

        // GET: Purchases
        [HttpGet]
        public ActionResult Edit()
        {
            JobManagement.WebMvc.Models.Purchases.EditPurchaseModel model = new Models.Purchases.EditPurchaseModel();
            model.loadModelData();
            return View(model);
        }


    }
}