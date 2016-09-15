using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job.WebMvc.Models.Person
{
    public class PersonIndexModel
    {
        public IEnumerable<EFDataModel.Person> Peoples { get; private set;}

        public void LoadModelData(bool? active)
        {
            Peoples = DataAccessLayer.DBPerson.getAll(active);
        }
    }
}