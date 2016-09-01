﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class JMContext : DbContext
    {
        public JMContext()
            : base("name=JMContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AutoNumberBase> AutoNumberBase { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<JobStatus> JobStatus { get; set; }
        public virtual DbSet<JobTasks> JobTasks { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<TravelExpenseAutoCode> TravelExpenseAutoCode { get; set; }
        public virtual DbSet<TravelExpenseLineCategories> TravelExpenseLineCategories { get; set; }
        public virtual DbSet<TravelExpensePurchases> TravelExpensePurchases { get; set; }
        public virtual DbSet<TravelExpenses> TravelExpenses { get; set; }
        public virtual DbSet<TravelExpensesLines> TravelExpensesLines { get; set; }
        public virtual DbSet<TravelExpenseStatus> TravelExpenseStatus { get; set; }
        public virtual DbSet<WorksJournal> WorksJournal { get; set; }
        public virtual DbSet<JobList> JobList { get; set; }
        public virtual DbSet<JobTotalPeopleWorkedHours> JobTotalPeopleWorkedHours { get; set; }
        public virtual DbSet<JobTotalWorkedHours> JobTotalWorkedHours { get; set; }
        public virtual DbSet<TravelExpenseJobsList> TravelExpenseJobsList { get; set; }
        public virtual DbSet<TravelExpenseList> TravelExpenseList { get; set; }
        public virtual DbSet<GLAccount> GLAccount { get; set; }
        public virtual DbSet<GeneralJournalLines> GeneralJournalLines { get; set; }
        public virtual DbSet<GenerlaJournalLineEntries> GenerlaJournalLineEntries { get; set; }
        public virtual DbSet<Vendors> Vendors { get; set; }
        public virtual DbSet<PurchaseInvoicePaidBy> PurchaseInvoicePaidBy { get; set; }
        public virtual DbSet<PurchaseInvoices> PurchaseInvoices { get; set; }
        public virtual DbSet<JobCosts> JobCosts { get; set; }
    
        public virtual int upCustomerDelete(Nullable<int> customerId)
        {
            var customerIdParameter = customerId.HasValue ?
                new ObjectParameter("customerId", customerId) :
                new ObjectParameter("customerId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("upCustomerDelete", customerIdParameter);
        }
    
        public virtual ObjectResult<upJobAdd_Result> upJobAdd(Nullable<long> customerId, string code, string description, Nullable<int> expectedWorkHours, Nullable<decimal> expectedIncome, Nullable<decimal> expectedCost, Nullable<System.DateTime> expectedStartDate, Nullable<System.DateTime> expectedFinishDate, Nullable<int> year, Nullable<byte> status)
        {
            var customerIdParameter = customerId.HasValue ?
                new ObjectParameter("CustomerId", customerId) :
                new ObjectParameter("CustomerId", typeof(long));
    
            var codeParameter = code != null ?
                new ObjectParameter("Code", code) :
                new ObjectParameter("Code", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var expectedWorkHoursParameter = expectedWorkHours.HasValue ?
                new ObjectParameter("ExpectedWorkHours", expectedWorkHours) :
                new ObjectParameter("ExpectedWorkHours", typeof(int));
    
            var expectedIncomeParameter = expectedIncome.HasValue ?
                new ObjectParameter("ExpectedIncome", expectedIncome) :
                new ObjectParameter("ExpectedIncome", typeof(decimal));
    
            var expectedCostParameter = expectedCost.HasValue ?
                new ObjectParameter("ExpectedCost", expectedCost) :
                new ObjectParameter("ExpectedCost", typeof(decimal));
    
            var expectedStartDateParameter = expectedStartDate.HasValue ?
                new ObjectParameter("ExpectedStartDate", expectedStartDate) :
                new ObjectParameter("ExpectedStartDate", typeof(System.DateTime));
    
            var expectedFinishDateParameter = expectedFinishDate.HasValue ?
                new ObjectParameter("ExpectedFinishDate", expectedFinishDate) :
                new ObjectParameter("ExpectedFinishDate", typeof(System.DateTime));
    
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(int));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<upJobAdd_Result>("upJobAdd", customerIdParameter, codeParameter, descriptionParameter, expectedWorkHoursParameter, expectedIncomeParameter, expectedCostParameter, expectedStartDateParameter, expectedFinishDateParameter, yearParameter, statusParameter);
        }
    
        public virtual int upJobDelete(Nullable<int> jobId)
        {
            var jobIdParameter = jobId.HasValue ?
                new ObjectParameter("jobId", jobId) :
                new ObjectParameter("jobId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("upJobDelete", jobIdParameter);
        }
    
        public virtual ObjectResult<upTravelExpenseAdd_Result> upTravelExpenseAdd(Nullable<System.DateTime> date, string annotation, Nullable<int> peopleId)
        {
            var dateParameter = date.HasValue ?
                new ObjectParameter("Date", date) :
                new ObjectParameter("Date", typeof(System.DateTime));
    
            var annotationParameter = annotation != null ?
                new ObjectParameter("Annotation", annotation) :
                new ObjectParameter("Annotation", typeof(string));
    
            var peopleIdParameter = peopleId.HasValue ?
                new ObjectParameter("PeopleId", peopleId) :
                new ObjectParameter("PeopleId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<upTravelExpenseAdd_Result>("upTravelExpenseAdd", dateParameter, annotationParameter, peopleIdParameter);
        }
    
        public virtual int upTravelExpenseAddPurchase(string travelExpenseCode, Nullable<int> peopleId, string buyFromName, string buyFromCity, string buyFromCountry, Nullable<int> buyFromDocType, string buyFromDocNumber, Nullable<System.DateTime> buyFromDocDate, Nullable<decimal> amount, Nullable<decimal> amountNoVat, Nullable<decimal> vat, Nullable<decimal> total)
        {
            var travelExpenseCodeParameter = travelExpenseCode != null ?
                new ObjectParameter("TravelExpenseCode", travelExpenseCode) :
                new ObjectParameter("TravelExpenseCode", typeof(string));
    
            var peopleIdParameter = peopleId.HasValue ?
                new ObjectParameter("PeopleId", peopleId) :
                new ObjectParameter("PeopleId", typeof(int));
    
            var buyFromNameParameter = buyFromName != null ?
                new ObjectParameter("BuyFromName", buyFromName) :
                new ObjectParameter("BuyFromName", typeof(string));
    
            var buyFromCityParameter = buyFromCity != null ?
                new ObjectParameter("BuyFromCity", buyFromCity) :
                new ObjectParameter("BuyFromCity", typeof(string));
    
            var buyFromCountryParameter = buyFromCountry != null ?
                new ObjectParameter("BuyFromCountry", buyFromCountry) :
                new ObjectParameter("BuyFromCountry", typeof(string));
    
            var buyFromDocTypeParameter = buyFromDocType.HasValue ?
                new ObjectParameter("BuyFromDocType", buyFromDocType) :
                new ObjectParameter("BuyFromDocType", typeof(int));
    
            var buyFromDocNumberParameter = buyFromDocNumber != null ?
                new ObjectParameter("BuyFromDocNumber", buyFromDocNumber) :
                new ObjectParameter("BuyFromDocNumber", typeof(string));
    
            var buyFromDocDateParameter = buyFromDocDate.HasValue ?
                new ObjectParameter("BuyFromDocDate", buyFromDocDate) :
                new ObjectParameter("BuyFromDocDate", typeof(System.DateTime));
    
            var amountParameter = amount.HasValue ?
                new ObjectParameter("Amount", amount) :
                new ObjectParameter("Amount", typeof(decimal));
    
            var amountNoVatParameter = amountNoVat.HasValue ?
                new ObjectParameter("AmountNoVat", amountNoVat) :
                new ObjectParameter("AmountNoVat", typeof(decimal));
    
            var vatParameter = vat.HasValue ?
                new ObjectParameter("Vat", vat) :
                new ObjectParameter("Vat", typeof(decimal));
    
            var totalParameter = total.HasValue ?
                new ObjectParameter("Total", total) :
                new ObjectParameter("Total", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("upTravelExpenseAddPurchase", travelExpenseCodeParameter, peopleIdParameter, buyFromNameParameter, buyFromCityParameter, buyFromCountryParameter, buyFromDocTypeParameter, buyFromDocNumberParameter, buyFromDocDateParameter, amountParameter, amountNoVatParameter, vatParameter, totalParameter);
        }
    
        public virtual ObjectResult<upOreMensiliLavorateGiornaliero_Result> upOreMensiliLavorateGiornaliero(Nullable<int> peopleId, Nullable<System.DateTime> beginDate)
        {
            var peopleIdParameter = peopleId.HasValue ?
                new ObjectParameter("PeopleId", peopleId) :
                new ObjectParameter("PeopleId", typeof(int));
    
            var beginDateParameter = beginDate.HasValue ?
                new ObjectParameter("BeginDate", beginDate) :
                new ObjectParameter("BeginDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<upOreMensiliLavorateGiornaliero_Result>("upOreMensiliLavorateGiornaliero", peopleIdParameter, beginDateParameter);
        }
    
        public virtual int upPostTravelExpense(string travelExpenseCode)
        {
            var travelExpenseCodeParameter = travelExpenseCode != null ?
                new ObjectParameter("TravelExpenseCode", travelExpenseCode) :
                new ObjectParameter("TravelExpenseCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("upPostTravelExpense", travelExpenseCodeParameter);
        }
    }
}
