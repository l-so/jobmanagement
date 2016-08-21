using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobManagement.WebMvc.Models
{
    public class ModalEditCustomerModel
    {
        public EFDataModel.Customers Customer { get; private set;}

        public void LoadModelData(long? custId)
        {
            if (custId.HasValue)
            {
                if (custId.Value > 0) { 
                    this.Customer = DataAccessLayer.DBCustomers.getCutomerById(custId.Value);
                }
                else
                {
                    this.Customer = EFDataModel.Customers.Create();
                }
            }
            else
            {
                this.Customer = EFDataModel.Customers.Create();
            }

        }
    }
}