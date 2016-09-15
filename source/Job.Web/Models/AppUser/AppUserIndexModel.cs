using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Job.WebMvc.Models.AppUser
{
    public class AppUserIndexModel
    {
        public string LoggedUserId { get; private set;}
        public IEnumerable<Identity.AppUser> Users { get; private set;}

        public void LoadModelData(string loggedUserId)
        {
            this.LoggedUserId = loggedUserId;
            this.Users = Identity.IdentityHelper.getUserList(null);
        }
    }
}
