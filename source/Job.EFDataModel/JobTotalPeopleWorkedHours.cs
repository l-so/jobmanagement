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
    
    public partial class JobTotalPeopleWorkedHours
    {
        public long JobId { get; set; }
        public int PeopleId { get; set; }
        public Nullable<decimal> TotalHours { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
    }
}
