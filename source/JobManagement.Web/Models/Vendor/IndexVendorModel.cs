using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobManagement.WebMvc.Models.Vendor
{
    public class IndexVendorModel
    {
        public string filterStatus { get; set; }
        public string filterName { get; set; }
        public List<EFDataModel.Vendors> VendorList { private set; get; }
        internal void loadData(string filterName, int filterStatus)
        {
            this.VendorList = DataAccessLayer.DBVendor.getVendorList(filterName, filterStatus);
        }
    }
}