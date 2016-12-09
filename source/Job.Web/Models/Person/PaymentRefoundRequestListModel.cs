using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job.WebMvc.Models.Person
{
    public class PaymentRefoundRequestListModel
    {
        public int FilterMonth { get; set; }
        public int FilterYear { get; set; }
        public int FilterRequestById { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> DDLPerson { get; private set; }
        public IEnumerable<EFDataModel.PrePaymentRefound> Requests { get; private set; }

        internal void LoadModelData()
        {
            DateTime fromDate = new DateTime(FilterYear,FilterMonth,1);
            DateTime toDate = new DateTime(FilterYear, FilterMonth, DateTime.DaysInMonth(FilterYear, FilterMonth));
            this.DDLPerson = DataAccessLayer.DALPerson.getPersonForDDL(FilterRequestById);
            this.Requests = DataAccessLayer.DALPerson.getPrePaymentRefoundList(FilterRequestById, fromDate, toDate);
        }
    }
}