using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.EFDataModel
{
    public partial class Person
    {
        public string RegisterCode
        {
            get
            {
                return PeopleId.ToString().PadLeft(4,'0');
            }
        }
        public string FullName
        {
            get
            {
                return this.FirstName.Trim() + " " + this.LastName.Trim();
            }
        }
    }
}
