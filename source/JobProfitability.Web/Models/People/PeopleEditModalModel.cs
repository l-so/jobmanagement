using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobManagement.WebMvc.Models.People
{
    public class PeopleEditModalModel
    {
        public EFDataModel.Person People { get; private set;}
        public List<System.Web.Mvc.SelectListItem> DDLAppUsers { get; private set; }
        
        internal void LoadModelData(int? id)
        {
            if (id.HasValue)
            {
                this.People = DataAccessLayer.DBPeople.getOne(id.Value);
            }
            else
            {
                this.People = new EFDataModel.Person();
                this.People.PeopleId = -1;
                this.People.IdentityId = null;
                this.People.AspNetUsers = null;
            }

            this.DDLAppUsers = new List<System.Web.Mvc.SelectListItem>();
            var users = Identity.IdentityHelper.getUserList();
            foreach (var u in users)
            {
                var item = new System.Web.Mvc.SelectListItem()
                {
                    Value = u.Id,
                    Text = u.UserName,
                    Selected = (u.Id == (this.People != null ? this.People.IdentityId : null))
                };
                this.DDLAppUsers.Add(item);
            }
        }
    }
}