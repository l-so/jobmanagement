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
        public decimal totalTravelExpenseCost { get; private set; }
        public decimal totalOtherCost { get; private set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> DDLCustomers { get; private set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> DDLStatus { get; private set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> DDLJobCostAccount { get; private set; }
        public List<EFDataModel.JobTravelExpenseList> JobTravelExpenses { get; private set; }
        public List<EFDataModel.JobWorkList> JobWorkedHours { get; private set; }
        internal void loadData(long id)
        {
            Job = DataAccessLayer.DBJobs.Get(id);
            DDLCustomers = DataAccessLayer.DBCustomers.getCustomerSelectListItem(this.Job.CustomerId);
            DDLStatus = DataAccessLayer.DBJobs.getStatusSelectListItem(this.Job.Status);
            DDLJobCostAccount = DataAccessLayer.DBJobs.getJobCostGLAccount(null);
            JobTravelExpenses = DataAccessLayer.DBJobs.JobTravelExpenses(this.Job.JobId);
            foreach (var a in JobTravelExpenses)
            {
                totalTravelExpenseCost += a.Amount.HasValue ? a.Amount.Value : decimal.Zero;
            }
            JobWorkedHours = DataAccessLayer.DBJobs.getWorkedHours(this.Job.JobId);
            foreach (var a in JobWorkedHours)
            {
                totalWorkedHours += a.WorkedHour.HasValue ? a.WorkedHour.Value : decimal.Zero;
            }
        }
    }
}