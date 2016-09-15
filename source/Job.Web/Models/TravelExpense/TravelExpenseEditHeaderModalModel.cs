using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job.WebMvc.Models.TravelExpense
{
    public class TravelExpenseEditHeaderModalModel
    {
        public EFDataModel.TravelExpenses TravelExpense { get; private set;}
        public List<System.Web.Mvc.SelectListItem> DDLPeople { get; private set; }
        public List<System.Web.Mvc.SelectListItem> DDLType
        {
            get
            {
                List<System.Web.Mvc.SelectListItem> res = new List<System.Web.Mvc.SelectListItem>();
                res.Add(new System.Web.Mvc.SelectListItem() { Text = "Analitico o piè di lista", Value = "ANALITICO", Selected = true });
                return res;
            }
        }
        public int TEFilterYear { get; set; }
        public int TEFilterMonth { get; set; }
        public int TEFilterPeopleId { get; set; }
        public string TEFilterStatus { get; set; }
        internal void LoadData(string travelExpenseCode, int peopleId, DateTime dt)
        {
            if (!string.IsNullOrWhiteSpace(travelExpenseCode))
            {
                this.TravelExpense = DataAccessLayer.DBTravelExpense.getOne(travelExpenseCode);
                this.DDLPeople = DataAccessLayer.DBPerson.getDDLPerson(this.TravelExpense.PeopleId);
            }
            else
            {
                this.TravelExpense = new EFDataModel.TravelExpenses();
                this.TravelExpense.TravelExpenseCode = null;
                this.TravelExpense.Date = dt;
                this.DDLPeople = DataAccessLayer.DBPerson.getDDLPerson(peopleId);
            }

        }
        internal void LoadData(string travelExpenseCode, int peopleId)
        {
            if (!string.IsNullOrWhiteSpace(travelExpenseCode))
            {
                this.TravelExpense = DataAccessLayer.DBTravelExpense.getOne(travelExpenseCode);
                this.DDLPeople = DataAccessLayer.DBPerson.getDDLPerson(this.TravelExpense.PeopleId);
            }
            else
            {
                this.TravelExpense = new EFDataModel.TravelExpenses();
                this.TravelExpense.TravelExpenseCode = null;
                this.DDLPeople = DataAccessLayer.DBPerson.getDDLPerson(peopleId);
            }
        }

        public string getIndexPageParameters()
        {
            return "?tefm=" + TEFilterMonth.ToString() + "&tefy=" + TEFilterYear.ToString() + "&tefp="+ TEFilterPeopleId.ToString() + "&tes=" + TEFilterStatus;
        }
    }
}