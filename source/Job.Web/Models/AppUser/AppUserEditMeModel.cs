using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Job.WebMvc.Models.AppUser
{
    public class AppUserEditMeModel
    {
        public string LoggedUserId {get; private set;}
        public Identity.AppUser UserApp {get; private set;}
        public EFDataModel.Person UserPeople { get; private set;}

        public void LoadModelData(string id)
        {
            this.LoggedUserId = id;
            Identity.AppUserManager mgr = new Identity.AppUserManager(new Microsoft.AspNet.Identity.EntityFramework.UserStore<Identity.AppUser>(new Identity.AppDbContext()));
            this.UserApp = mgr.Users.Where(au => au.Id == id).FirstOrDefault<Identity.AppUser>();
            this.UserPeople = DataAccessLayer.DBPerson.getLoggedByUserId(id);
        }
    }
}
