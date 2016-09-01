using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobManagement.WebMvc.Controllers
{
    public class VendorController : Controller
    {
        // GET: Vendors
        public ActionResult Index(string filterName, string filterStatus)
        {
            Models.Vendor.IndexVendorModel model = new Models.Vendor.IndexVendorModel();
            if (string.IsNullOrWhiteSpace(filterStatus))
            {
                 model.filterStatus = "0";
            } else
            {
                model.filterStatus = filterStatus;
            }
            model.filterName = filterName;
            model.loadData(model.filterName,int.Parse(model.filterStatus));
            return View(model);
        }

        public ActionResult ModalEdit(string id)
        {
            Models.Vendor.ModalEditVendorModel model = new Models.Vendor.ModalEditVendorModel();
            model.loadData(id);
            return PartialView(model);
        }
    }
}