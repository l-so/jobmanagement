using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobManagement.WebMvc.Models
{
    public class CustomerIndexModel
    {
        public IEnumerable<EFDataModel.Customers> CustomerList { get; set;}
        public int CurrentYear { get; private set;}
        public void LoadModelData(string filterFullname, string filterActive)
        {
            short actState = -1;
            switch (filterActive)
            {
                case "-1":
                    actState = -1;
                    break;
                case "1":
                    actState = EFDataModel.Customers.STATUS_ARCHIVED;
                    break;
                default:
                    actState = EFDataModel.Customers.STATUS_ACTIVE;
                    break;
            }
            this.CurrentYear = System.DateTime.Now.Year;
            if (string.IsNullOrWhiteSpace(filterFullname)) 
            { 
                this.CustomerList = DataAccessLayer.DBCustomers.getCustomerList(actState);
            }
            else
            {
                this.CustomerList = DataAccessLayer.DBCustomers.getCustomerList(filterFullname, actState);
            }
        }
    }
}