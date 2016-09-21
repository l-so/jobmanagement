using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job.WebMvc.Models
{
    public class CustomerIndexModel
    {
        public IEnumerable<EFDataModel.Customers> CustomerList { get; set;}
        public string FilterFullName { get; private set; }
        public short FilterStatus { get; private set; }
        public void LoadModelData(string filterFullname, string filterActive)
        {

            FilterStatus = EFDataModel.Customers.STATUS_ACTIVE;
            FilterFullName = filterFullname;

            switch (filterActive)
            {
                case "-1":
                    FilterStatus = -1; // TUTTI
                    break;
                case "1":
                    FilterStatus = EFDataModel.Customers.STATUS_ARCHIVED;
                    break;
                case "200":
                    FilterStatus = 200; // ARCHIVIATI + ATTIVI
                    break;
                case "125":
                    FilterStatus = EFDataModel.Customers.STATUS_INTERNAL;
                    break;
            }
            
            if (string.IsNullOrWhiteSpace(filterFullname)) 
            { 
                this.CustomerList = DataAccessLayer.DBCustomers.getCustomerList(FilterStatus);
            }
            else
            {
                this.CustomerList = DataAccessLayer.DBCustomers.getCustomerList(FilterFullName, FilterStatus);
            }
        }
    }
}