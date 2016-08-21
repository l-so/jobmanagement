using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobManagement.WebMvc.Models.AppUser
{
    public class ModalAppUserEditModel
    {
        public Identity.AppUser User { get; private set;}
        public IList<string> UserRoles { get; private set; }
        public IEnumerable<Microsoft.AspNet.Identity.EntityFramework.IdentityRole> Roles { get; private set; }

        public void LoadModelData(string userId)
        {
            if (!string.IsNullOrWhiteSpace(userId)) { 
                this.User = Identity.IdentityHelper.getAppUserById(userId);
                this.UserRoles = Identity.IdentityHelper.getAppUserRoles(userId);
            }
            else
            {
                this.User = new Identity.AppUser();
                this.User.Id = null;
                this.UserRoles = new List<string>();
            }
            this.Roles = Identity.IdentityHelper.getAvailableRole();
        }
    }
}