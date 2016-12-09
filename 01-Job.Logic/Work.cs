using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Logic
{
    public class Work
    {
        public static void updateWorks(long jobId, int peopleId, string jtId, DateTime date, string work, string where, string note)
        {
            EFDataModel.WorksJournal r = new EFDataModel.WorksJournal();
            EFDataModel.WorksJournal wj = new EFDataModel.WorksJournal();
            wj.JobId = jobId;
            wj.PeopleId = peopleId;
            wj.JobTaskId = jtId;
            wj.TaskWhere = where;
            wj.Annotation = note;
            wj.Date = date;
            decimal d = 0;
            int h = 0;
            decimal.TryParse(work.Substring(0, work.Length - 1), out d);
            if (d >= 1 || d <= -1)
            {
                try
                {
                    wj.WorkedHours = 8;
                    r = DataAccessLayer.DALJob.UpdateWorksLine(wj);
                    if (d > 1)
                    {
                        for (int i = 2; i <= d; i++)
                        {
                            wj.WorkJournalId = -1;
                            wj.Date = wj.Date.AddDays(1);
                            r = DataAccessLayer.DALJob.UpdateWorksLine(wj);
                            h = i;
                        }
                        wj.Date = wj.Date.AddDays(1);
                    }
                    if (d < -1)
                    {
                        d = Math.Abs(d);
                        for (int i = 2; i <= d; i++)
                        {
                            wj.WorkJournalId = -1;
                            wj.Date = wj.Date.AddDays(-1);
                            r = DataAccessLayer.DALJob.UpdateWorksLine(wj);
                            h = i;
                        }
                        wj.Date = wj.Date.AddDays(-1);
                    }
                    if ((d - h) > 0)
                    {
                        d = d - h;
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            if (Math.Abs(d) > 0 && Math.Abs(d) < 1)
            {
                try
                {
                    switch (Math.Abs(d).ToString().Substring(0, 3))
                    {
                        case "0.1": //0.125
                            wj.WorkedHours = 1;
                            break;
                        case "0.2": //0.25
                            wj.WorkedHours = 2;
                            break;
                        case "0.3": //0.375
                            wj.WorkedHours = 3;
                            break;
                        case "0.5":
                            wj.WorkedHours = 4;
                            break;
                        case "0.6": // 0.625
                            wj.WorkedHours = 5;
                            break;
                        case "0.7": // 0.75
                            wj.WorkedHours = 6;
                            break;
                        case "0.8": // 0.875
                            wj.WorkedHours = 7;
                            break;
                    }
                    r = DataAccessLayer.DALJob.UpdateWorksLine(wj);
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }
        public static Code.MontlyWorkedPeopleHours getMonthWorkedHourByPeople(EFDataModel.Person people, int year, int month)
        {
            Code.MontlyWorkedPeopleHours _result = new Code.MontlyWorkedPeopleHours(month,year,people);
            List<Code.WorkedPeopleDay> wh = DataAccessLayer.DALWork.getMonthWorkedHourByPeople(people.PeopleId, month, year);
            for(int i = 0; i < wh.Count; i++)
            {
                wh[i].People = people;
                wh[i].ExpectedHours = getDayExpectedHours(people, wh[i].Date);
            }
            DateTime currentDate = new DateTime(year, month, 1);
            int currentWeek = 0;
            Code.WorkedPeopleDay wd;
            _result.Weeks[currentWeek].FirstDate = currentDate;
            while (currentDate.Month == month)
            {
                wd = wh.Where(e => e.Date == currentDate.Date).FirstOrDefault();
                if (wd == null)
                {
                    wd = new Code.WorkedPeopleDay()
                    {
                        Date = currentDate,
                        People = people,
                        ExpectedHours = getDayExpectedHours(people, currentDate.Date),
                        Hours = decimal.Zero
                    };
                }
                _result.Weeks[currentWeek].AddWorkDay(wd);
                currentDate = currentDate.AddDays(1); 
                if (currentDate.DayOfWeek == DayOfWeek.Monday)
                {
                    currentWeek += 1;
                }
            }
            return _result;
        }
        private static decimal getDayExpectedHours(EFDataModel.Person people, System.DateTime day)
        {
            switch (day.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return (people.MondayExpectedHours.HasValue ? people.MondayExpectedHours.Value : 0);
                case DayOfWeek.Tuesday:
                    return (people.TuesdayExpectedHours.HasValue ? people.TuesdayExpectedHours.Value : 0);
                case DayOfWeek.Wednesday:
                    return (people.WendsdayExpectedHours.HasValue ? people.WendsdayExpectedHours.Value : 0);
                case DayOfWeek.Thursday:
                    return (people.ThursdayExpectedHours.HasValue ? people.ThursdayExpectedHours.Value : 0);
                case DayOfWeek.Friday:
                    return (people.FridayExpectedHours.HasValue ? people.FridayExpectedHours.Value : 0);
                case DayOfWeek.Saturday:
                    return (people.SaturdayExpectedHours.HasValue ? people.SaturdayExpectedHours.Value : 0);
                case DayOfWeek.Sunday:
                    return (people.SundayExpectedHours.HasValue ? people.SundayExpectedHours.Value : 0);
                default:
                    return decimal.Zero;
            }

        }
    }
}
