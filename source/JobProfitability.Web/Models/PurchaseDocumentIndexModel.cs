using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobManagement.WebMvc.Models
{
    public class PurchaseDocumentIndexModel
    {
        public DateTime filterFromDate { get; set;}
        public DateTime filterToDate { get; set; }
        public string CashAccountId { get; set; }

        internal void LoadModelData(DateTime fromDate, DateTime toDate, string accountId)
        {
            // throw new NotImplementedException();
        }

        internal void LoadModelData()
        {
            throw new NotImplementedException();
        }
    }
}