using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobManagement.WebMvc.Models.TravelExpense
{
    public class TravelExpenseDisplayModel
    {
        public int TEFilterYear { get; set; }
        public int TEFilterMonth { get; set; }
        public int TEFilterPeopleId { get; set; }
        public EFDataModel.TravelExpenses TravelExpense { get; private set; }
        public EFDataModel.TravelExpenseList TravelExpenseList { get; private set; }
        public List<EFDataModel.TravelExpensesLines> TravelExpenseLine { get; private set; }
        internal void LoadData(string id)
        {
            this.TravelExpense = DataAccessLayer.DBTravelExpense.getOne(id);
            this.TravelExpenseList = DataAccessLayer.DBTravelExpense.getOneFromList(id);
            this.TravelExpenseLine = DataAccessLayer.DBTravelExpense.getLines(id);
        }
    }
}