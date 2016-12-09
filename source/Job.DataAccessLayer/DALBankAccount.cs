using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Job.DataAccessLayer
{
    public class DALBankAccount
    {
        public static List<EFDataModel.BankAccounts> getJobTasks(long jobId)
        {
            List<EFDataModel.BankAccounts> result = new List<EFDataModel.BankAccounts>();
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    ctx.Configuration.LazyLoadingEnabled = false;
                    result = ctx.BankAccounts.ToList();
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

        public static IEnumerable<SelectListItem> getDDLBAnkAccount(string id)
        {
            List<SelectListItem> _result = new List<SelectListItem>();
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.ProxyCreationEnabled = false;
                    ctx.Configuration.LazyLoadingEnabled = false;
                    var tmp = ctx.BankAccounts.ToList();
                    if (tmp.Count == 1)
                    {
                        _result.Add(new System.Web.Mvc.SelectListItem()
                        {
                            Value = tmp[0].Code,
                            Text = tmp[0].BankName,
                            Selected = true
                        });
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(id))
                        {
                            _result.Add(new System.Web.Mvc.SelectListItem()
                            {
                                Value = string.Empty,
                                Text = "<Selezionare il conto corrente>",
                                Selected = true
                            });
                        }
                        foreach (var t in tmp)
                        {
                            _result.Add(new System.Web.Mvc.SelectListItem()
                            {
                                Value = t.Code,
                                Text = t.BankName,
                                Selected = (t.Code == id)
                            });
                        }
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
