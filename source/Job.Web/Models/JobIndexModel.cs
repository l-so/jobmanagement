using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Job.WebMvc.Models
{
    public class JobIndexModel
    {
        public short filterStatusOfferta { get; set; }
        public short filterStatusOperativa { get; set; }
        public short filterStatusChiusa { get; set; }
        public short filterStatusInterna { get; set; }
        public short filterStatusArchiviata { get; set; }

        public IEnumerable<EFDataModel.JobList> JobsList { get; private set; }
        public IEnumerable<SelectListItem> DDLCustomerList { get; private set; }
        
        internal void LoadModelData(long selectedCustomer, short[] filterStatus)
        {
            this.DDLCustomerList = DataAccessLayer.DBCustomers.getCustomerSelectListItem(selectedCustomer);
            this.JobsList = DataAccessLayer.DBJobs.getJobList(selectedCustomer,filterStatus);
        }

        
    }
}