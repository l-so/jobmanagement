using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Job.WebMvc.Models
{
    public class JobIndexModel
    {
        public byte filterStatusOfferta { get; set; }
        public byte filterStatusOperativa { get; set; }
        public byte filterStatusChiusa { get; set; }
        public byte filterStatusInterna { get; set; }
        public byte filterStatusArchiviata { get; set; }

        public IEnumerable<EFDataModel.JobList> JobsList { get; private set; }
        public IEnumerable<SelectListItem> DDLCustomerList { get; private set; }
        
        internal void LoadModelData(long selectedCustomer, byte[] filterStatus)
        {
            this.DDLCustomerList = DataAccessLayer.DBCustomers.getCustomerSelectListItem(selectedCustomer);
            this.JobsList = DataAccessLayer.DALJob.getJobList(selectedCustomer,filterStatus);
        }

        
    }
}