using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JobManagement.DataAccessLayer
{
    public class DBJobs
    {
        public static List<EFDataModel.WorksJournal> getJobWorkLog(int peopleId, long? customerId, DateTime beginDate, DateTime endDate)
        {
            List<EFDataModel.WorksJournal> result = new List<EFDataModel.WorksJournal>();
            try 
            {
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
                {
                    result = db.WorksJournal.Include("Jobs").Include(jw => jw.Person).Include(jw => jw.Jobs.Customers).Include("JobTask").Where(jl => (jl.Date >= beginDate && jl.Date <= endDate) && (jl.PeopleId == peopleId || peopleId == -1) && (jl.Jobs.CustomerId == customerId || customerId == null)).OrderByDescending(jl => jl.Date).ToList();
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e) 
            {
                throw e;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        public static List<EFDataModel.WorksJournal> getWorksJournal(int peopleId, long customerId, DateTime beginDate, DateTime endDate)
        {
            List<EFDataModel.WorksJournal> result = new List<EFDataModel.WorksJournal>();
            try
            {
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
                {
                    result = db.WorksJournal.Include("Jobs").Include(jw => jw.Person).Include(jw => jw.Jobs.Customers).Include("JobTask").Where(jl => (jl.Date >= beginDate && jl.Date <= endDate) && (jl.PeopleId == peopleId || peopleId == -1) && (jl.Jobs.CustomerId == customerId || customerId == -1)).OrderByDescending(jl => jl.Date).ToList();
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        public static List<EFDataModel.WorksJournal> getJobWorkLog(int peopleId, DateTime beginDate, DateTime endDate)
        {
            List<EFDataModel.WorksJournal> result = new List<EFDataModel.WorksJournal>();
            try 
            {
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
                {
                    db.Configuration.ProxyCreationEnabled = false;
                    db.Configuration.LazyLoadingEnabled = false;
                    result = db.WorksJournal.Include("Jobs").Include("JobTask").Where(jl => (jl.Date >= beginDate && jl.Date <= endDate) && jl.PeopleId == peopleId).OrderByDescending(jl => jl.Date).ToList();
                }
                foreach (EFDataModel.WorksJournal e in result)
                {
                    e.Jobs.WorksJournal.Clear();
                    e.JobTasks.WorksJournal.Clear();
                }
             }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e) 
            {
                throw e;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        public static EFDataModel.Jobs getJobById(long jobId)
        {
            EFDataModel.Jobs result = new EFDataModel.Jobs();
            try 
            {
                result.JobId = -1;
                result.CustomerId = -1;
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
                {
                    result = db.Jobs.Include(j => j.Customers).Where(j => j.JobId == jobId).FirstOrDefault();
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e) 
            {
                throw e;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        public static List<EFDataModel.Jobs> getJobOpen(long jobId)
        {
            List<EFDataModel.Jobs> result = new List<EFDataModel.Jobs>();
            try
            {
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;
                    if (jobId > 0) { 
                        result = db.Jobs.Include(j => j.Customers).Include(j => j.JobStatus).Where(j => j.Status == 10 || j.JobId == jobId).ToList();
                    }
                    else
                    {
                        result = db.Jobs.Include(j => j.Customers).Include(j => j.JobStatus).Where(j => j.Status == 10).ToList();
                    }
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        public static List<EFDataModel.Jobs> getJobForDDL(long jobId)
        {
            List<EFDataModel.Jobs> result = new List<EFDataModel.Jobs>();
            try {
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;
                    result = db.Jobs.Include(j => j.Customers).Include(j => j.JobStatus).Where(j => j.Status == 10 || j.JobId == jobId).ToList();
                }
             }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e) 
            {
                throw e;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        public static List<EFDataModel.Jobs> getJobForDDL()
        {
            List<EFDataModel.Jobs> result = new List<EFDataModel.Jobs>();
            try {
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;
                    result = db.Jobs.Include(j => j.Customers).Include(j => j.JobStatus).Where(j => j.Status == 10).ToList();
                }
                result.Insert(0, new EFDataModel.Jobs() { JobId = -1, Description = "<Seleziona una commessa>" });
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e) 
            {
                throw e;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        public static List<EFDataModel.JobTasks> getJobTaskForDDL(bool productive)
        {
            List<EFDataModel.JobTasks> result = new List<EFDataModel.JobTasks>();
            try 
            {
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
                {
                    db.Configuration.ProxyCreationEnabled = false;
                    db.Configuration.LazyLoadingEnabled = false;
                    result = db.JobTasks.Where(j => j.NoWorkTask != productive).ToList();
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        public static void Update(EFDataModel.Jobs job) {
            try 
            {
                using ( EFDataModel.JMContext db = new EFDataModel.JMContext())
                {
                    if (job.JobId < 1)
                    {
                        var r = db.upJobAdd(job.CustomerId, job.Code,job.Description,job.ExpectedWorkHours,job.ExpectedIncome,job.ExpectedCost,job.ExpectedStartDate,job.ExpectedFinishDate,job.Year,job.Status);
                    }
                    else
                    {
                        db.Entry(job).State = EntityState.Modified;
                        db.Entry(job).Property(x => x.Code).IsModified = false;
                        db.SaveChanges();
                    }
                    
                }
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static EFDataModel.WorksJournal getWorksJournalById(long WorksJournalId)
        {
            EFDataModel.WorksJournal r = null;
            try {
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
                {
                    db.Configuration.ProxyCreationEnabled = false;
                    r = db.WorksJournal.Find(WorksJournalId);
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return r;
        }
        public static void UpdateJobWorkLog(EFDataModel.WorksJournal WorksJournal)
        {
            using (EFDataModel.JMContext db = new EFDataModel.JMContext())
            {
                if (WorksJournal.WorkJournalId < 1)
                {
                    db.Entry(WorksJournal).State = EntityState.Added;
                }
                else
                {
                    db.Entry(WorksJournal).State = EntityState.Modified;
                }
                db.SaveChanges();
            }
        }
        public static IEnumerable<EFDataModel.Jobs> getJobByCustomer(long? customerId)
        {
            List<EFDataModel.Jobs> result = new List<EFDataModel.Jobs>();
            long c = (customerId.HasValue ? customerId.Value : -1);
            try {
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;
                    if (c > 0) {
                        result = db.Jobs.Include(j => j.JobStatus).Include(j => j.Customers).Where(j => j.CustomerId == c).ToList();
                    }
                    else
                    {
                        result = db.Jobs.Include("JobStatus").Include(j => j.Customers).ToList();
                    }
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e) 
            {
                throw e;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        public static System.Web.Mvc.JsonResult WorksJournalDelete(int WorksJournalId)
        {
            System.Web.Mvc.JsonResult r = new System.Web.Mvc.JsonResult() { Data = new { ErrorResult = "OK", ErrorMessage = "" } };
            try { 
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
                {
                    EFDataModel.WorksJournal j = new EFDataModel.WorksJournal() { WorkJournalId = WorksJournalId };
                    db.Entry(j).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e) 
            {
                throw e;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return r;
        }
        public static List<EFDataModel.upOreMensiliLavorateGiornaliero_Result> getOneMonthTotalDayWorkedHoursForResource(DateTime beginDate, int peopleId)
        {
            List<EFDataModel.upOreMensiliLavorateGiornaliero_Result> result = null;
            try
            {
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
                {
                    result = db.upOreMensiliLavorateGiornaliero(peopleId, beginDate).ToList<EFDataModel.upOreMensiliLavorateGiornaliero_Result>();
                }
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        public static List<System.Web.Mvc.SelectListItem> getJobTask(string selTaskId)
        {
            List<System.Web.Mvc.SelectListItem> list = new List<System.Web.Mvc.SelectListItem>();
            try
            {
                List<EFDataModel.JobTasks> tasks = null;
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
                {
                    tasks = db.JobTasks.Where(t => t.NoWorkTask == false).ToList<EFDataModel.JobTasks>();
                }
                if (tasks != null)
                {
                    foreach (var t in tasks)
                    {
                        var item = new System.Web.Mvc.SelectListItem()
                        {
                            Value = t.JobTaskId,
                            Text = t.Description,
                            Selected = (t.JobTaskId == selTaskId)
                        };
                        list.Add(item);
                    }
                    
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return list;
        }
        public static IEnumerable<System.Web.Mvc.SelectListItem> getJobNoWorkTask()
        {
            List<System.Web.Mvc.SelectListItem> list = new List<System.Web.Mvc.SelectListItem>();
            try
            {
                List<EFDataModel.JobTasks> tasks = null;
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
                {
                    tasks = db.JobTasks.Where(t => t.NoWorkTask == true).ToList<EFDataModel.JobTasks>();
                }
                if (tasks != null)
                {
                    foreach (var t in tasks)
                    {
                        var item = new System.Web.Mvc.SelectListItem()
                        {
                            Value = t.JobTaskId,
                            Text = t.Description
                        };
                        list.Add(item);
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return list;
        }
        public static List<EFDataModel.JobList> getJobList(long custId, short[] filterStatus)
        {
            List<EFDataModel.JobList> result = new List<EFDataModel.JobList>();
            try
            {
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;
                    if ((filterStatus.Length < 1) && (custId < 1))
                    { 
                        result = db.JobList.ToList<EFDataModel.JobList>();
                    }
                    if (custId > 0 && (filterStatus.Length > 0))
                    {
                        result = db.JobList.Where(j => j.CustomerId == custId && filterStatus.Contains(j.Status)).ToList<EFDataModel.JobList>();
                    }
                    if ((custId > 0) && (filterStatus.Length < 1))
                    {
                        result = db.JobList.Where(j => j.CustomerId == custId).ToList<EFDataModel.JobList>();
                    }
                    if ((custId < 1) && (filterStatus.Length > 0))
                    {
                        result = db.JobList.Where(j => filterStatus.Contains(j.Status)).ToList<EFDataModel.JobList>();
                    }
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        public static IEnumerable<System.Web.Mvc.SelectListItem> getJobForDDL(long jobId, short[] status)
        {
            List<System.Web.Mvc.SelectListItem> list = new List<System.Web.Mvc.SelectListItem>();
            List<EFDataModel.Jobs> jl = new List<EFDataModel.Jobs>();
            try
            {
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;
                    jl = db.Jobs.Where(j => status.Contains(j.Status) || j.JobId == jobId).ToList();
                }
                if (jl.Count > 0)
                {
                    foreach (var t in jl)
                    {
                        var item = new System.Web.Mvc.SelectListItem()
                        {
                            Value = t.JobId.ToString(),
                            Text = t.Code + " " + t.Description
                        };
                        list.Add(item);
                    }

                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return list;
        }

        public static IEnumerable<System.Web.Mvc.SelectListItem> getStatusSelectListItem(byte currentStatus)
        {
            List<System.Web.Mvc.SelectListItem> list = new List<System.Web.Mvc.SelectListItem>();
            try
            {
                List<EFDataModel.JobStatus> cust = null;
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
                {
                    cust = db.JobStatus.OrderBy(c => c.JobStateId).ToList<EFDataModel.JobStatus>();
                }
                if (cust != null)
                {
                    foreach (var c in cust)
                    {
                        var item = new SelectListItem()
                        {
                            Value = c.JobStateId.ToString(),
                            Text = c.Description,
                            Selected = (c.JobStateId == currentStatus)
                        };
                        list.Add(item);
                    }
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException)
            {
                throw;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                throw;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
    }

}
