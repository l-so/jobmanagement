using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace JobManagement.Code
{
    public class UtiliMix
    {
        public static DateTime getCurrentMonthLastDay()
        {
            return getMonthLastDay(System.DateTime.Now.Year, System.DateTime.Now.Month);
        }
        public static DateTime getMonthLastDay(int year, int month)
        {
            int day = System.DateTime.DaysInMonth(year, month);
            return new System.DateTime(year, month, day);
        }
        public static DateTime getMonthLastDay(DateTime date)
        {
            return getMonthLastDay(date.Year, date.Month);
        }
        public static DateTime getMonthFirstDay(int year, int month)
        {
            return new System.DateTime(year, month, 1);
        }
        public static DateTime getMonthFirstDay(DateTime date)
        {
            return getMonthFirstDay(date.Year, date.Month);
        }
        public static DateTime getCurrentMonthFirstDay()
        {
            return getMonthFirstDay(System.DateTime.Now.Year, System.DateTime.Now.Month);
        }

        public static IEnumerable<SelectListItem> getMontSelectListItem (int? selectedMonth)
        {
            var result = new List<SelectListItem>();
            result.Add(new SelectListItem()
            {
                Value = "1",
                Text = "Gennaio",
                Selected = (selectedMonth.HasValue ? selectedMonth.Value == 1 : false)
            });
            result.Add(new SelectListItem()
            {
                Value = "2",
                Text = "Febbraio",
                Selected = (selectedMonth.HasValue ? selectedMonth.Value == 2 : false)
            });
            result.Add(new SelectListItem()
            {
                Value = "3",
                Text = "Marzo",
                Selected = (selectedMonth.HasValue ? selectedMonth.Value == 3 : false)
            });
            result.Add(new SelectListItem()
            {
                Value = "4",
                Text = "Aprile",
                Selected = (selectedMonth.HasValue ? selectedMonth.Value == 4 : false)
            });
            result.Add(new SelectListItem()
            {
                Value = "5",
                Text = "Maggio",
                Selected = (selectedMonth.HasValue ? selectedMonth.Value == 5 : false)
            });
            result.Add(new SelectListItem()
            {
                Value = "6",
                Text = "Giugno",
                Selected = (selectedMonth.HasValue ? selectedMonth.Value == 6 : false)
            });
            result.Add(new SelectListItem()
            {
                Value = "7",
                Text = "Luglio",
                Selected = (selectedMonth.HasValue ? selectedMonth.Value == 7 : false)
            });
            result.Add(new SelectListItem()
            {
                Value = "8",
                Text = "Agosto",
                Selected = (selectedMonth.HasValue ? selectedMonth.Value == 8 : false)
            });
            result.Add(new SelectListItem()
            {
                Value = "9",
                Text = "Settembre",
                Selected = (selectedMonth.HasValue ? selectedMonth.Value == 9 : false)
            });
            result.Add(new SelectListItem()
            {
                Value = "10",
                Text = "Ottobre",
                Selected = (selectedMonth.HasValue ? selectedMonth.Value == 10 : false)
            });
            result.Add(new SelectListItem()
            {
                Value = "11",
                Text = "Novembre",
                Selected = (selectedMonth.HasValue ? selectedMonth.Value == 11 : false)
            });
            result.Add(new SelectListItem()
            {
                Value = "12",
                Text = "Dicembre",
                Selected = (selectedMonth.HasValue ? selectedMonth.Value == 12 : false)
            });
            return result;
        }

        public static string getMonthName(int m)
        {
            string r = null;
            switch (m)
            {
                case 1:
                    r = "Gennaio";
                break;
                case 2:
                    r = "Febbraio";
                break;
                case 3:
                    r = "Marzo";
                break;
                case 4:
                    r = "Aprile";
                break;
                case 5:
                    r = "Maggio";
                break;
                case 6:
                    r = "Giugno";
                break;
                case 7:
                    r = "Luglio";
                break;
                case 8:
                    r = "Agosto";
                break;
                case 9:
                    r = "Settembre";
                break;
                case 10:
                    r = "Ottobre";
                break;
                case 11:
                    r = "Novembre";
                break;
                case 12:
                    r = "Dicembre";
                break;
                default:
                    r = "Che minchia di mese è il " + m.ToString();
                break;
            }
            return r;
        }
        public static string getThreeCharDayName(System.DateTime dt)
        {   
            string r = getDayName(dt);
            return r.Substring(0,3);
        }
        public static string getDayName(System.DateTime dt)
        {
            string r = null;
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    r = "Lunedì";
                    break;
                case DayOfWeek.Tuesday:
                    r = "Martedì";
                    break;
                case DayOfWeek.Wednesday:
                    r = "Mercoledì";
                    break;
                case DayOfWeek.Thursday:
                    r = "Giovedì";
                    break;
                case DayOfWeek.Friday:
                    r = "Venerdì";
                    break;
                case DayOfWeek.Saturday:
                    r = "Sabato";
                    break;
                default:
                    r = "Domenica";
                    break;
            }
            return r;
        }
    }
}
