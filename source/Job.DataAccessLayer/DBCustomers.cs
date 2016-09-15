using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Job.DataAccessLayer
{
    public class DBCustomers
    {
        public static IEnumerable<EFDataModel.Customers> getCustomerList(short status)
        {
            List<EFDataModel.Customers> result = new List<EFDataModel.Customers>();
            using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
            {
                result = db.Customers.Where(c => c.Status == status || status == -1).OrderBy(c => c.FullName).ToList<EFDataModel.Customers>();
            }
            return result;
        }
        public static IEnumerable<EFDataModel.Customers> getCustomerList(string custFullName, short status)
        {
            List<EFDataModel.Customers> result = new List<EFDataModel.Customers>();
            using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
            {
                result = db.Customers.Where(c => (c.Status == status || status == -1) && c.FullName.StartsWith(custFullName)).OrderBy(c => c.FullName).ToList<EFDataModel.Customers>();
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
                    cust = db.Customers.Where(c => c.Status == EFDataModel.Customers.STATUS_ACTIVE || c.CustomerId == currentCustomer).OrderBy(c => c.FullName).ToList<EFDataModel.Customers>();
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
                    if (currentCustomer < 1)
                    {
                        list.Insert(0, new SelectListItem()
                        {
                            Value = "-1",
                            Text = "<Selezionare il cliente>",
                            Selected = true
                        });
                    }
                    else {
                        list.Insert(0, new SelectListItem()
                        {
                            Value = "-1",
                            Text = "<Selezionare il cliente>",
                            Selected = false
                        });
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
                        customer.Status = EFDataModel.Customers.STATUS_ACTIVE;
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
