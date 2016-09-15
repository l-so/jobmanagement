using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.EFDataModel
{
    public partial class ExpensePaymentRefound
    {
        public const byte STATUS_BOZZA = 0;
        public const byte STATUS_REGISTRATA = 1;
        public string StatusDescription
        {
            get
            {
                switch (this.Status)
                {
                    case STATUS_BOZZA:
                        return "BOZZA";
                    default:
                        return "REGISTRATA";
                }
            }
        }
    }
}
