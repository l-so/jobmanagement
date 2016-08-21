﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobManagement.WebMvc.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index(string filterFullName, string filterActiveState)
        {
            Models.CustomerIndexModel model = new Models.CustomerIndexModel();
            model.LoadModelData(filterFullName, filterActiveState);
            return View(model);
        }

        [HttpGet]
        public ActionResult ModalEditCustomer(long? id)
        {
            Models.ModalEditCustomerModel model = new Models.ModalEditCustomerModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost]
        public JsonResult ModalEditCustomer(EFDataModel.Customers customer)
        {
            JsonResult _result = null;
            _result = DataAccessLayer.DBCustomers.Update(customer);
            return _result;
        }
    }
}