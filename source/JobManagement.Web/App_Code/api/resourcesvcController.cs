using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JobManagement.WebMvc.Controllers.api
{
    [Authorize]
    public class resourcesvcController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<System.Web.Mvc.SelectListItem> Get()
        {
            return DataAccessLayer.DBPeople.getPeopleDDL(-1);
        }

       
    }
}