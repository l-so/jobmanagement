using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.EFDataModel
{
    public partial class Person
    {
        public string FullName
        {
            get
            {
                return this.FirstName.Trim() + " " + this.LastName.Trim();
            }
        }
    }
}
