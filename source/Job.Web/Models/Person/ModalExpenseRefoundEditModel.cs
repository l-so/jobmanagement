using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Job.EFDataModel;

namespace Job.WebMvc.Models.Person
{
    public class ModalExpenseRefoundEditModel
    {
        internal EFDataModel.Person LoggedPeople { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> DDLPerson { get; private set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> DDLGLAccount { get; private set; }

        public EFDataModel.ExpensePaymentRefound Payment { get; private set; }
        
        public void loadData(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                this.Payment = new EFDataModel.ExpensePaymentRefound();
                this.Payment.Id = -1;
                this.Payment.PeopleId = LoggedPeople.PeopleId;
            } else
            {
                this.Payment = DataAccessLayer.DBPerson.getExpensePaymentRefound(long.Parse(id));
            }
            this.DDLGLAccount = DataAccessLayer.DBGeneralLedger.getDDLPurchaseGLAccount(this.Payment.GLAccountCode);
            this.DDLPerson = DataAccessLayer.DBPerson.getDDLPerson(this.Payment.PeopleId.Value);
        }
    }
}