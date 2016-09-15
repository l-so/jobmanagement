using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job.WebMvc.Models.Person
{
    public class ModalPeoplePaymentModel
    {
        public List<System.Web.Mvc.SelectListItem> DDLPerson { set; get; }
        public List<System.Web.Mvc.SelectListItem> DDLBankAccount { set; get; }
        public void loadModelData(string peopleId)
        {
            DDLPerson = DataAccessLayer.DBPerson.getDDLPerson(int.Parse(peopleId));
            DDLBankAccount = DataAccessLayer.DBPayment.getBankAccount();
            
        }
    }
}