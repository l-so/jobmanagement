﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobManagement.EFDataModel;

namespace JobManagement.DataAccessLayer
{
    public class DBGeneralLedger
    {
        public static List<GLAccount> getGLAccounts()
        {
            List<GLAccount> list = new List<GLAccount>();
            try
            {
                using (EFDataModel.JMContext ctx = new EFDataModel.JMContext())
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

        public static List<System.Web.Mvc.SelectListItem> getDDLPurchaseInvoiceGLAccount (string accountId)
        {
            List<System.Web.Mvc.SelectListItem> _result = new List<System.Web.Mvc.SelectListItem>();
            try
            {
                using (EFDataModel.JMContext ctx = new EFDataModel.JMContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    var r = ctx.GLAccount.Where(a => a.Type == "E" && a.SubType== "AC").ToList();
                    foreach (var a in r)
                    {
                        _result.Add(new System.Web.Mvc.SelectListItem()
                        {
                            Value = a.GLAccountCode,
                            Text = a.Name,
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
