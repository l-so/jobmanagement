using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JobManagement.WebMvc.Identity
{
    public class IdentityHelper
    {
        internal static AppUser getAppUserById(string id)
        {
            UserStore<AppUser> store = new UserStore<AppUser>(new AppDbContext());
            UserManager<AppUser> userManager = new UserManager<AppUser>(store);
            AppUser user = userManager.FindById(id);
            return user;
        }

        internal static AppUser Create(string userName, string email, string passwd)
        {
            using (Identity.AppDbContext dbctx = new Identity.AppDbContext())
            {
                var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(dbctx));
                var appUsr = new AppUser
                {
                    UserName = userName,
                    Email = email,
                    EmailConfirmed = true
                };
                IdentityResult r = userMgr.Create(appUsr, passwd);
                if (r.Succeeded)
                {
                    return appUsr;
                }
                else
                {
                    return null;
                }
            }
        }

        internal static IdentityResult ResetPassword(string userId, string userPwd)
        {
            using (Identity.AppDbContext dbctx = new Identity.AppDbContext())
            {
                var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(dbctx));
                IdentityResult r = userMgr.ResetPassword(userId, Guid.NewGuid().ToString(), userPwd);
                return r;
            }
        }

        internal static IdentityResult ChangePassword(string userId, string oldPwd, string newPwd)
        {
            using (Identity.AppDbContext dbctx = new Identity.AppDbContext())
            {
                var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(dbctx));
                IdentityResult r = userMgr.ChangePassword(userId, oldPwd, newPwd);
                return r;
            }
        }

        public static bool IsAdmin(string userId)
        {
            bool r = false;
            using (Identity.AppDbContext dbctx = new Identity.AppDbContext())
            {
                var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(dbctx));
                r = userMgr.IsInRole(userId, "ADMIN");
            }
            return r;
        }

        internal static IEnumerable<AppUser> getUserList(bool? active)
        {
            IEnumerable<AppUser> _result = null;
            using (Identity.AppDbContext dbctx = new Identity.AppDbContext())
            {
                dbctx.Configuration.ProxyCreationEnabled = false;
                _result = dbctx.Users.ToList<Identity.AppUser>();
            }
            return _result;
        }

        internal static IEnumerable<AppUser> getUserList()
        {
            IEnumerable<AppUser> _result = null;
            using (Identity.AppDbContext dbctx = new Identity.AppDbContext())
            {
                dbctx.Configuration.ProxyCreationEnabled = false;
                dbctx.Configuration.LazyLoadingEnabled = false;
                _result = dbctx.Users.ToList<Identity.AppUser>();
            }
            return _result;
        }

        internal static IList<string> getAppUserRoles(string appUserId)
        {
            UserStore<AppUser> store = new UserStore<AppUser>(new AppDbContext());
            UserManager<AppUser> userManager = new UserManager<AppUser>(store);
            IList<string> _roles = userManager.GetRoles(appUserId);
            return _roles;
        }

        internal static IEnumerable<IdentityRole> getAvailableRole()
        {
            RoleStore<IdentityRole> storeRole = new RoleStore<IdentityRole>(new AppDbContext());
            RoleManager<IdentityRole> managerRole = new RoleManager<IdentityRole>(storeRole);
            return managerRole.Roles.ToList<IdentityRole>();
        }

        public static IdentityResult ResetUserPassword(string userId, string passwd)
        {

            UserStore<AppUser> store = new UserStore<AppUser>(new AppDbContext());
            UserManager<AppUser> userManager = new UserManager<AppUser>(store);
            IdentityResult r = userManager.RemovePassword(userId);
            if (r.Succeeded)
            {
                r = userManager.AddPassword(userId, passwd);
            }
            return r;
        }

        public static IdentityResult AppUserCreate(string _userName, string _userEmail, string _userPwd, string _userRoleId)
        {
            IdentityResult _result = null;
            using (Identity.AppDbContext dbctx = new Identity.AppDbContext())
            {
                var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(dbctx));
                var appUsr = new AppUser
                {
                    UserName = _userName,
                    Email = _userEmail,
                    EmailConfirmed = true
                };
                _result = userMgr.Create(appUsr, _userPwd);
                if (_result.Succeeded)
                {
                    userMgr.AddToRole<AppUser, string>(appUsr.Id, _userRoleId);
                }
                return _result;
            }
        }
    }
}