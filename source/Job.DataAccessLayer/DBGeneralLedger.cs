using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Job.EFDataModel;

namespace Job.DataAccessLayer
{
    public class DBGeneralLedger
    {
        public static List<GLAccount> getGLAccounts()
        {
            List<GLAccount> list = new List<GLAccount>();
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    list = ctx.GLAccount.OrderBy(a => a.GLAccountCode).ToList();
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

        public static List<GeneralJournalLineEntries> getJournalLines(string accountCode, DateTime fromDate, DateTime toDate)
        {
            List<GeneralJournalLineEntries> _result = null;
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    _result = ctx.GeneralJournalLineEntries.Include("GeneralJournalLines").Where(l => l.GLAccountCode == accountCode && l.GeneralJournalLines.Date >= fromDate.Date && l.GeneralJournalLines.Date <= toDate).OrderBy(l => l.GeneralJournalLines.Date).ToList();
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

        public static decimal getGLAccountTotal(DateTime endDate, string accountCode, string debitCredit)
        {
            DateTime beginDate = new DateTime(endDate.Year, 1, 1);

            decimal _result = decimal.Zero;
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    var r = ctx.GeneralJournalLineEntries.Where(l => l.GLAccountCode == accountCode && l.Date >= beginDate.Date && l.Date < endDate && l.DebitCredit == debitCredit);
                    foreach (var i in r)
                    {
                        _result += i.Amount;
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

        public static GLAccount getGLAccountByCode(string accountCode)
        {
            GLAccount _result = null;
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    _result = ctx.GLAccount.Find(accountCode);
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

        public static List<System.Web.Mvc.SelectListItem> getDDLPurchaseGLAccount(string accountId)
        {
            List<System.Web.Mvc.SelectListItem> _result = new List<System.Web.Mvc.SelectListItem>();
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    var r = ctx.GLAccount.Where(a => a.Type == "E" && a.SubType.Trim() == "C").ToList();
                    foreach (var a in r)
                    {
                        _result.Add(new System.Web.Mvc.SelectListItem()
                        {
                            Value = a.GLAccountCode,
                            Text = string.Format("{0} {1}", a.GLAccountCode, a.Name),
                            Selected = (a.GLAccountCode == accountId)
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
    }
}
