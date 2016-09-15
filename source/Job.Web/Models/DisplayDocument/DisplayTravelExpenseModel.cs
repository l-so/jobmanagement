using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job.WebMvc.Models.DisplayDocument
{
    public class DisplayTravelExpenseModel
    {
        public EFDataModel.TravelExpenses TExpense { private set; get; }
        public EFDataModel.TravelExpenseList TEList { private set; get; }
        public List<EFDataModel.TravelExpensesLines> TELine { private set; get; }
        internal void loadData(string id)
        {
            this.TEList = DataAccessLayer.DBTravelExpense.getOneFromList(id);
            this.TExpense = DataAccessLayer.DBTravelExpense.getOne(id);
            this.TELine = DataAccessLayer.DBTravelExpense.getLines(id);
        }
    }
}