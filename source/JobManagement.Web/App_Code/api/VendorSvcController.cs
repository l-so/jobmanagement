using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JobManagement.WebMvc.Controllers.api
{
    public class VendorSvcController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
            try
            {
                long vendorId = -1;
                Dictionary<string, string> values = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData.ToString());
                string op = values["Operation"];
                switch (op)
                {
                    case "Update":
                        EFDataModel.Vendors _ven = new EFDataModel.Vendors();
                        _ven.VendorId = long.Parse(values["VendorId"]);
                        _ven.Status = byte.Parse(values["Status"]);
                        _ven.Name = values["Name"];
                        _ven.Name2 = values["Name2"];
                        _ven.VATNumber = values["VatNumber"];
                        _ven.FiscalCode = values["FiscalCode"];
                        _ven.Address = values["Address"];
                        _ven.Address1 = values["Address1"];
                        _ven.PostalCode = values["PostalCode"];
                        _ven.City = values["City"];
                        _ven.Province = values["Province"];
                        _ven.State = values["State"];
                        _ven.Country = values["Country"];
                        DataAccessLayer.DBVendor.Save(_ven);
                        break;
                }
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