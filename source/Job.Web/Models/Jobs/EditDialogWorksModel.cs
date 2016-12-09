using System.Collections.Generic;

namespace Job.WebMvc.Models.Jobs
{
    public class EditDialogWorksModel
    {
        public EFDataModel.WorksJournal WorkJournal { get; private set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> DDLPerson { get; private set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> DDLJobs { get; private set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> DDLJobTask { get; private set; }
        public EFDataModel.Person People { get; private set; }
        public long SelectedJobId { get; private set; }
        public void LoadModelData(long? id, int peopleId, long? jobId)
        {
            List<System.Web.Mvc.SelectListItem> tmpDLLTsk = new List<System.Web.Mvc.SelectListItem>();
            if (id.HasValue)
            {
                this.WorkJournal = DataAccessLayer.DBJobs.getWorksJournalById(id.Value);
                this.SelectedJobId = this.WorkJournal.JobId;
                this.DDLJobs = DataAccessLayer.DBJobs.getDDLJobSelectListItem(this.SelectedJobId);
                this.People = DataAccessLayer.DBPerson.getOne(peopleId);
                this.DDLJobTask = DataAccessLayer.DALJob.getDDLJobTasks(this.SelectedJobId, this.WorkJournal.JobTaskId);
            }
            else
            {
                
                this.WorkJournal = new EFDataModel.WorksJournal();
                this.WorkJournal.WorkJournalId = -1;
                this.WorkJournal.Date = System.DateTime.Now.Date;
                this.SelectedJobId = (jobId.HasValue ? jobId.Value : -1);
                this.DDLJobs = DataAccessLayer.DBJobs.getDDLJobSelectListItem(this.SelectedJobId);
                this.People = DataAccessLayer.DBPerson.getOne(peopleId);
                if (this.SelectedJobId > 0)
                {
                    var tskList = DataAccessLayer.DALJob.getJobTasks(this.SelectedJobId);
                    foreach (var tsk in tskList)
                    {
                        tmpDLLTsk.Add(new System.Web.Mvc.SelectListItem()
                            {
                                Value = tsk.JobTaskId,
                                Text = tsk.Description,
                                Selected = false
                            }
                        );
                    }
                    tmpDLLTsk.Add(new System.Web.Mvc.SelectListItem()
                        {
                            Value = string.Empty,
                            Text = "Seleziona un'attività...",
                            Selected = true
                        }
                    );
                } else
                {
                    tmpDLLTsk.Add(new System.Web.Mvc.SelectListItem()
                        {
                            Value = string.Empty,
                            Text = "--SELEZIONA UNA COMMESSA--",
                            Selected = true
                        }
                    );
                }
                this.DDLJobTask = tmpDLLTsk;
            }
            this.DDLPerson = DataAccessLayer.DBPerson.getDDLPerson(this.People.PeopleId);
        }
    }
}