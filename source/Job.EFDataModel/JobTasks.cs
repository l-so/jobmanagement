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
    
    public partial class JobTasks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JobTasks()
        {
            this.WorksJournal = new HashSet<WorksJournal>();
        }
    
        public string JobTaskId { get; set; }
        public string Description { get; set; }
        public long JobId { get; set; }
        public Nullable<decimal> ExpectedInvoice { get; set; }
        public Nullable<decimal> ExpectedCost { get; set; }
        public string TaskBusinessGroup { get; set; }
        public Nullable<int> ExpectedHoursOfWork { get; set; }
        public Nullable<decimal> IncomePerHour { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorksJournal> WorksJournal { get; set; }
        public virtual Jobs Jobs { get; set; }
    }
}
