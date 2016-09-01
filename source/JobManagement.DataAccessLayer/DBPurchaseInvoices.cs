using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using JobManagement.EFDataModel;

namespace JobManagement.DataAccessLayer
{
    public class DBPurchaseInvoices
    {
        public static PurchaseInvoices getById(long id)
        {
            PurchaseInvoices _result = new PurchaseInvoices();
            try
            {
                using (EFDataModel.JMContext ctx = new EFDataModel.JMContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    _result = ctx.PurchaseInvoices.Find(id);
                    if (_result.BuyFromVendorId.HasValue)
                    {
                        _result.Vendors = ctx.Vendors.Find(_result.BuyFromVendorId.Value);
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

        public static List<SelectListItem> getDDLPaidBy(int? paidById)
        {
            int selectedId = (paidById.HasValue ? paidById.Value : -1);
            List <System.Web.Mvc.SelectListItem> _result = new List<System.Web.Mvc.SelectListItem>();
            try
            {
                using (EFDataModel.JMContext ctx = new EFDataModel.JMContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    var r = ctx.PurchaseInvoicePaidBy.ToList();
                    foreach (var a in r)
                    {
                        _result.Add(new System.Web.Mvc.SelectListItem()
                        {
                            Value = a.PurchaseInvoicePaidById.ToString(),
                            Text = a.Name,
                            Selected = (a.PurchaseInvoicePaidById == selectedId)
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
