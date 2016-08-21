using System;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace JobManagement.WebMvc.Controllers
{
    [AllowAnonymous]
    public class IndexController : Controller
    {

        public ActionResult Login(string loginUserName, string returnurl, string loginErrorMsg)
        {
            if (string.IsNullOrWhiteSpace(returnurl)) 
            {
                ViewBag.ReturnUrl = System.Web.VirtualPathUtility.ToAbsolute("~/Home/Index");
            }
            else 
            { 
                ViewBag.ReturnUrl = returnurl;
            }
            ViewBag.UserNname = loginUserName;
            ViewBag.ErrorMessage = loginErrorMsg;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password, bool remember, string returnurl)
        {
            string s = SignIn(email, password, remember);
            if (s == "OK")
            {
                Identity.LoggedUserSessionData sd = new Identity.LoggedUserSessionData();
                sd.LoggedAspNetUser = new EFDataModel.AspNetUsers();
                sd.LoggedAspNetUser.Id = User.Identity.GetUserId();
                sd.LoggedAspNetUser.UserName = User.Identity.Name;
                sd.LoggedPeople = DataAccessLayer.DBPeople.getLoggedByUserId(User.Identity.GetUserId());
                this.Session["LoggedUserSessionData"] = sd;
                return Redirect(returnurl);
            }
            else
            {
                return RedirectToAction("Login", new {loginUserName = email, loginErrorMsg = s});
            }
        }
        public ActionResult LogOff()
        {
            SignOut();
            return RedirectToAction("Login");
        }

        protected string SignIn(string loginUser, string loginPassword, bool loginRemeber)
        {
            try { 
                Identity.AppDbContext dbCtx = new Identity.AppDbContext();
                var userStore = new UserStore<Identity.AppUser>(dbCtx);
                var userManager = new Identity.AppUserManager(userStore);
                Identity.AppUser user = userManager.Find(loginUser, loginPassword);            
            
                if (user != null)
                {
                    if (userManager.CheckPassword(user, loginPassword)) { 
                        var authenticationManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
                        var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                        authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = loginRemeber }, userIdentity);
                        return "OK";
                    }
                    else
                    {
                        return "Password is not valid!";
                    }
                }
                else
                {
                    return "Username or password not valid!";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        protected void SignOut()
        {
            var authenticationManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            RedirectToAction("Login","Index");
        }
    }
}