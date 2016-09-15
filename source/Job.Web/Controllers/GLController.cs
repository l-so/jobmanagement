using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Job.WebMvc.Controllers
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

        public ActionResult ShowAccount(string filterAccountCode, string filterYear, string filterPeriod)
        {
            // Mostra il singolo conto
            Models.GL.GLShowAccountModel model = new Models.GL.GLShowAccountModel();
            if (string.IsNullOrWhiteSpace(filterAccountCode)) throw new System.ArgumentNullException("filterAccountCode è obbligatorio!");
            model.AccountCode = filterAccountCode;
            model.FilterYear = (string.IsNullOrWhiteSpace(filterYear) ? DateTime.Now.Year : int.Parse(filterYear));
            model.FilterPeriod = (string.IsNullOrWhiteSpace(filterPeriod) ? short.Parse("99") : short.Parse(filterPeriod));
            model.loadData();
            return View(model);
        }
    }
}