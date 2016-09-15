using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job.WebMvc.Models.GL
{
    public class GLShowAccountModel
    {
        public string AccountCode { get; set; }
        public int FilterYear { get; set; }
        public short FilterPeriod { get; set; }
        public EFDataModel.GLAccount GLAccount { get; private set; }
        public List<EFDataModel.GeneralJournalLineEntries> GLAccountLineEntries { get; private set; }
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
            GLAccount = DataAccessLayer.DBGeneralLedger.getGLAccountByCode(this.AccountCode);
            GLAccountLineEntries = DataAccessLayer.DBGeneralLedger.getJournalLines(this.AccountCode,fromDate,toDate);
            if (fromDate != new DateTime(FilterYear, 1, 1))
            {
                decimal totalDebit = DataAccessLayer.DBGeneralLedger.getGLAccountTotal(fromDate, this.AccountCode,"D");
                decimal totalCredit = DataAccessLayer.DBGeneralLedger.getGLAccountTotal(fromDate, this.AccountCode, "A");
                EFDataModel.GeneralJournalLineEntries l = new EFDataModel.GeneralJournalLineEntries()
                {
                    Date = fromDate,
                    GLAccountCode = AccountCode,
                    GLAccount = DataAccessLayer.DBGeneralLedger.getGLAccountByCode(AccountCode),
                    GeneralJournalLines = new EFDataModel.GeneralJournalLines()
                    {
                        Date = fromDate,
                        Description = "Valore apertura del periodo"
                    }
                };
                if (totalDebit > totalCredit)
                {
                    l.DebitCredit = "D";
                    l.Amount = totalDebit - totalCredit;
                    GLAccountLineEntries.Insert(0, l);
                } else
                {
                    if (totalCredit > totalDebit)
                    {
                        l.DebitCredit = "A";
                        l.Amount = totalCredit - totalDebit;
                        GLAccountLineEntries.Insert(0, l);
                    }
                }
            }
        }
    }
}