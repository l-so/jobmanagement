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
    
    public partial class GenerlaJournalLineEntries
    {
        public long GenerlaJournalLineEntryId { get; set; }
        public long GenerlaJournalLineId { get; set; }
        public int Position { get; set; }
        public string GLAccountCode { get; set; }
        public decimal Amount { get; set; }
        public string DebitCredit { get; set; }
    
        public virtual GeneralJournalLines GeneralJournalLines { get; set; }
    }
}