using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace JobManagement.WebMvc.Controllers
{
    [Authorize]
    public class AppUserController : Controller
    {
        [Authorize(Roles = "ADMIN")]
        public ActionResult Index()
        {
            Models.AppUser.AppUserIndexModel model = new Models.AppUser.AppUserIndexModel();
            model.LoadModelData(this.User.Identity.GetUserId());
            return View(model);
        }
        [HttpGet]
        [OutputCache(Duration = 0, VaryByParam = "none", NoStore = true)]
        public ActionResult ModalAppUserEdit(string id)
        {
            Models.AppUser.ModalAppUserEditModel model = new Models.AppUser.ModalAppUserEditModel();
            model.LoadModelData(id);
            return PartialView(model);
        }
        [HttpPost]
        [OutputCache(Duration = 0, VaryByParam = "none", NoStore = true)]
        public ActionResult ModalEditUser(string UserId, string UserName, string Email, string Passwd, string PasswdConfirm, string UserRole)
        {
            Identity.AppUser usr = Identity.IdentityHelper.Create(UserName,Email,Passwd);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [OutputCache(Duration = 0, VaryByParam = "none", NoStore = true)]
        public ActionResult ModalResetPassword(string id)
        {
            Models.AppUser.ModalAppUserRstPwdModel m = new Models.AppUser.ModalAppUserRstPwdModel();
            var u = Identity.IdentityHelper.getAppUserById(id);
            if (u != null)
            {
                m.UserId = u.Id;
                m.UserName = u.UserName;
            }
            return PartialView(m);
        }
        [HttpPost]
        public JsonResult ModalResetPassword(string userId, string Passwd, string PasswdConfirm)
        {
            Code.MyApiStandardResponse _resp = new Code.MyApiStandardResponse();
            _resp.ResultStatus = "OK"; // No errori
            _resp.ErrorMessage = null;
            IdentityResult r = Identity.IdentityHelper.ResetUserPassword(userId, Passwd);
            if (!r.Succeeded)
            {
                _resp.ResultStatus = "KO";
                _resp.ErrorMessage = string.Empty;
                foreach (string s in  r.Errors) {
                    _resp.ErrorMessage += s;
                }
            }
            return new JsonResult() { Data = _resp}; 
        }
        
        [HttpGet]
        public ActionResult EditMe()
        {
            Models.AppUser.AppUserEditMeModel model = new Models.AppUser.AppUserEditMeModel();
            model.LoadModelData(this.User.Identity.GetUserId());
            return View(model);
        }
    }
}