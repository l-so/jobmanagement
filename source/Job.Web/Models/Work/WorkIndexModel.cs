using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job.WebMvc.Models.Work
{
    public class WorkIndexModel
    {
        
        public int FilterMonth { get; set; }
        public int FilterYear { get; set; }
        public int FilterPeopleId { get; set; }
        public EFDataModel.Person People { get; private set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> DDLPerson { get; private set; }
        public Code.MontlyWorkedPeopleHours WorkedHours { get; private set; }

        internal void LoadModelData()
        {
            People = DataAccessLayer.DBPerson.getOne(FilterPeopleId);
            this.DDLPerson = DataAccessLayer.DALPerson.getPersonForDDL(FilterPeopleId);
            WorkedHours = Logic.Work.getMonthWorkedHourByPeople(People, FilterYear, FilterMonth);
        }
    }
}