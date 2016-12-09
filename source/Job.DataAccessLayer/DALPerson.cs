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
    public static class DALPerson
    {
        public static IEnumerable<System.Web.Mvc.SelectListItem> getPersonForDDL(int selectedPeopleId)
        {
            List<System.Web.Mvc.SelectListItem> _result = new List<System.Web.Mvc.SelectListItem>();
            string cnnString = WebConfigurationManager.ConnectionStrings["JobSQLConnectionString"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cnnString))
            {
                try
                {
                    cnn.Open();
                    string sqlCmdString = "SELECT [PeopleId], [FirstName], [LastName] FROM [Job].[Person] WHERE [ActiveState] = 1;";
                    SqlCommand sqlCmd = new SqlCommand(sqlCmdString, cnn);
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    while (reader.Read())
                    {
                        _result.Add(new System.Web.Mvc.SelectListItem()
                        {
                            Value = reader.GetInt32(0).ToString(),
                            Text = (reader.IsDBNull(1) ? string.Empty : reader.GetString(1) + " ")  + (reader.IsDBNull(2) ? string.Empty : reader.GetString(2)),
                            Selected = (reader.GetInt32(0) == selectedPeopleId)
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

        public static IEnumerable<PrePaymentRefound> getPrePaymentRefoundList(int requestById, DateTime fromDate, DateTime toDate)
        {
            List<PrePaymentRefound> result = null;
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    result = ctx.PrePaymentRefound.Include("Person").Include("GLAccount").Where(p => p.PeopleId == requestById && p.Date >= fromDate && p.Date <= toDate).ToList<PrePaymentRefound>();
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
            catch (System.NotSupportedException)
            {
                throw;
            }
            catch (System.ObjectDisposedException)
            {
                throw;
            }
            catch (System.InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public static PrePaymentRefound getPrePaymentRefound(long id)
        {
            PrePaymentRefound result = null;
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    result = ctx.PrePaymentRefound.Where(p => p.Id == id).FirstOrDefault<PrePaymentRefound>();
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
            catch (System.NotSupportedException)
            {
                throw;
            }
            catch (System.ObjectDisposedException)
            {
                throw;
            }
            catch (System.InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public static PrePaymentRefound createPrePaymentRefound(PrePaymentRefound epr)
        {
            try
            {
                epr.Status = EFDataModel.PrePaymentRefound.STATUS_BOZZA;
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    ctx.Entry(epr).State = System.Data.Entity.EntityState.Added;
                    ctx.SaveChanges();
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
            catch (System.NotSupportedException)
            {
                throw;
            }
            catch (System.ObjectDisposedException)
            {
                throw;
            }
            catch (System.InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return epr;
        }
    }
}
