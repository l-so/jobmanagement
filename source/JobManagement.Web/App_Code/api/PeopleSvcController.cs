using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JobManagement.WebMvc.Controllers.api
{
    public class PeopleSvcController : ApiController
    {
        [AcceptVerbs("GET")]
        //http://localhost/zzspace/api/PeopleSvc?filterscount=0&groupscount=0&pagenum=0&pagesize=10&recordstartindex=0&recordendindex=16&_=1466841839889
        public string Get()
        {
            string _resString = null;
            Code.MyApiStandardResponse _response = new Code.MyApiStandardResponse();
            _response.ResultStatus = "OK";
            _response.Data = null;
            try
            {
                IEnumerable<EFDataModel.Person> peoples = DataAccessLayer.DBPeople.getAll(true);
                _resString = Newtonsoft.Json.JsonConvert.SerializeObject(peoples);
                _response.Data = _resString;
                
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
            {
                _response.ResultStatus = "KO";
                _response.Error = "System.Data.Entity.Infrastructure.DbUpdateConcurrencyException";
                _response.ErrorMessage = e.Message;
                _response.Data = null;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                _response.ResultStatus = "KO";
                _response.Error = "System.Data.Entity.Infrastructure.DbUpdateException";
                _response.ErrorMessage = e.Message;
                _response.Data = null;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                _response.ResultStatus = "KO";
                _response.Error = "System.Data.Entity.Validation.DbEntityValidationException";
                _response.ErrorMessage = e.Message;
                _response.Data = null;
            }
            catch (System.NotSupportedException e)
            {
                _response.ResultStatus = "KO";
                _response.Error = "System.NotSupportedException";
                _response.ErrorMessage = e.Message;
                _response.Data = null;
            }
            catch (System.ObjectDisposedException e)
            {
                _response.ResultStatus = "KO";
                _response.Error = "System.ObjectDisposedException";
                _response.ErrorMessage = e.Message;
                _response.Data = null;
            }
            catch (System.InvalidOperationException e)
            {
                _response.ResultStatus = "KO";
                _response.Error = "System.InvalidOperationException";
                _response.ErrorMessage = e.Message;
                _response.Data = null;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                _response.ResultStatus = "KO";
                _response.Error = "System.Data.SqlClient.SqlException";
                _response.ErrorMessage = e.Message;
                _response.Data = null;
            }
            catch (System.ArgumentNullException e)
            {
                _response.ResultStatus = "KO";
                _response.Error = "System.ArgumentNullException";
                _response.ErrorMessage = e.Message;
                _response.Data = null;
            }
            catch (System.Data.DataException e)
            {
                _response.ResultStatus = "KO";
                _response.Error = "System.Data.DataException";
                _response.ErrorMessage = e.Message;
                _response.Data = null;
            }
            catch (Exception e)
            {
                _response.ResultStatus = "KO";
                _response.Error = "Exception";
                _response.ErrorMessage = e.Message;
                _response.Data = null;
            }
            return _resString;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public Code.MyApiStandardResponse Post(object jsonData)
        {
            Code.MyApiStandardResponse _response = new Code.MyApiStandardResponse();
            _response.ResultStatus = "OK";
            try { 
                Dictionary<string, string> values = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData.ToString());
                int id = -1;
                if (values.Keys.Contains("PeopleId"))
                {
                    id = int.Parse(values["PeopleId"]);
                }
                string c = values["Code"];
                string l = values["LastName"];
                string f = values["FirstName"];
                string cn = values["CompanyName"];
                bool actState = true;
                if (values.Keys.Contains("ActiveState"))
                {
                    if (!string.IsNullOrWhiteSpace(values["ActiveState"])) 
                    { 
                        actState = bool.Parse(values["ActiveState"]);
                    }
                }
                
                bool idDef = false;
                if (values.Keys.Contains("IdentityDefault"))
                {
                    idDef = bool.Parse(values["IdentityDefault"]);
                }
                string idId = null;
                if (values.Keys.Contains("IdentityId"))
                {
                    idId = values["IdentityId"];
                }
                string cp = values["CarPlate"];
                string cd = values["CarDescription"];
                string ck = values["CarKmCost"];
                if (string.IsNullOrWhiteSpace(ck))
                {
                    ck = "0";
                }
                EFDataModel.Person p = null;
                if (id < 1) { 
                    p = DataAccessLayer.DBPeople.Create(c,l,f,cn,idDef,idId,cp,cd,decimal.Parse(ck),actState);
                }
                else {
                    p = DataAccessLayer.DBPeople.Update(id, c, l, f, cn, idDef, idId, cp, cd, decimal.Parse(ck),actState);
                }
               _response.Data = Newtonsoft.Json.JsonConvert.SerializeObject(p);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
            {
                _response.ResultStatus = "KO";
                _response.Error = "System.Data.Entity.Infrastructure.DbUpdateConcurrencyException";
                _response.ErrorMessage = e.Message;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                _response.ResultStatus = "KO";
                _response.Error = "System.Data.Entity.Infrastructure.DbUpdateException";
                _response.ErrorMessage = e.Message;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                _response.ResultStatus = "KO";
                _response.Error = "System.Data.Entity.Validation.DbEntityValidationException";
                _response.ErrorMessage = e.Message;
            }
            catch (System.NotSupportedException e)
            {
                _response.ResultStatus = "KO";
                _response.Error = "System.NotSupportedException";
                _response.ErrorMessage = e.Message;
            }
            catch (System.ObjectDisposedException e)
            {
                _response.ResultStatus = "KO";
                _response.Error = "System.ObjectDisposedException";
                _response.ErrorMessage = e.Message;
            }
            catch (System.InvalidOperationException e)
            {
                _response.ResultStatus = "KO";
                _response.Error = "System.InvalidOperationException";
                _response.ErrorMessage = e.Message;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                _response.ResultStatus = "KO";
                _response.Error = "System.Data.SqlClient.SqlException";
                _response.ErrorMessage = e.Message;
            }
            catch (System.ArgumentNullException e)
            {
                _response.ResultStatus = "KO";
                _response.Error = "System.ArgumentNullException";
                _response.ErrorMessage = e.Message;
            }
            catch (System.Data.DataException e)
            {
                _response.ResultStatus = "KO";
                _response.Error = "System.Data.DataException";
                _response.ErrorMessage = e.Message;
            }
            catch (Exception e)
            {
                _response.ResultStatus = "KO";
                _response.Error = "Exception";
                _response.ErrorMessage = e.Message;
            }
            return _response;
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