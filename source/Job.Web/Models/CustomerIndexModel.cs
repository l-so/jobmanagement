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
        public bool FilterIsActive { get; private set; }
        public void LoadModelData(string filterFullname, string filterActive)
        {
            FilterIsActive = ! string.IsNullOrEmpty(filterActive);
            FilterFullName = filterFullname;            
            if (string.IsNullOrWhiteSpace(filterFullname)) 
            { 
                this.CustomerList = DataAccessLayer.DBCustomers.getCustomerList(FilterIsActive);
            }
            else
            {
                this.CustomerList = DataAccessLayer.DBCustomers.getCustomerList(FilterFullName);
            }
        }
    }
}