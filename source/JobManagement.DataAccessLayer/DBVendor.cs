using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobManagement.EFDataModel;

namespace JobManagement.DataAccessLayer
{
    public class DBVendor
    {
        public static List<Vendors> getVendorList(string filterName, int filterStatus)
        {
            List<EFDataModel.Vendors> _result = new List<EFDataModel.Vendors>();
            try
            {
                using (EFDataModel.JMContext ctx = new EFDataModel.JMContext())
                {
                    
                    if (filterStatus == 999)
                    {
                        _result = ctx.Vendors.Where(v => v.FullName.StartsWith(filterName) || filterName == null).ToList<EFDataModel.Vendors>();
                    } else
                    {
                        _result = ctx.Vendors.Where(v => (v.FullName.StartsWith(filterName) || filterName == null) && v.Status == filterStatus).ToList<EFDataModel.Vendors>();
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

        public static Vendors get(long v)
        {
            EFDataModel.Vendors _result = null;
            try
            {
                using (JMContext ctx = new JMContext())
                {
                    _result = ctx.Vendors.Find(v);
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

        public static Vendors Save(Vendors _ven)
        {
            Vendors _result = null; 
            try
            {
                using (JMContext ctx = new JMContext())
                {
                    if (_ven.VendorId < 1)
                    {
                        _ven.Status = EFDataModel.Vendors.STATUS_ACTIVE;
                        ctx.Entry(_ven).State = System.Data.Entity.EntityState.Added;
                    }
                    else
                    {
                        ctx.Entry(_ven).State = System.Data.Entity.EntityState.Modified;
                    }
                    ctx.SaveChanges();
                    _result = _ven;
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

        public static List<System.Web.Mvc.SelectListItem> getDDLVendor(long vendorId)
        {
            List<System.Web.Mvc.SelectListItem> _result = new List<System.Web.Mvc.SelectListItem>();
            try
            {
                using (EFDataModel.JMContext ctx = new EFDataModel.JMContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    var r = ctx.Vendors.Where(v => v.Status == 0 || v.VendorId == vendorId).ToList();
                    foreach (var a in r)
                    {
                        _result.Add(new System.Web.Mvc.SelectListItem()
                        {
                            Value = a.VendorId.ToString(),
                            Text = a.FullName,
                            Selected = (a.VendorId == vendorId)
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
