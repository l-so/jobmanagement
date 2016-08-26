using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JobManagement.DataAccessLayer
{
    public class DBTravelExpense
    {

        public static object GetTravelExpenseInMonth(int peopleId, int m, int y)
        {
            DateTime fromDate = new DateTime(y, m, 1);
            DateTime toDate = new DateTime(y, m, DateTime.DaysInMonth(y, m));
            List<EFDataModel.TravelExpenseList> _result = new List<EFDataModel.TravelExpenseList>();
            try
            {
                using (EFDataModel.JMContext ctx = new EFDataModel.JMContext())
                {
                    _result = ctx.TravelExpenseList.Where(t => t.PeopleId == peopleId && t.Date >= fromDate && t.Date <= toDate).ToList<EFDataModel.TravelExpenseList>();
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

        public static EFDataModel.TravelExpenses getOne(string travelExpenseCode)
        {
            EFDataModel.TravelExpenses _result = null;
            try
            {
                using (EFDataModel.JMContext ctx = new EFDataModel.JMContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    _result = ctx.TravelExpenses.Find(travelExpenseCode);
                    _result.Person = ctx.Person.Find(_result.PeopleId);
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

        public static EFDataModel.TravelExpenseList getOneFromList(string travelExpenseCode)
        {
            EFDataModel.TravelExpenseList _result = null;
            try
            {
                using (EFDataModel.JMContext ctx = new EFDataModel.JMContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    _result = ctx.TravelExpenseList.Where(t => t.TravelExpenseCode == travelExpenseCode).FirstOrDefault<EFDataModel.TravelExpenseList>();
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
            return _result;
        }


        public static List<EFDataModel.TravelExpensesLines> getLines(string travelExpenseCode)
        {
            List<EFDataModel.TravelExpensesLines> _result = new List<EFDataModel.TravelExpensesLines>();
            try
            {
                using (EFDataModel.JMContext ctx = new EFDataModel.JMContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    _result = ctx.TravelExpensesLines.Include("TravelExpenseLineCategories").Where(tel => tel.TravelExpenseCode == travelExpenseCode).ToList<EFDataModel.TravelExpensesLines>();
                    foreach (var l in _result)
                    {
                        if (l.TravelExpenseLineCategories != null)
                        {
                            if (l.TravelExpenseLineCategories.TravelExpensesLines != null)
                            {
                                if (l.TravelExpenseLineCategories.TravelExpensesLines.Count != 0)
                                {
                                    l.TravelExpenseLineCategories.TravelExpensesLines.Clear();
                                }
                            }
                        }
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

        public static string PostTravelExpenseRequest(string travelExpenseCode)
        {
            string _result = "OK";
            try
            {
                using (EFDataModel.JMContext ctx = new EFDataModel.JMContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    ctx.upPostTravelExpense(travelExpenseCode);
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

        public static EFDataModel.TravelExpensesLines LineGet(long id)
        {
            EFDataModel.TravelExpensesLines _result = new EFDataModel.TravelExpensesLines();
            try
            {
                using (EFDataModel.JMContext ctx = new EFDataModel.JMContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    _result = ctx.TravelExpensesLines.Find(id);
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

        public static void LineDelete()
        {

        }

        public static List<System.Web.Mvc.SelectListItem> getLineCategory()
        {
            List<System.Web.Mvc.SelectListItem> list = new List<System.Web.Mvc.SelectListItem>();
            try
            {
                List<EFDataModel.TravelExpenseLineCategories> lineCategories = null;
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
                {
                    lineCategories = db.TravelExpenseLineCategories.ToList<EFDataModel.TravelExpenseLineCategories>();
                }
                if (lineCategories != null)
                {
                    foreach (var t in lineCategories)
                    {
                        var item = new System.Web.Mvc.SelectListItem()
                        {
                            Value = t.TravelExpenseLineCategoryId.ToString(),
                            Text = t.Description
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

        public static EFDataModel.TravelExpenseLineCategories getCarLineCategory()
        {
            EFDataModel.TravelExpenseLineCategories result = null;
            try
            {
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
                {
                    result = db.TravelExpenseLineCategories.Where(c => c.UsePersonalCar == true).FirstOrDefault<EFDataModel.TravelExpenseLineCategories>();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        public static DBTravelExpenseLineUpdateResult LineUpdate(JobManagement.EFDataModel.TravelExpensesLines tel)
        {
            DBTravelExpenseLineUpdateResult _res = new DBTravelExpenseLineUpdateResult();
            try
            {
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
                {
                    if (tel.TravelExpenseLineId > 0)
                    {
                        db.Entry(tel).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(tel).State = System.Data.Entity.EntityState.Added;
                    }
                    db.SaveChanges();
                    _res.Rows = db.TravelExpensesLines.Include("TravelExpenseLineCategory").Where(t => t.TravelExpenseCode == tel.TravelExpenseCode).OrderBy(t => t.Date).ToList();
                    _res.Total = 0;
                    foreach (EFDataModel.TravelExpensesLines t in _res.Rows)
                    {
                        _res.Total += t.Amount;
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
            return _res;
        }

        public static EFDataModel.TravelExpenses Update(string teCode, int tePeopleId, string teTypeId, DateTime teDate, string teDescription)
        {

            EFDataModel.TravelExpenses te = null;
            try
            {
                te = new EFDataModel.TravelExpenses();
                using (EFDataModel.JMContext ctx = new EFDataModel.JMContext())
                {
                    if (string.IsNullOrWhiteSpace(teCode))
                    {
                        ctx.Configuration.LazyLoadingEnabled = false;
                        ctx.Configuration.ProxyCreationEnabled = false;
                        EFDataModel.upTravelExpenseAdd_Result r = ctx.upTravelExpenseAdd(teDate, teDescription, tePeopleId).FirstOrDefault<EFDataModel.upTravelExpenseAdd_Result>();
                        te.TravelExpenseCode = r.TravelExpenseCode;
                        te.Status = r.Status;
                        te.PeopleId = r.PeopleId;
                        te.Person = DataAccessLayer.DBPeople.getOne(te.PeopleId);
                        te.Date = r.Date;
                        te.Annotation = r.Annotation;
                    }
                    else
                    {
                        te.TravelExpenseCode = teCode;
                        te.PeopleId = tePeopleId;
                        te.Date = teDate;
                        te.Annotation = te.Annotation;
                        ctx.Entry(te).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                        if (te.Person == null)
                        {
                            te.Person = DataAccessLayer.DBPeople.getOne(te.PeopleId);
                        }
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
            return te;
        }

        public static string LoadTravelExpensJobs(string travelExpenseCode)
        {
            string _res = null;
            try
            {
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
                {
                    var q = from p in db.TravelExpenseJobsList
                            where p.TravelExpenseCode == travelExpenseCode
                            select new { p.TravelExpenseCode, p.JobId, p.Code, p.Description, p.InPercent, p.Amount };
                    _res = Newtonsoft.Json.JsonConvert.SerializeObject(q);
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
            catch (System.InvalidOperationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return _res;
        }
        public static string AssignJob(string travelExpenseCode, long teJobJobId, decimal tePercent)
        {
            string _res = null;
            EFDataModel.TravelExpenseJobs tej = new EFDataModel.TravelExpenseJobs()
            {
                TravelExpenseCode = travelExpenseCode,
                JobId = teJobJobId,
                InPercent = tePercent
            };
            try
            {
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
                {
                    var o = db.TravelExpenseJobs.Find(tej.TravelExpenseCode, tej.JobId);
                    if (o != null)
                    {
                        db.TravelExpenseJobs.Remove(o);
                        db.SaveChanges();
                    }
                    db.Entry(tej).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    var q = from p in db.TravelExpenseJobsList
                            where p.TravelExpenseCode == travelExpenseCode
                            select new { p.TravelExpenseCode, p.JobId, p.Code, p.Description, p.Amount };
                    _res = Newtonsoft.Json.JsonConvert.SerializeObject(q);
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
            catch (System.InvalidOperationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return _res;
        }

        public static void RemoveJobs(string travelExpenseCode, long jobsId)
        {
            try
            {
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
                {
                    var o = db.TravelExpenseJobs.Find(travelExpenseCode, jobsId);
                    if (o != null)
                    {
                        db.TravelExpenseJobs.Remove(o);
                        db.SaveChanges();
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
            catch (System.InvalidOperationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
