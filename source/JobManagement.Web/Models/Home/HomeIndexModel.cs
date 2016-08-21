using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobManagement.WebMvc.Models.Home
{
    public class HomeIndexModel
    {
        public Identity.AppUser LoggedUser { get; private set;}
        public EFDataModel.Person loggedPeople { get; private set;}
        public string FullName { get; private set;}
        public string ResourceId { get; private set; }
        public int PeopleId { get; private set;}
        public List<Settimana> LavoroDelMese { get; private set;}
        public string MeseAnno { get; private set;}
        public void LoadModelData(EFDataModel.Person per, int monthYear)
        {
            this.ResourceId = per.IdentityId;
            this.PeopleId = per.PeopleId;
            int a = monthYear / 100;
            int m = monthYear % 100;
            LoadMonthWork(a,m);
            this.LoggedUser = Identity.IdentityHelper.getAppUserById(per.IdentityId);
            this.loggedPeople = per;
            this.MeseAnno = Code.UtiliMix.getMonthName(m) + " " + a.ToString();
        }
        
        private void LoadMonthWork(int a, int m) {
            this.LavoroDelMese = new List<Settimana>();
            DateTime beginDate = new DateTime(a,m,1,0,0,0);
            DateTime currentDate = beginDate;
            Settimana s = new Settimana();
            List<EFDataModel.upOreMensiliLavorateGiornaliero_Result> giorni = DataAccessLayer.DBJobs.getOneMonthTotalDayWorkedHoursForResource(beginDate, this.PeopleId);
            foreach (EFDataModel.upOreMensiliLavorateGiornaliero_Result g in giorni)
            {
                currentDate = g.Date.Value;
                switch (currentDate.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        s.Lunedi = new Giorno(currentDate);
                        s.Lunedi.Ore = (g.Ore.HasValue ? g.Ore.Value : decimal.Zero);
                        if (currentDate.AddDays(1).Month != currentDate.Month)
                        {
                            LavoroDelMese.Add(s);
                        }
                        break;
                    case DayOfWeek.Tuesday:
                        s.Martedi = new Giorno(currentDate);
                        s.Martedi.Ore = (g.Ore.HasValue ? g.Ore.Value : decimal.Zero);
                        if (currentDate.AddDays(1).Month != currentDate.Month)
                        {
                            LavoroDelMese.Add(s);
                        }
                        break;
                    case DayOfWeek.Wednesday:
                        s.Mercoledi = new Giorno(currentDate);
                        s.Mercoledi.Ore = (g.Ore.HasValue ? g.Ore.Value : decimal.Zero);
                        if (currentDate.AddDays(1).Month != currentDate.Month)
                        {
                            LavoroDelMese.Add(s);
                        }
                        break;
                    case DayOfWeek.Thursday:
                        s.Giovedi = new Giorno(currentDate);
                        s.Giovedi.Ore = (g.Ore.HasValue ? g.Ore.Value : decimal.Zero);
                        if (currentDate.AddDays(1).Month != currentDate.Month)
                        {
                            LavoroDelMese.Add(s);
                        }
                        break;
                    case DayOfWeek.Friday:
                        s.Venerdi = new Giorno(currentDate);
                        s.Venerdi.Ore = (g.Ore.HasValue ? g.Ore.Value : decimal.Zero);
                        if (currentDate.AddDays(1).Month != currentDate.Month)
                        {
                            LavoroDelMese.Add(s);
                        }
                        break;
                    case DayOfWeek.Saturday:
                        s.Sabato = new Giorno(currentDate);
                        s.Sabato.Ore = (g.Ore.HasValue ? g.Ore.Value : decimal.Zero);
                        if (currentDate.AddDays(1).Month != currentDate.Month)
                        {
                            LavoroDelMese.Add(s);
                        }
                        break;
                    case DayOfWeek.Sunday:
                        s.Domenica = new Giorno(currentDate);
                        s.Domenica.Ore = (g.Ore.HasValue ? g.Ore.Value : decimal.Zero);
                        LavoroDelMese.Add(s);
                        s = new Settimana();
                        break;
                }
            }
            
        }
        // LUN MAR MER GIO VEN SAB DOM
    }


    public class Settimana
    {
        public Giorno Lunedi { get; set;}
        public Giorno Martedi { get; set; }
        public Giorno Mercoledi { get; set; }
        public Giorno Giovedi { get; set; }
        public Giorno Venerdi { get; set; }
        public Giorno Sabato { get; set; }
        public Giorno Domenica { get; set; }
            
    }
    public class Giorno 
    {
        public System.DateTime Data { get; private set;}
        public string Nome { get; private set;}
        public int Numero { get; private set; }
        public decimal Ore { get; set; }
        public decimal Ordinario { get; set;}
        public decimal Straordinario 
        {
	        get
	        {
	            return ((this.Ore - this.Ordinario) < 0 ? decimal.Zero : (this.Ore - this.Ordinario));
	        }
        }
        public string OrdinarioString
        {
            get
            {
                return (this.Ordinario == 0 ? string.Empty : string.Format("{0:F2}", this.Ordinario));
            }
        }
        public string StraordinarioString
        {
            get
            {
                return (this.Straordinario == 0 ? string.Empty : string.Format("{0:F2}", this.Straordinario));
            }
        }

        public Giorno(System.DateTime d)
        {
            switch (d.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    this.Nome = "LUN";
                    break;
                case DayOfWeek.Tuesday:
                    this.Nome = "MAR";
                    break;
                case DayOfWeek.Wednesday:
                    this.Nome = "MER";
                    break;
                case DayOfWeek.Thursday:
                    this.Nome = "GIO";
                    break;
                case DayOfWeek.Friday:
                    this.Nome = "VEN";
                    break;
                case DayOfWeek.Saturday:
                    this.Nome = "SAB";
                    break;
                case DayOfWeek.Sunday:
                    this.Nome = "DOM";
                    break;
            }
            this.Data = d;
            this.Numero = d.Day;
            if ((d.DayOfWeek != DayOfWeek.Sunday) && (d.DayOfWeek != DayOfWeek.Saturday)) 
            { 
                this.Ordinario = 8;
            } 
            else 
            {
                this.Ordinario = 0;
            }
        }
    }
}


