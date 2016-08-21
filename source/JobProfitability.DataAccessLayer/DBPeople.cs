using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.DataAccessLayer
{
    public class DBPeople
    {
        public static List<System.Web.Mvc.SelectListItem> getPeopleDDL(int peopleId)
        {
            List<System.Web.Mvc.SelectListItem> list = new List<System.Web.Mvc.SelectListItem>();
            try
            {
                List<EFDataModel.Person> pers = null;
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
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
                            Text = p.FirstName.Trim() + " " + p.LastName.Trim(),
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
        public static List<System.Web.Mvc.SelectListItem> getPeopleDDL(string identityId)
        {
            List<System.Web.Mvc.SelectListItem> list = new List<System.Web.Mvc.SelectListItem>();
            try
            {
                List<EFDataModel.Person> pers = null;
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
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
                using (EFDataModel.JMContext ctx = new EFDataModel.JMContext())
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
        public static EFDataModel.Person getLoggedByUserId (string identityId) 
        {
            EFDataModel.Person per = null;
            try
            {
                using (EFDataModel.JMContext ctx = new EFDataModel.JMContext())
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
                using (EFDataModel.JMContext ctx = new EFDataModel.JMContext())
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
                using (EFDataModel.JMContext ctx = new EFDataModel.JMContext())
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
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
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
                using (EFDataModel.JMContext db = new EFDataModel.JMContext())
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
