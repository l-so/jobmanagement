using System;
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
    }
}
