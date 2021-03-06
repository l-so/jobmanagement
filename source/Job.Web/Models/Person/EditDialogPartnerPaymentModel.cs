﻿using System.Collections.Generic;

namespace Job.WebMvc.Models.Person
{
    public class EditDialogPartnerPaymentModel
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