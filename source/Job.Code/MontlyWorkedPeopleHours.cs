using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Code
{
    public class MontlyWorkedPeopleHours
    {
        public EFDataModel.Person People { get; private set; }
        public WorkedPeopleWeek[] Weeks { get; set; }
        public int Year { get; private set; }
        public int Month { get; private set; }
        public MontlyWorkedPeopleHours(int month, int year, EFDataModel.Person people)
        {
            this.Year = year;
            this.Month = month;
            this.People = people;
            this.Weeks = new WorkedPeopleWeek[6];
            this.Weeks[0] = new WorkedPeopleWeek(people);
            this.Weeks[1] = new WorkedPeopleWeek(people);
            this.Weeks[2] = new WorkedPeopleWeek(people);
            this.Weeks[3] = new WorkedPeopleWeek(people);
            this.Weeks[4] = new WorkedPeopleWeek(people);
            this.Weeks[5] = new WorkedPeopleWeek(people);
        }
    }

    public class WorkedPeopleWeek
    {
        public DateTime FirstDate { get; set; }
        public EFDataModel.Person People { get; set; }
        public WorkedPeopleDay[] Week {get; set;}
        public WorkedPeopleWeek(EFDataModel.Person people)
        {
            this.People = people;
            this.Week = new WorkedPeopleDay[7];
        }
        public void AddWorkDay(WorkedPeopleDay day)
        {
            Week[(int)day.Date.DayOfWeek] = day;
            if (day.Date.DayOfWeek == DayOfWeek.Monday) {
                FirstDate = day.Date;
            }
        }
    }
    public class WorkedPeopleDay
    {
        public DateTime Date { get; set; }
        public decimal ExpectedHours { get; set; }
        public decimal Hours { get; set; }
        public EFDataModel.Person People { get; set; }
    }
}
