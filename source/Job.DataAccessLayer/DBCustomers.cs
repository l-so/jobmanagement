using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Job.DataAccessLayer
{
    public class DBCustomers
    {
        public static IEnumerable<EFDataModel.Customers> getCustomerList()
        {
            List<EFDataModel.Customers> result = new List<EFDataModel.Customers>();
            using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
            {
                result = db.Customers.OrderBy(c => c.FullName).ToList<EFDataModel.Customers>();
            }
            return result;
        }
        public static IEnumerable<EFDataModel.Customers> getCustomerList(bool isActive)
        {
            List<EFDataModel.Customers> result = new List<EFDataModel.Customers>();
            using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
            {
                result = db.Customers.Where(c => c.IsActive == isActive && c.IsInternal == false).OrderBy(c => c.FullName).ToList<EFDataModel.Customers>();
            }
            return result;
        }
        public static IEnumerable<EFDataModel.Customers> getCustomerList(string filterFullName)
        {
            List<EFDataModel.Customers> result = new List<EFDataModel.Customers>();
            using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
            {
                result = db.Customers.Where(c => c.IsInternal == false && c.FullName.StartsWith(filterFullName)).OrderBy(c => c.FullName).ToList<EFDataModel.Customers>();
            }
            return result;
        }
        public static IEnumerable<EFDataModel.Customers> getInternalCustomerList()
        {
            List<EFDataModel.Customers> result = new List<EFDataModel.Customers>();
            using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
            {
                result = db.Customers.Where(c => c.IsInternal == true).OrderBy(c => c.FullName).ToList<EFDataModel.Customers>();
            }
            return result;
        }

        public static IEnumerable<SelectListItem> getCustomerSelectListItem(long currentCustomer)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try 
            { 
                List<EFDataModel.Customers> cust = null;
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
                {
                    cust = db.Customers.Where(c => (c.IsInternal == false && c.IsActive == true) || c.CustomerId == currentCustomer).OrderBy(c => c.FullName).ToList<EFDataModel.Customers>();
                }
                if (cust != null)
                {
                    foreach (var c in cust)
                    {
                        var item = new SelectListItem()
                        {
                            Value = c.CustomerId.ToString(),
                            Text = c.FullName,
                            Selected = (c.CustomerId == currentCustomer)
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
        public static IEnumerable<SelectListItem> getCustomerBusinessGroupList(string selected)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                List<EFDataModel.CustomerBusinessGroup> cbg = null;
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
                {
                    cbg = db.CustomerBusinessGroup.ToList<EFDataModel.CustomerBusinessGroup>();
                }
                if (cbg != null)
                {
                    foreach (var c in cbg)
                    {
                        var item = new SelectListItem()
                        {
                            Value = c.CustomerBusinessGroupId,
                            Text = c.CustomerBusinessGroupId,
                            Selected = (c.CustomerBusinessGroupId == selected)
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
        public static EFDataModel.Customers getCutomerById(long customerId)
        {
            using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
            {
                return db.Customers.Find(customerId);
            }
        }
        public static JsonResult Update(EFDataModel.Customers customer)
        {
            JsonResult _result = null;
            if (string.IsNullOrWhiteSpace(customer.Name2))
            {
                customer.Name2 = null;
            }
            if (string.IsNullOrWhiteSpace(customer.Address1))
            {
                customer.Address1 = null;
            }
            if (string.IsNullOrWhiteSpace(customer.State))
            {
                customer.State = null;
            }
            if (string.IsNullOrWhiteSpace(customer.Country))
            {
                customer.Country = "Italia";
            }
            try
            {
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
                {
                    if (customer.CustomerId < 1)
                    {
                        customer.IsActive = true;
                        customer.IsInternal = false;
                        db.Entry(customer).State = EntityState.Added;
                    }
                    else
                    {
                        db.Entry(customer).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
                _result = new JsonResult() { Data = new { ErrorResult = "OK", ErrorMessage =  ""} };
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
            {
                _result = new JsonResult() { Data = new { ErrorResult = "KO", ErrorMessage = e.Message } };
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                _result = new JsonResult() { Data = new { ErrorResult = "KO", ErrorMessage = e.Message } };
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                _result = new JsonResult() { Data = new { ErrorResult = "KO", ErrorMessage = e.Message } };
            }
            catch (Exception e)
            {
                _result = new JsonResult() { Data = new { ErrorResult = "KO", ErrorMessage = e.Message } };
            }
            return _result;
        }
    }
}
