using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Code
{
    public class RegisterGetConfirmDataResult
    {
        public int PeopleId { get; set; }
        public string PeopleFullName { get; set; }
        public string TravelExpenseCode { get; set; }
        public DateTime TravelExpenseFromDate { get; set; }
        public DateTime TravelExpenseToDate { get; set; }
        public decimal TravelExpenseTotal { get; set; }
        public decimal TravelExpenseInvoiceAmount { get; set; }

        public List<RegisterGetConfirmDataResultJob> Jobs { get; set; }

    }

    public class RegisterGetConfirmDataResultJob
    {
        public long JobId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Hours { get; set; }
        public decimal Amount { get; set;}
    }
}
