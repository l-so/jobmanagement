using System;

namespace JobManagement.WebMvc.Models.Vendor
{
    public class ModalEditVendorModel
    {

        public EFDataModel.Vendors Vendor { private set; get; }
        internal void loadData(string id)
        {
            long v = -1;
            if (!string.IsNullOrWhiteSpace(id)) {
                v = long.Parse(id);
            }
            if (v == -1)
            {
                Vendor = new EFDataModel.Vendors();
                Vendor.VendorId = -1;
            } else
            {
                this.Vendor = DataAccessLayer.DBVendor.get(v);
            }
        }
    }
}