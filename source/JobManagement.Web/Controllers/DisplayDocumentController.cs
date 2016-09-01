using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobManagement.WebMvc.Controllers
{
    public class DisplayDocumentController : Controller
    {
        // GET: DisplayDocument
        public ActionResult Index(string type, string id, string p1, string p2, string p3)
        {
            string viewName = "Index";
            object objModel = null;
            switch (type)
            {
                case "RimborsoSpese":
                    viewName = "DDRimborsoSpese";
                    
                break;
                case "Fattura":
                    viewName = "DDInvoice";
                    
                break;
            }
            return View(viewName, objModel);
        }
        public ActionResult TravelExpense(string id)
        {
            return View();
        }
        public ActionResult PurchaseInvoice(long id)
        {
            return View();
        }
    }
}