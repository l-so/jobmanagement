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
    
    public partial class TravelExpensesLines
    {
        public long TravelExpenseLineId { get; set; }
        public string TravelExpenseCode { get; set; }
        public System.DateTime Date { get; set; }
        public int TravelExpenseLineCategoryId { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public string CarPlate { get; set; }
        public string CarDescription { get; set; }
        public decimal CarKmCost { get; set; }
        public int CarKm { get; set; }
    
        public virtual TravelExpenseLineCategories TravelExpenseLineCategories { get; set; }
        public virtual TravelExpenses TravelExpenses { get; set; }
    }
}
