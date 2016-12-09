using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job.WebMvc.Models.Jobs
{
    public class JobsEditModel
    {
        public EFDataModel.Jobs Job { get; private set; }
        public decimal totalWorkedHours { get; private set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> DDLCustomers { get; private set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> DDLStatus { get; private set; }
        //public IEnumerable<System.Web.Mvc.SelectListItem> DDLJobCostAccount { get; private set; }
        public IEnumerable<EFDataModel.JobTasks> TaskList { get; private set; }

        internal void loadData(long id)
        {
            Job = DataAccessLayer.DBJobs.Get(id);
            DDLCustomers = DataAccessLayer.DBCustomers.getCustomerSelectListItem(this.Job.CustomerId);
            DDLStatus = DataAccessLayer.DBJobs.getStatusSelectListItem(this.Job.Status);
            //DDLJobCostAccount = DataAccessLayer.DBJobs.getJobCostGLAccount(null);
            totalWorkedHours = DataAccessLayer.DBJobs.getTotalWorkedHours(id);
            TaskList = DataAccessLayer.DBJobs.getJobTask(id);
        }
    }
}