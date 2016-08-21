using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobManagement.WebMvc.Identity
{
    public class AppRoleManager : RoleManager<IdentityRole>
    {
        public AppRoleManager(IRoleStore<IdentityRole, string> roleStore)
            : base(roleStore)
        {

        }

        public static AppRoleManager Create(
            IdentityFactoryOptions<AppRoleManager> options,
            IOwinContext context)
        {
            var manager = new AppRoleManager(
                new RoleStore<IdentityRole>(
                    context.Get<AppDbContext>()));

            return manager;
        }
    }
}