using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job.WebMvc.Models.Person
{
    public class EditDialogPartnerTaxPaymentModel
    {
        public EFDataModel.Person People { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> DDLPerson { get; private set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> DDLBankAccount { get; private set; }
        public void LoadModelData()
        {
            this.DDLPerson = DataAccessLayer.DBPerson.getDDLPerson(this.People.PeopleId);
            this.DDLBankAccount = DataAccessLayer.DALBankAccount.getDDLBAnkAccount(null);

        }
    }
}