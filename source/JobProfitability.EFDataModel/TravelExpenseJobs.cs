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
    
    public partial class TravelExpenseJobs
    {
        public string TravelExpenseCode { get; set; }
        public long JobId { get; set; }
        public decimal InPercent { get; set; }
    
        public virtual Jobs Jobs { get; set; }
        public virtual TravelExpenses TravelExpenses { get; set; }
    }
}
