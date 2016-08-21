using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobManagement.WebMvc.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        public ActionResult Index()
        {
            Models.People.PeopleIndexModel model = new Models.People.PeopleIndexModel();
            model.LoadModelData(null);
            return View(model);
        }
        public ActionResult EditModal(int? id)
        {
            Models.People.PeopleEditModalModel model = new Models.People.PeopleEditModalModel();
            model.LoadModelData(id);
            return PartialView(model);
        }

    }
}