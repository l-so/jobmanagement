using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Job.DataAccessLayer
{
    public class DALFinancial
    {
        public static IEnumerable<SelectListItem> getDDLExpenseAccount(string selectedGLAccountCode)
        {
            List<System.Web.Mvc.SelectListItem> list = new List<System.Web.Mvc.SelectListItem>();
            try
            {
                List<EFDataModel.GLAccount> expenseAccount = null;
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
                {
                    expenseAccount = db.GLAccount.Where(c => c.EconomicoPatrimoniale == "E" && c.CostoRicavo == "C" & c.TotaleAnalitico == "A").OrderBy(c => c.GLAccountCode).ToList<EFDataModel.GLAccount>();
                }
                if (expenseAccount != null)
                {
                    foreach (var ea in expenseAccount)
                    {
                        var item = new System.Web.Mvc.SelectListItem()
                        {
                            Value = ea.GLAccountCode,
                            Text = string.Format("[{0}] {1}", ea.GLAccountCode, ea.Name),
                            Selected = (ea.GLAccountCode == selectedGLAccountCode)
                        };
                        list.Add(item);
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
            return list;
        }
    }
}
