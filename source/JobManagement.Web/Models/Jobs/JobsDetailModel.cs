using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobManagement.WebMvc.Models.Jobs
{
    public class JobsDetailModel
    {
        public EFDataModel.Jobs Job { get; private set;}

        public void LoadModelData(long jobId)
        {
            this.Job = DataAccessLayer.DBJobs.getJobById(jobId);
        }
    }
}