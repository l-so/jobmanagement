using System;

namespace Job.WebMvc.Models.Work
{
    public class WorkEditWeekModel
    {
        public DateTime Monday {get; private set; }
        public DateTime Tuesday { get; private set; }
        public DateTime Wendsday { get; private set; }
        public DateTime Thursday { get; private set; }
        public DateTime Friday { get; private set; }
        public DateTime Saturday { get; private set; }
        public DateTime Sunday { get; private set; }
        public EFDataModel.Person People { get; private set; }
        internal void LoadModelData(string peopleId, string weekStartDay)
        {
            Monday = DateTime.Parse(weekStartDay);
            while(Monday.DayOfWeek == DayOfWeek.Monday)
            {
                Monday = Monday.AddDays(-1);
            }
            Tuesday = Monday.AddDays(1);
            Wendsday = Tuesday.AddDays(1);
            Thursday = Wendsday.AddDays(1);
            Friday = Thursday.AddDays(1);
            Saturday = Friday.AddDays(1);
            Sunday = Saturday.AddDays(1);
            People = DataAccessLayer.DBPerson.getOne(int.Parse(peopleId));
        }
    }
}