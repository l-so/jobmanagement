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
    
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            this.WorksJournal = new HashSet<WorksJournal>();
            this.TravelExpenses = new HashSet<TravelExpenses>();
            this.PrePaymentRefound = new HashSet<PrePaymentRefound>();
        }
    
        public int PeopleId { get; set; }
        public string IdentityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public byte Contract { get; set; }
        public string Email { get; set; }
        public decimal HourCost { get; set; }
        public bool ActiveState { get; set; }
        public string Code { get; set; }
        public string CarPlate { get; set; }
        public string CarDescription { get; set; }
        public decimal CarKmCost { get; set; }
        public bool IdentityDefault { get; set; }
        public Nullable<decimal> MondayExpectedHours { get; set; }
        public Nullable<decimal> TuesdayExpectedHours { get; set; }
        public Nullable<decimal> WendsdayExpectedHours { get; set; }
        public Nullable<decimal> ThursdayExpectedHours { get; set; }
        public Nullable<decimal> FridayExpectedHours { get; set; }
        public Nullable<decimal> SaturdayExpectedHours { get; set; }
        public Nullable<decimal> SundayExpectedHours { get; set; }
        public string PersonBusinessAccountId { get; set; }
        public Nullable<decimal> CompensoMensile { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorksJournal> WorksJournal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TravelExpenses> TravelExpenses { get; set; }
        public virtual PersonBusinessAccount PersonBusinessAccount { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrePaymentRefound> PrePaymentRefound { get; set; }
    }
}
