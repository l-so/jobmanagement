using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Job.DataAccessLayer
{
    public static class DBPayment
    {
        public static void PeoplePayment(DateTime _date, int _peopleId, decimal _compenso, decimal _tasse, decimal _inps, string _bankAccount)
        {
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    ctx.upPostPaymentToPerson( _date, _peopleId, _compenso, _tasse , _inps, _bankAccount);
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
        }

        public static List<SelectListItem> getBankAccount()
        {
            List<SelectListItem> _result = new List<SelectListItem>();
            List<EFDataModel.BankAccounts> ba = null;
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    ba = ctx.BankAccounts.ToList();
                }
                if (ba != null)
                {
                    foreach (var b in ba)
                    {
                        var item = new System.Web.Mvc.SelectListItem()
                        {
                            Value = b.Code,
                            Text = b.BankName
                        };
                        _result.Add(item);
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
            return _result;
        }
    }
}
