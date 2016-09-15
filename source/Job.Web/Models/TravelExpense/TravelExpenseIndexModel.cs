using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job.WebMvc.Models.TravelExpense
{
    public class TravelExpenseIndexModel
    {
        public int TEFilterYear { get; private set; }
        public int TEFilterMonth { get; private set; }
        public int TEFilterPeopleId { get; private set; }
        public int TEFilterStatus { get; private set; }
        public List<System.Web.Mvc.SelectListItem> DDLPeople { get; private set; }
        internal void LoadData(int? m, int? y, int? p, string status)
        {

            TEFilterMonth = (m.HasValue ? m.Value : System.DateTime.Now.Month);
            TEFilterYear = (y.HasValue ? y.Value : System.DateTime.Now.Year);
            TEFilterPeopleId = (p.HasValue ? p.Value : -1);
            TEFilterStatus = string.IsNullOrEmpty(status) ? 999 : int.Parse(status);
            this.DDLPeople = DataAccessLayer.DBPerson.getDDLPerson(TEFilterPeopleId);
        }
    }
}