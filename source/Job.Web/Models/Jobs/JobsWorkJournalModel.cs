using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Job.WebMvc.Models.Jobs
{
    public class JobsWorkJournalModel
    {
        public DateTime BeginDate { get; private set;}
        public DateTime EndDate { get; private set; }
        public EFDataModel.Person People { get; private set;}
        public EFDataModel.Customers Customer { get; private set;}
        public List<EFDataModel.WorksJournal> WorkJournalList { get; private set;}
        public List<WorkJournalListElement> WorkList { get; private set; }
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
            this.DDLPeopleList = DataAccessLayer.DBPerson.getDDLPerson((this.People == null ? -1 : this.People.PeopleId));
            LoadWorks();
        }
        private void LoadWorks()
        {
            List<EFDataModel.WorksJournal> _works = DataAccessLayer.DBJobs.getWorksJournal((this.People == null ? -1 : this.People.PeopleId), (this.Customer == null ? -1 : this.Customer.CustomerId), this.BeginDate, this.EndDate);
            this.WorkList = new List<WorkJournalListElement>();
            // Add not worked day
            System.DateTime d = this.BeginDate.Date;
            WorkJournalListElement e = null;
            while (d.Date <= this.EndDate.Date)
            {
                e = new WorkJournalListElement();
                e.Date = d.Date;
                e.Works = new List<EFDataModel.WorksJournal>();
                e.Works = _works.Where(w => w.Date == e.Date).ToList();
                this.WorkList.Add(e);
                d = d.AddDays(1);
            }

        }
        public static string getListRowStyle(WorkJournalListElement el, int pos)
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
    public class WorkJournalListElement
    {
        public System.DateTime Date { get; set; }
        public List<EFDataModel.WorksJournal> Works { get; set; }
    }
}
