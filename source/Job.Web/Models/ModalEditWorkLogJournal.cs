using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Job.WebMvc.Models
{
    public class ModalEditJobWorkJournalModel
    {
        public EFDataModel.WorksJournal WorkJournal { get; private set;}
        public IEnumerable<SelectListItem> DDLPerson { get; private set; }
        public IEnumerable<SelectListItem> DDLJobs { get; private set; }
        public IEnumerable<SelectListItem> DDLJobTask { get; private set; }
        public EFDataModel.Person People { get; private set;}
        public long SelectedJobId { get; private set;}
        public void LoadModelData(long? id, int peopleId, long? jobId)
        {
            if (id.HasValue)
            {
                this.WorkJournal = DataAccessLayer.DBJobs.getWorksJournalById(id.Value);
                this.SelectedJobId = this.WorkJournal.JobId;
                this.DDLJobs = DataAccessLayer.DBJobs.getDDLJobSelectListItem(this.SelectedJobId);
                this.People = DataAccessLayer.DBPerson.getOne(peopleId);
                this.DDLJobTask = DataAccessLayer.DBJobs.getJobTask(this.WorkJournal.JobTaskId);
            }
            else
            {
                this.WorkJournal = new EFDataModel.WorksJournal();
                this.WorkJournal.WorkJournalId = -1;
                this.WorkJournal.Date = System.DateTime.Now.Date;
                this.SelectedJobId = -1;
                this.DDLJobs = DataAccessLayer.DBJobs.getDDLJobSelectListItem((jobId.HasValue ? jobId.Value : -1));
                this.People = DataAccessLayer.DBPerson.getOne(peopleId);
                this.DDLJobTask = DataAccessLayer.DBJobs.getJobTask(null);
            }
            this.DDLPerson = DataAccessLayer.DBPerson.getDDLPerson(this.People.PeopleId);
        }


    }
}