using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobManagement.WebMvc.Models.Jobs
{
    public class JobsWorkJournalModel
    {
        public DateTime BeginDate { get; private set;}
        public DateTime EndDate { get; private set; }
        public EFDataModel.Person People { get; private set;}
        public EFDataModel.Customers Customer { get; private set;}
        public List<EFDataModel.WorksJournal> WorkJournalList { get; private set;}
        public IEnumerable<SelectListItem> DDLPeopleList { get; private set; }
        public IEnumerable<SelectListItem> DDLCustomerList { get; private set; }
        public void LoadModelData(EFDataModel.Person people, long? filterCustomerId, DateTime? fromDate, DateTime? toDate)
        {
            int a = System.DateTime.Now.Year;
            int m = System.DateTime.Now.Month;
            this.BeginDate = (fromDate.HasValue ? fromDate.Value.Date : new System.DateTime(a, m, 1));
            this.EndDate = (toDate.HasValue ? toDate.Value.Date : new System.DateTime(a, m, System.DateTime.DaysInMonth(a, m)).Date);
            this.EndDate = this.EndDate.Date.Add(new TimeSpan(23, 59, 59));
            this.People = people;
            if (filterCustomerId.HasValue) { 
                this.Customer = DataAccessLayer.DBCustomers.getCutomerById(filterCustomerId.Value);
            }
            else
            {
                this.Customer = null;
            }

            this.DDLCustomerList = DataAccessLayer.DBCustomers.getCustomerSelectListItem((filterCustomerId.HasValue ? filterCustomerId.Value : -1));
            this.DDLPeopleList = DataAccessLayer.DBPeople.getPeopleDDL((this.People == null ? -1 : this.People.PeopleId));
            LoadWorkJournalData();
        }
        private void LoadWorkJournalData() 
        {
            List<EFDataModel.WorksJournal> ttt = DataAccessLayer.DBJobs.getWorksJournal((this.People == null ? -1 : this.People.PeopleId), (this.Customer == null ? -1 : this.Customer.CustomerId), this.BeginDate, this.EndDate);
            this.WorkJournalList = new List<EFDataModel.WorksJournal>();
            // Add not worked day
            System.DateTime d = this.BeginDate;
            EFDataModel.WorksJournal t = null;
            bool addNew = true;
            while (d.Date.Date <= this.EndDate.Date) 
            {
                foreach (var w in ttt)
                {
                    if (w.Date.Date == d.Date.Date)
                    {
                        addNew = false;
                        t = w;
                        break;
                    }
                }
                if (addNew)
                {
                    t = new EFDataModel.WorksJournal();
                    t.Date = d;
                    t.WorkJournalId = 0;
                    t.Person = null;
                    t.Jobs = null;
                    t.TaskWhere = null;
                    t.Annotation = null;
                    t.JobTasks = null;
                    t.WorkedHours = 0;
                    t.JobId = 0;
                    t.JobTaskId = null;
                    t.PeopleId = 0;
                    this.WorkJournalList.Add(t);
                }
                else
                {
                    this.WorkJournalList.Add(t);
                }
                addNew = true;
                d = d.AddDays(1);
            }

}
        public static string getListRowStyle(EFDataModel.WorksJournal el, int pos)
        {
            string _r = "trStd";
            if ((pos % 2) == 0)
            {
                _r = "trAlt";
            }
            else
            {
                _r = "trStd";
            }
            if (el.Date.DayOfWeek == DayOfWeek.Saturday || el.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                if ((pos % 2) == 0)
                {
                    _r = "trFesStd";
                } else {
                    _r = "trFesAlt";
                }
            }
            return _r;
        }
    }
}
