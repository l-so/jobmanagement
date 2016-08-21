using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobManagement.WebMvc.Models.People
{
    public class PeopleIndexModel
    {
        public IEnumerable<EFDataModel.Person> Peoples { get; private set;}

        public void LoadModelData(bool? active)
        {
            Peoples = DataAccessLayer.DBPeople.getAll(active);
        }
    }
}