using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using Job.EFDataModel;

namespace Job.DataAccessLayer
{
    public class DALJob
    {
        public static List<EFDataModel.JobList> getJobList(long custId, byte[] filterStatus)
        {
            List<EFDataModel.JobList> _result = new List<EFDataModel.JobList>();
            string sqlCmdWhere = " WHERE ";
            if (filterStatus.Length > 0)
            {
                string strStatus = string.Empty;
                foreach (var st in filterStatus)
                {
                    strStatus += st.ToString() + ",";
                }
                strStatus = strStatus.Substring(0, strStatus.Length - 1);
                sqlCmdWhere += "[Status] IN (" + strStatus + ")";
            }
            if (custId > 0)
            {
                if (sqlCmdWhere != " WHERE ")
                {
                    sqlCmdWhere += " AND ";
                }
                sqlCmdWhere += "[CustomerId] = " + custId.ToString();
            }
            string sqlCmdString = "SELECT [JobId],[CustomerId],[Code],[Description],[Status],[Year],[StatusDescription],[CustomerName],[CustomerName2],[CustomerFullName],[ActualHours],[ActualBegin],[ActualEnd] FROM [Job].[JobList]";
            if (sqlCmdWhere != " WHERE ")
            {
                sqlCmdString += sqlCmdWhere;
            }
            string cnnString = WebConfigurationManager.ConnectionStrings["JobSQLConnectionString"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cnnString))
            {
                try
                {
                    cnn.Open();
                    SqlCommand sqlCmd = new SqlCommand(sqlCmdString, cnn);
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    while (reader.Read())
                    {
                        _result.Add(new EFDataModel.JobList()
                        {
                            JobId = reader.GetInt64(0),
                            CustomerId = reader.GetInt64(1),
                            Code = (reader.IsDBNull(2) ? null : reader.GetString(2)),
                            Description = (reader.IsDBNull(3) ? null : reader.GetString(3)),
                            Status = reader.GetByte(4),
                            Year = reader.GetInt64(5),
                            StatusDescription = (reader.IsDBNull(6) ? null : reader.GetString(6)),
                            CustomerName = (reader.IsDBNull(7) ? null : reader.GetString(7)),
                            CustomerName2 = (reader.IsDBNull(8) ? null : reader.GetString(8)),
                            CustomerFullName = (reader.IsDBNull(9) ? null : reader.GetString(9)),
                            ActualHours = (reader.IsDBNull(10) ? decimal.Zero : reader.GetDecimal(10)),
                            ActualBegin = (reader.IsDBNull(11) ? (DateTime?) null : reader.GetDateTime(11)),
                            ActualEnd = (reader.IsDBNull(12) ? (DateTime?)null : reader.GetDateTime(12))
                        });
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

        public static JobTasks UpdateTask(JobTasks task)
        {
            JobTasks result = new JobTasks();
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    ctx.Configuration.LazyLoadingEnabled = false;
                    var t = ctx.JobTasks.Find(task.JobTaskId, task.JobId);
                    if (t == null)
                    {
                        ctx.JobTasks.Add(task);
                    }
                    else
                    {
                        //ctx.JobTasks.Attach(task);
                        //ctx.Entry(task).State = System.Data.Entity.EntityState.Modified;
                        ctx.Entry(t).CurrentValues.SetValues(task);
                    }

                    ctx.SaveChanges();
                }
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
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

        public static WorksJournal UpdateWorksLine(WorksJournal wj)
        {
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    ctx.Configuration.LazyLoadingEnabled = false;
                    var t = ctx.WorksJournal.Find(wj.WorkJournalId);
                    if (t == null)
                    {
                        ctx.WorksJournal.Add(wj);
                    }
                    else
                    {
                        ctx.Entry(t).CurrentValues.SetValues(wj);
                    }
                    ctx.SaveChanges();
                }
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
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
            return wj;
        }

        public static void DeleteWorksLine(long Id)
        {
            WorksJournal result = new WorksJournal();
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.WorksJournal.Remove(new EFDataModel.WorksJournal() { WorkJournalId = Id });
                    ctx.SaveChanges();
                }
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
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
        }
        public static List<JobTasks> getJobTasks(long jobId)
        {
            List<JobTasks> result = new List<JobTasks>();
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    ctx.Configuration.LazyLoadingEnabled = false;
                    result = ctx.JobTasks.Include("Jobs").Where(jt => jt.JobId == jobId).ToList();
                    foreach(var t in result)
                    {
                        t.Jobs.JobTasks?.Clear();
                        t.Jobs.JobBalance?.Clear();
                        t.Jobs.Customers = null;

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
        public static JobTasks getTask(long jobId, string taskId)
        {
            JobTasks result = new JobTasks();
            try
            {
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
                {
                    result = db.JobTasks.Include("Jobs").Where(jt => jt.JobId == jobId && jt.JobTaskId == taskId).FirstOrDefault();
                    result.WorksJournal.Clear();
                    result.Jobs.Customers = null;
                    result.Jobs.JobTasks.Clear();
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
        public static List<System.Web.Mvc.SelectListItem> getDDLJobTasks(long jobId, string selTaskId)
        {
            List<System.Web.Mvc.SelectListItem> list = new List<System.Web.Mvc.SelectListItem>();
            try
            {
                List<EFDataModel.JobTasks> tasks = null;
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
                {
                    tasks = db.JobTasks.Where(t => t.JobId == jobId).ToList<EFDataModel.JobTasks>();
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
    }
}
