using System;
using System.Collections.Generic;

namespace Job.WebMvc.Models.Person
{
    public class ExpenseRefoundIndexModel
    {
        public int FilterYear { get; set; }
        public int FilterMonth { get; set; }
        public int FilterPeopleId { get; set; }
        public EFDataModel.Person LoggedPeople { get; internal set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> DDLPerson { get; private set; }
        public List<EFDataModel.ExpensePaymentRefound> ExpensePaymentRefoundList { get; private set; }

        internal void loadData(int year, int month, int peopleId)
        {
            DateTime fromDate;
            DateTime toDate;
            if (month < 13)
            {
                fromDate = new DateTime(year, month, 1);
                toDate = new DateTime(year, month, DateTime.DaysInMonth(year,month));
            } 
            else
            {
                fromDate = new DateTime(year, 1, 1);
                toDate = new DateTime(year, 12, 31);
            }
            ExpensePaymentRefoundList = DataAccessLayer.DBPerson.getExpensePaymentRefound(peopleId, fromDate, toDate);
            this.DDLPerson = DataAccessLayer.DBPerson.getDDLPerson(peopleId);
        }
    }
}