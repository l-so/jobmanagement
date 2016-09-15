using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.DataAccessLayer
{
    public class DBTravelExpenseLineUpdateResult
    {
        public decimal Total { get; set;}
        public List<EFDataModel.TravelExpensesLines> Rows {get; set;}
    }
}
