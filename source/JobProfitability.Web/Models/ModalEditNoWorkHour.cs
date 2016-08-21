using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobManagement.WebMvc.Models
{
    public class ModalEditNoWorkHour
    {
        public IEnumerable<SelectListItem> DDLPeopleList { get; private set; }
        public IEnumerable<SelectListItem> DDLJobNoWorkTask { get; private set; }
        public EFDataModel.Jobs NoWorkJob { get; private set;}
        internal void LoadData(int peopleId)
        {
            this.DDLPeopleList = DataAccessLayer.DBPeople.getPeopleDDL(peopleId);
            this.DDLJobNoWorkTask = DataAccessLayer.DBJobs.getJobNoWorkTask();
            
        }
    }
}