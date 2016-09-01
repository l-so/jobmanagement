//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobManagement.EFDataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PurchaseInvoices
    {
        public long PurchaseInvoiceId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<long> BuyFromVendorId { get; set; }
        public string BuyFromName { get; set; }
        public decimal Amount { get; set; }
        public decimal Vat { get; set; }
        public string GLAccountCode { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<int> PaidById { get; set; }
        public Nullable<byte> Status { get; set; }
        public Nullable<System.DateTime> PostDate { get; set; }
        public Nullable<int> PostLine { get; set; }
    
        public virtual PurchaseInvoicePaidBy PurchaseInvoicePaidBy { get; set; }
        public virtual Vendors Vendors { get; set; }
    }
}
