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
    
    public partial class GeneralJournalLines
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GeneralJournalLines()
        {
            this.GenerlaJournalLineEntries = new HashSet<GenerlaJournalLineEntries>();
        }
    
        public long GeneralJournalLineId { get; set; }
        public System.DateTime Date { get; set; }
        public int LineNumber { get; set; }
        public string Description { get; set; }
        public string DocumentReference { get; set; }
        public string Type { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GenerlaJournalLineEntries> GenerlaJournalLineEntries { get; set; }
    }
}