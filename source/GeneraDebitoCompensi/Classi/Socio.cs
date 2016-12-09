using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneraDebitoCompensi.Classi
{
    class Socio
    {
        public int PeopleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Compenso { get; set; }
        public string PersonBusinessAccountId { get; set; }
        public string CompensoAccountCode { get; set; }
        public string DebitAccountCode { get; set; }

        public string RegisterCode
        {
            get
            {
                return PeopleId.ToString().PadLeft(4, '0');
            }
        }
    }
}
