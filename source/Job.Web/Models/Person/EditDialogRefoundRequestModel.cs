using System.Collections.Generic;

namespace Job.WebMvc.Models.Person
{
    public class EditDialogPrePaymentRefoundModel
    {
        public EFDataModel.PrePaymentRefound Refound { get; set; }
        public EFDataModel.Person People { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> DDLPerson { get; private set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> DDLMotivo { get; private set; }
        public void LoadModelData(string requestId)
        {
            
            if (string.IsNullOrWhiteSpace(requestId))
            {
                Refound = new EFDataModel.PrePaymentRefound();
                Refound.PeopleId = this.People.PeopleId;
                this.DDLPerson = DataAccessLayer.DBPerson.getDDLPerson(this.People.PeopleId);
                this.DDLMotivo = DataAccessLayer.DALFinancial.getDDLExpenseAccount(null);
            }
            else
            {
                Refound = DataAccessLayer.DALPerson.getPrePaymentRefound(long.Parse(requestId));
                this.DDLPerson = DataAccessLayer.DBPerson.getDDLPerson(Refound.PeopleId);
                this.DDLMotivo = DataAccessLayer.DALFinancial.getDDLExpenseAccount(Refound.GLAccountCode);
            }
        }
    }
}