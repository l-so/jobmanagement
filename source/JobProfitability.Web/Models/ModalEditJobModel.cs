using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobManagement.WebMvc.Models
{
    public class ModalEditJobModel
    {
        public EFDataModel.Jobs Job { get; set; }
        public IEnumerable<SelectListItem> DDLCustomerList { get; private set; }
        public IEnumerable<SelectListItem> DDLStatusList { get; private set; }

        internal void LoadModelData(long? jobId)
        {
            if (jobId.HasValue)
            {
                this.Job = DataAccessLayer.DBJobs.getJobById(jobId.Value);
            }
            else
            {
                this.Job = new EFDataModel.Jobs();
                this.Job.JobId = -1;
                this.Job.CustomerId = -1;
                this.Job.Status = 0;
                this.Job.Year = System.DateTime.Now.Year;
            }
            this.DDLCustomerList = DataAccessLayer.DBCustomers.getCustomerSelectListItem(this.Job.CustomerId);
            this.DDLStatusList = DataAccessLayer.DBJobs.getStatusSelectListItem(this.Job.Status);
        }

        
    }
}