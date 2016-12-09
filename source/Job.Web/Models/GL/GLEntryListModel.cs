using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job.WebMvc.Models.GL
{
    public class GLEntryListModel
    {
        public string AccountCode { get; set; }
        public int FilterYear { get; set; }
        public short FilterPeriod { get; set; }
        public List<EFDataModel.GeneralJournalLines> GLEntries { get; private set; }
        public void loadData()
        {
            DateTime fromDate;
            DateTime toDate;
            switch (FilterPeriod)
            {
                case 1:
                    fromDate = new DateTime(FilterYear, 1, 1);
                    toDate = new DateTime(FilterYear, 3, 31);
                    break;
                case 2:
                    fromDate = new DateTime(FilterYear, 4, 1);
                    toDate = new DateTime(FilterYear, 6, 30);
                    break;
                case 3:
                    fromDate = new DateTime(FilterYear, 7, 1);
                    toDate = new DateTime(FilterYear, 9, 30);
                    break;
                case 4:
                    fromDate = new DateTime(FilterYear, 10, 1);
                    toDate = new DateTime(FilterYear, 12, 31);
                    break;
                default:
                    fromDate = new DateTime(FilterYear, 1, 1);
                    toDate = new DateTime(FilterYear, 12, 31);
                    break;
            }
            GLEntries = DataAccessLayer.DBGeneralLedger.getEntry(fromDate, toDate);
        }
    }
}