using System;
using System.Collections.Generic;
using System.Linq;
using Job.EFDataModel;
namespace Job.DataAccessLayer
{
    public class DBPerson
    {
        public static List<System.Web.Mvc.SelectListItem> getDDLPerson(int peopleId)
        {
            List<System.Web.Mvc.SelectListItem> list = new List<System.Web.Mvc.SelectListItem>();
            try
            {
                List<EFDataModel.Person> pers = null;
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
                {
                    pers = db.Person.Where(c => c.ActiveState == true || (c.PeopleId == peopleId || peopleId == -1)).OrderBy(c => c.LastName).ToList<EFDataModel.Person>();
                }
                if (pers != null)
                {
                    foreach (var p in pers)
                    {
                        var item = new System.Web.Mvc.SelectListItem()
                        {
                            Value = p.PeopleId.ToString(),
                            Text = string.Format("[{0}] {1}", p.Code, p.FirstName.Trim() + " " + p.LastName.Trim()),
                            Selected = (p.PeopleId == peopleId)
                        };
                        list.Add(item);
                    }
                    if (peopleId < 1)
                    {
                        list.Insert(0, new System.Web.Mvc.SelectListItem()
                        {
                            Value = "-1",
                            Text = "<Selezionare la persona>",
                            Selected = true
                        });
                    }
                    else
                    {
                        list.Insert(0, new System.Web.Mvc.SelectListItem()
                        {
                            Value = "-1",
                            Text = "<Selezionare la persona>",
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

        public static List<ExpensePaymentRefound> getExpensePaymentRefound(int peopleId, DateTime fromDate, DateTime toDate)
        {
            List<ExpensePaymentRefound> _result = null;
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    _result = ctx.ExpensePaymentRefound.Include("Person").Include("GLAccount").Where(e => e.Date >= fromDate && e.Date <= toDate && (e.PeopleId == peopleId || peopleId == -1)).OrderBy(e => e.Date).ToList();
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

        public static ExpensePaymentRefound getExpensePaymentRefound(long id)
        {
            ExpensePaymentRefound _result = null;
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    _result = ctx.ExpensePaymentRefound.Find(id);
                    if (_result != null)
                    {
                        _result.GLAccount = DataAccessLayer.DBGeneralLedger.getGLAccountByCode(_result.GLAccountCode);
                        _result.GLAccount.GeneralJournalLineEntries.Clear();
                        _result.GLAccount.ExpensePaymentRefound.Clear();
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

        public static List<System.Web.Mvc.SelectListItem> getDDLPerson(string identityId)
        {
            List<System.Web.Mvc.SelectListItem> list = new List<System.Web.Mvc.SelectListItem>();
            try
            {
                List<EFDataModel.Person> pers = null;
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
                {
                    pers = db.Person.Where(c => c.ActiveState == true || c.IdentityId == identityId).OrderBy(c => c.LastName).ToList<EFDataModel.Person>();
                }
                if (pers != null)
                {
                    foreach (var p in pers)
                    {
                        var item = new System.Web.Mvc.SelectListItem()
                        {
                            Value = p.PeopleId.ToString(),
                            Text = p.FirstName.Trim() + " " + p.LastName.Trim(),
                            Selected = p.IdentityDefault
                        };
                        list.Add(item);
                    }
                    list.Insert(0, new System.Web.Mvc.SelectListItem()
                    {
                        Value = "-1",
                        Text = "<Selezionare la persona>",
                        Selected = false
                    });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return list;
        }

        public static EFDataModel.Person getOne(int peopleId)
        {
            EFDataModel.Person per = null;
            try {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    per = ctx.Person.Find(peopleId);
                    per.AspNetUsers = null;
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
            return per;
        }

        public static ExpensePaymentRefound ExpensePaymentRefoundCreate(ExpensePaymentRefound epr)
        {
            ExpensePaymentRefound _result = null;
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    ctx.Entry(epr).State = System.Data.Entity.EntityState.Added;
                    ctx.SaveChanges();
                    _result = epr;
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

        public static void ExpensePaymentRefoundRegister(int peopleId, int year, int month)
        {
            DateTime fromDate;
            DateTime toDate;
            if (month < 13)
            {
                fromDate = new DateTime(year, month, 1);
                toDate = new DateTime(year, month, DateTime.DaysInMonth(year,month));
            } else
            {
                fromDate = new DateTime(year, 1, 1);
                toDate = new DateTime(year, 12, 31);
            }
            try
            {
                List<EFDataModel.ExpensePaymentRefound> epr;
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    epr = ctx.ExpensePaymentRefound.Where(e => e.Date >= fromDate && e.Date <= toDate && e.PeopleId == peopleId).ToList();
                }
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    foreach (var i in epr)
                    {
                       var r = ctx.upPostExpensePaymentRefound(i.Id);
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
        }

        public static ExpensePaymentRefound ExpensePaymentRefoundUpdate(ExpensePaymentRefound epr)
        {
            ExpensePaymentRefound _result = null;
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    ctx.Entry(epr).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                    _result = epr;
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

        public static EFDataModel.Person getLoggedByUserId (string identityId) 
        {
            EFDataModel.Person per = null;
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    per = ctx.Person.Where(p => p.IdentityId == identityId && p.IdentityDefault == true).FirstOrDefault<EFDataModel.Person>();
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
            return per;
        }
        public static EFDataModel.Person getPeopleByIdentityUserName(string identityUserName)
        {
            EFDataModel.Person per = null;
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    EFDataModel.AspNetUsers a = ctx.AspNetUsers.Where(u => u.UserName == identityUserName).FirstOrDefault<EFDataModel.AspNetUsers>();
                    per = getLoggedByUserId(a.Id);
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
            return per;
        }
        public static IEnumerable<EFDataModel.Person> getAll(bool? active)
        {
            List<EFDataModel.Person> per = null;
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    per = ctx.Person.Include("AspNetUsers").Where(p => p.ActiveState == active || active == null).ToList<EFDataModel.Person>();
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
            return per;
        }

        public static EFDataModel.Person Create(string code, string lastName, string firstName, string companyName, bool identityDefault, string identityId, string carPlate, string carDescription, decimal carKmCost, bool activeState)
        {
            EFDataModel.Person p = null;
            try {
                p = new EFDataModel.Person();
                p.ActiveState = activeState;
                p.CarDescription = carDescription;
                p.CarKmCost = carKmCost;
                p.CarPlate = carPlate;
                p.CompanyName = companyName;
                p.IdentityId = identityId;
                p.IdentityDefault = identityDefault;
                p.Code = code;
                p.LastName = lastName;
                p.FirstName = firstName;
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
                {
                    db.Entry(p).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
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
            return p;
        }
        public static EFDataModel.Person Update(int peopleid, string code, string lastName, string firstName, string companyName, bool identityDefault, string identityId, string carPlate, string carDescription, decimal carKmCost, bool activeState)
        {
            EFDataModel.Person p = null;
            try
            {
                p = new EFDataModel.Person();
                p.PeopleId = peopleid;
                p.ActiveState = activeState;
                p.CarDescription = carDescription;
                p.CarKmCost = carKmCost;
                p.CarPlate = carPlate;
                p.CompanyName = companyName;
                p.IdentityId = identityId;
                p.IdentityDefault = identityDefault;
                p.Code = code;
                p.LastName = lastName;
                p.FirstName = firstName;
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
                {
                    db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
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
            return p;
        }
        
    }
}
