using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Job.WebMvc.Models
{
    public class WorkLogReportListModel
    {
        public IEnumerable<SelectListItem> DDLCustomerList { get; private set; }
        public IEnumerable<SelectListItem> DDLReportStateList { get; private set; }
        public long? filterCustomerId { get; private set; }
        public int? filterReportState { get; private set; }
        public void LoadModelData(long? customerId,int? reportState)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            SelectListItem i = new SelectListItem();
            list.Add(new SelectListItem() { Value = "1" , Text = "Creato", Selected = (reportState.HasValue ? (reportState.Value == 1) : false)});
            list.Add(new SelectListItem() { Value = "2", Text = "Inviato al cliente", Selected = (reportState.HasValue ? (reportState.Value == 2) : false) });
            list.Add(new SelectListItem() { Value = "3", Text = "Storico", Selected = (reportState.HasValue ? (reportState.Value == 3) : false) });
            list.Add(new SelectListItem() { Value = "99", Text = "Fatturato", Selected = (reportState.HasValue ? (reportState.Value == 99) : false) });
            this.DDLReportStateList = list;
            this.DDLCustomerList = DataAccessLayer.DBCustomers.getCustomerSelectListItem((customerId.HasValue ? customerId.Value : -1));
            this.filterCustomerId = customerId;
            this.filterReportState = reportState;
         }
    }
}