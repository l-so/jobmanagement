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
    
    public partial class upJobAdd_Result
    {
        public long JobId { get; set; }
        public Nullable<long> CustomerId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal ExpectedIncome { get; set; }
        public decimal ExpectedCost { get; set; }
        public int ExpectedWorkHours { get; set; }
        public byte Status { get; set; }
        public Nullable<int> Year { get; set; }
    }
}
