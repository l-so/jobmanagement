using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JobManagement.WebMvc.Controllers.api
{
    [Authorize]
    public class jobdimensionsvcController : ApiController
    {
        // GET api/<controller>
        public Code.MyApiStandardResponse Get()
        {
            Code.MyApiStandardResponse r = new Code.MyApiStandardResponse();
            try
            {
                r.ResultStatus = "OK";
                r.ErrorMessage = string.Empty;
                r.Data = Newtonsoft.Json.JsonConvert.SerializeObject(DataAccessLayer.DBJobs.getJobTaskForDDL(true));
                return r;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                r.ResultStatus = "KO";
                r.ErrorMessage = e.Message;
                r.Data = null;
                return r;
            }
            catch (Exception e)
            {
                r.ResultStatus = "KO";
                r.ErrorMessage = e.Message;
                r.Data = null;
                return r;
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}