using System;

namespace JobManagement.WebMvc.Models.PurchaseInvoice
{
    public class ModalEditPurchaseInvoiceModel
    {
        public EFDataModel.PurchaseInvoices PurchaseInvoice { get; set; }
        public long JobId { get; private set; }
        public long Id { get; private set; }
        public System.Collections.Generic.List<System.Web.Mvc.SelectListItem> DDLVendorList { get; private set; }
        public System.Collections.Generic.List<System.Web.Mvc.SelectListItem> DDLJobList { get; private set; }
        public System.Collections.Generic.List<System.Web.Mvc.SelectListItem> DDLAccountList { get; private set; }
        public System.Collections.Generic.List<System.Web.Mvc.SelectListItem> DDLPurchInvPaidByist { get; private set; }
        internal void loadData(string id, string jobid)
        {
            this.Id = (string.IsNullOrWhiteSpace(id) ? -1 : long.Parse(id));
            this.JobId = (string.IsNullOrWhiteSpace(jobid) ? -1 : long.Parse(jobid));
            if (this.Id > 0)
            {
                this.PurchaseInvoice = DataAccessLayer.DBPurchaseInvoices.getById(this.Id);
            }
            else
            {
                this.PurchaseInvoice = new EFDataModel.PurchaseInvoices();
                this.PurchaseInvoice.PurchaseInvoiceId = -1;
                this.PurchaseInvoice.GLAccountCode = EFDataModel.GLAccount.RISTORANTE_ALBERGHI_ACCOUNT;
                this.PurchaseInvoice.PurchaseInvoicePaidBy = null;
            }
            this.DDLVendorList = DataAccessLayer.DBVendor.getDDLVendor((this.PurchaseInvoice.BuyFromVendorId.HasValue ? this.PurchaseInvoice.BuyFromVendorId.Value : -1));
            this.DDLVendorList.Insert(0, new System.Web.Mvc.SelectListItem() { Value="-1", Text="<Fornitore generico non codificato>", Selected = !this.PurchaseInvoice.BuyFromVendorId.HasValue});
            this.DDLAccountList = DataAccessLayer.DBGeneralLedger.getDDLPurchaseInvoiceGLAccount(this.PurchaseInvoice.GLAccountCode);
            this.DDLPurchInvPaidByist = DataAccessLayer.DBPurchaseInvoices.getDDLPaidBy(this.PurchaseInvoice.PaidById);
            loadAssignedJob();
        }
        private void loadAssignedJob()
        {
            this.DDLJobList = DataAccessLayer.DBJobs.getDDLJobSelectListItem(-1);
            this.DDLJobList.Insert(0, new System.Web.Mvc.SelectListItem() { Value = "-1", Text = "<Non assegnata>" });
            
        }
    }
}