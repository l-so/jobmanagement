using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job.WebMvc.Models.Jobs
{
    public class EditDialogJobTaskModel
    {
        public EFDataModel.JobTasks Task { get; private set; }
        internal void LoadData(long jobId, string taskId)
        {
            if (string.IsNullOrWhiteSpace(taskId))
            {
                Task = new EFDataModel.JobTasks();
                Task.JobId = jobId;
                Task.Jobs = DataAccessLayer.DBJobs.getJobById(jobId);
            }
            else
            {
                Task = DataAccessLayer.DALJob.getTask(jobId, taskId);
            }
        }
    }
}