//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Job.EFDataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class TravelExpenses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TravelExpenses()
        {
            this.TravelExpensesLines = new HashSet<TravelExpensesLines>();
        }
    
        public string TravelExpenseCode { get; set; }
        public System.DateTime Date { get; set; }
        public string Annotation { get; set; }
        public byte Status { get; set; }
        public int PeopleId { get; set; }
        public Nullable<System.DateTime> PostDate { get; set; }
        public Nullable<decimal> InvoiceAmount { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public decimal Amount { get; set; }
    
        public virtual Person Person { get; set; }
        public virtual TravelExpenseStatus TravelExpenseStatus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TravelExpensesLines> TravelExpensesLines { get; set; }
    }
}
