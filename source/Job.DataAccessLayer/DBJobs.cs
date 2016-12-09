using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Job.EFDataModel;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace Job.DataAccessLayer
{
    public class DBJobs
    {
        public static List<EFDataModel.WorksJournal> getJobWorkLog(int peopleId, long? customerId, DateTime beginDate, DateTime endDate)
        {
            List<EFDataModel.WorksJournal> result = new List<EFDataModel.WorksJournal>();
            try 
            {
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
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

        public static List<JobWorkList> getWorkedHours(long jobId)
        {
            List<JobWorkList> result = new List<JobWorkList>();
            try
            {
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
                {
                    result = db.JobWorkList.Where(l => l.JobId == jobId).OrderByDescending(l => l.YearMonth).ToList();
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

        public static decimal getTotalWorkedHours(long id)
        {
            decimal _result = 0;
            string cnnString = WebConfigurationManager.ConnectionStrings["JobSQLConnectionString"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cnnString))
            {
                try
                {
                    cnn.Open();
                    string sqlCmd = "SELECT SUM([WorkedHours]) as Ore FROM [Job].[WorksJournal] WHERE [JobId] = @JobId;";
                    SqlCommand cmdTotalHours = new SqlCommand(sqlCmd, cnn);
                    cmdTotalHours.CommandType = System.Data.CommandType.Text;
                    cmdTotalHours.Parameters.Add("@JobId", System.Data.SqlDbType.BigInt);
                    cmdTotalHours.Parameters["@JobId"].Value = id;
                    object o = cmdTotalHours.ExecuteScalar();
                    if (o != null)
                    {
                        if (o != System.DBNull.Value)
                        {
                            _result = Convert.ToDecimal(o);
                        }
                    }
                }
                catch (SqlException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    cnn.Close();
                }
            }
            return _result;
        }
        

        public static List<EFDataModel.WorksJournal> getWorksJournal(int peopleId, long customerId, DateTime beginDate, DateTime endDate)
        {
            List<EFDataModel.WorksJournal> result = new List<EFDataModel.WorksJournal>();
            try
            {
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
                {
                    result = db.WorksJournal.Include(x => x.Jobs).Include(jw => jw.Person).Include(jw => jw.Jobs.Customers).Include(x => x.JobTasks).Where(jl => (jl.Date >= beginDate && jl.Date <= endDate) && (jl.PeopleId == peopleId || peopleId == -1) && (jl.Jobs.CustomerId == customerId || customerId == -1)).OrderByDescending(jl => jl.Date).ToList();
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
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
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
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
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
        public static EFDataModel.Jobs Get(long jobId)
        {
            EFDataModel.Jobs result = new EFDataModel.Jobs();
            try
            {
                result.JobId = -1;
                result.CustomerId = -1;
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
                {
                    result = db.Jobs.Include(j => j.Customers).Where(j => j.JobId == jobId).FirstOrDefault();
                    List<EFDataModel.JobBalance> jb = db.JobBalance.Include(jj => jj.GLAccount).Where(jj => jj.JobId == jobId).ToList();
                    result.JobBalance.Clear();
                    result.JobBalance = jb;
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
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
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
        public static List<SelectListItem> getDDLJobSelectListItem(long jobId)
        {
            List<SelectListItem> _result = new List<SelectListItem>();
            try
            {
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;
                    var r  = db.Jobs.Include(j => j.Customers).Include(j => j.JobStatus).Where(j => j.Status == Jobs.STATE_OPERATIVA || j.JobId == jobId).ToList();
                    _result.Add(new SelectListItem()
                    {
                        Value = "-1",
                        Text = "<Selezionare la commessa>",
                        Selected = (jobId == -1)
                    });

                    foreach (var j in r)
                    {
                        
                        _result.Add(new SelectListItem()
                        {
                            Value = j.JobId.ToString(),
                            Text = j.Code.ToString() + " " + j.Description,
                            Selected = (j.JobId == jobId)
                        });
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

            return _result;
        }
  
       

        //public static List<EFDataModel.JobTasks> getJobTaskForDDL(bool productive)
        //{
        //    List<EFDataModel.JobTasks> result = new List<EFDataModel.JobTasks>();
        //    try 
        //    {
        //        using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
        //        {
        //            db.Configuration.ProxyCreationEnabled = false;
        //            db.Configuration.LazyLoadingEnabled = false;
        //            result = db.JobTasks.ToList();
        //        }
        //    }
        //    catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
        //    {
        //        throw e;
        //    }
        //    catch (System.Data.Entity.Infrastructure.DbUpdateException e)
        //    {
        //        throw e;
        //    }
        //    catch (System.Data.Entity.Validation.DbEntityValidationException e)
        //    {
        //        throw e;
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //    return result;
        //}
        public static List<EFDataModel.JobTasks> getJobTask(long jId)
        {
            List<EFDataModel.JobTasks> result = new List<EFDataModel.JobTasks>();
            try
            {
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
                {
                    db.Configuration.ProxyCreationEnabled = false;
                    db.Configuration.LazyLoadingEnabled = false;
                    result = db.JobTasks.Where(t =>t.JobId == jId).OrderBy(t => t.JobTaskId).ToList();
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
                using ( EFDataModel.JobEntities db = new EFDataModel.JobEntities())
                {
                    if (job.JobId < 1)
                    {
                        var r = db.upJobAdd(job.CustomerId, job.Code,job.Description,job.Year,job.Status);
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
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
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

        public static IEnumerable<EFDataModel.Jobs> getJobByCustomer(long? customerId)
        {
            List<EFDataModel.Jobs> result = new List<EFDataModel.Jobs>();
            long c = (customerId.HasValue ? customerId.Value : -1);
            try {
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
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
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
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
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
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
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
                {
                    tasks = db.JobTasks.ToList<EFDataModel.JobTasks>();
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
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
                {
                    tasks = db.JobTasks.ToList<EFDataModel.JobTasks>();
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
        public static List<EFDataModel.JobList> getJobList(long custId, byte[] filterStatus)
        {
            List<EFDataModel.JobList> result = new List<EFDataModel.JobList>();
            try
            {
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;
                    if ((filterStatus.Length < 1) && (custId < 1))
                    { 
                        result = db.JobList.ToList();
                    }
                    if (custId > 0 && (filterStatus.Length > 0))
                    {
                        result = db.JobList.Where(j => j.CustomerId == custId).ToList<EFDataModel.JobList>();
                    }
                    if ((custId > 0) && (filterStatus.Length < 1))
                    {
                        result = db.JobList.Where(j => j.CustomerId == custId).ToList<EFDataModel.JobList>();
                    }
                    if ((custId < 1) && (filterStatus.Length > 0))
                    {
                        result = (from j in db.JobList select j).ToList();
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
            catch (System.InvalidOperationException e)
            {
                throw e;
            }
            catch (System.ArgumentException e)
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
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
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
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
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


        public static void Create(int year, long? customerId, string description, byte status)
        {
            string cnnString = WebConfigurationManager.ConnectionStrings["JobSQLConnectionString"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cnnString))
            {
                SqlTransaction trn;
                cnn.Open();
                trn = cnn.BeginTransaction();

                try
                {
                    // Command Objects for the transaction
                    SqlCommand getId = new SqlCommand("[Job].[upGetElementNumber]", cnn);
                    getId.CommandType = System.Data.CommandType.StoredProcedure;
                    getId.Transaction = trn;
                    getId.Parameters.Add(new SqlParameter("@Element", System.Data.SqlDbType.NVarChar, 50));
                    getId.Parameters["@Element"].Value = "Job.Code";
                    getId.Parameters.Add(new SqlParameter("@Year", System.Data.SqlDbType.Int));
                    getId.Parameters["@Year"].Value = year;
                    getId.Parameters.Add(new SqlParameter("@ResultId", System.Data.SqlDbType.NVarChar, 20));
                    getId.Parameters["@ResultId"].Direction = System.Data.ParameterDirection.Output;
                    int r = getId.ExecuteNonQuery();
                    string jobCode = Convert.ToString(getId.Parameters["@ResultId"].Value);
                    if (string.IsNullOrWhiteSpace(jobCode))
                    {
                        trn.Rollback();
                    }
                    string sqlCmd = "INSERT INTO[Job].[Jobs] ([CustomerId], [Code], [Description], [Status], [Year]) ";
                    sqlCmd += "VALUES (@CustomerId, @Code, @Description, @Status, @Year);";
                    SqlCommand createJob = new SqlCommand(sqlCmd, cnn);
                    createJob.CommandType = System.Data.CommandType.Text;
                    createJob.Transaction = trn;
                    createJob.Parameters.Add(new SqlParameter("@CustomerId", System.Data.SqlDbType.BigInt));
                    createJob.Parameters["@CustomerId"].Value = customerId;
                    createJob.Parameters.Add(new SqlParameter("@Code", System.Data.SqlDbType.NVarChar, 20));
                    createJob.Parameters["@Code"].Value = jobCode;
                    createJob.Parameters.Add(new SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 512));
                    createJob.Parameters["@Description"].Value = description;
                    createJob.Parameters.Add(new SqlParameter("@Status", System.Data.SqlDbType.TinyInt));
                    createJob.Parameters["@Status"].Value = status;
                    createJob.Parameters.Add(new SqlParameter("@Year", System.Data.SqlDbType.Int));
                    createJob.Parameters["@Year"].Value = year;
                    createJob.ExecuteNonQuery();
                    trn.Commit();
                }
                catch (SqlException)
                {
                    trn.Rollback();
                    throw;
                }
                catch (Exception)
                {
                    trn.Rollback();
                    throw;
                }
                finally
                {
                    cnn.Close();
                    cnn.Dispose();
                }
            }
        }
    }

}
