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
    
    public partial class JobList
    {
        public long JobId { get; set; }
        public long CustomerId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal ExpectedIncome { get; set; }
        public decimal ExpectedCost { get; set; }
        public int ExpectedWorkHours { get; set; }
        public byte Status { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<decimal> TotalHours { get; set; }
        public string StatusDescription { get; set; }
        public string CustomerName { get; set; }
        public string CustomerName2 { get; set; }
        public string CustomerFullName { get; set; }
    }
}