using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobManagement.WebMvc.Controllers
{
    public class GLController : Controller
    {
        // GET: GL
        public ActionResult Index()
        {
            // Display del piano dei conti
            Models.GL.GLIndexModel model = new Models.GL.GLIndexModel();
            model.loadModelData();
            return View(model);
        }

        public ActionResult ShowAccount(string id)
        {
            // Mostra il singolo conto
            Models.GL.GLShowAccountModel model = new Models.GL.GLShowAccountModel();
            return View(model);
        }
    }
}