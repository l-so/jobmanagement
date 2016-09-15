using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Job.WebMvc.Models.Home
{
    public class HomeDayEditModel
    {
        public EFDataModel.Person LoggedPeople { get; private set; }
        public DateTime Day { get; private set; }
        public List<System.Web.Mvc.SelectListItem> PeopleList {get; private set;}

        internal void LoadModelData(EFDataModel.Person people, DateTime day)
        {
            this.LoggedPeople = people;
            this.Day = day;
            this.PeopleList = DataAccessLayer.DBPerson.getDDLPerson(people.PeopleId);
        }
    }
}
