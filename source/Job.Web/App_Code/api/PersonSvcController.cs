using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Job.WebMvc.Controllers.api
{
    [Authorize]
    public class PersonSvcController : ApiController
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
                IEnumerable<EFDataModel.Person> peoples = DataAccessLayer.DBPerson.getAll(true);
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
            string operation = string.Empty;
            int id = -1;
            try
            {
                Dictionary<string, string> values = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData.ToString());
                if (values.ContainsKey("Operation"))
                {
                    operation = values["Operation"];
                }
                switch (operation)
                {
                    case "PeoplePayment":
                        DateTime d = DateTime.Parse(values["Date"]);
                        id = int.Parse(values["PeopleId"]);
                        string b = values["Bank"];
                        decimal co = decimal.Parse(values["Compenso"]);
                        decimal t = decimal.Parse(values["Tasse"]);
                        decimal i = decimal.Parse(values["Inps"]);
                        DataAccessLayer.DBPayment.PeoplePayment(d, id, co, t, i, b);
                        break;
                    case "ExpensePaymentUpdate":
                        EFDataModel.PrePaymentRefound epr = new EFDataModel.PrePaymentRefound();
                        epr.Id = long.Parse(values["ExpensePaymentRefoundId"]);
                        epr.PeopleId = int.Parse(values["PeopleId"]);
                        epr.Date = DateTime.Parse(values["Date"]).Date;
                        epr.Amount = decimal.Parse(values["Amount"]);
                        epr.GLAccountCode = values["GLAccount"];
                        epr.Note = values["Note"];
                        if (epr.Id < 1)
                        {
                            epr = DataAccessLayer.DBPerson.ExpensePaymentRefoundCreate(epr);
                        }
                        else
                        {
                            epr = DataAccessLayer.DBPerson.ExpensePaymentRefoundUpdate(epr);
                        }
                        _response.Data = Newtonsoft.Json.JsonConvert.SerializeObject(epr);
                        break;
                    case "Update":
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
                        if (id < 1)
                        {
                            p = DataAccessLayer.DBPerson.Create(c, l, f, cn, idDef, idId, cp, cd, decimal.Parse(ck), actState);
                        }
                        else
                        {
                            p = DataAccessLayer.DBPerson.Update(id, c, l, f, cn, idDef, idId, cp, cd, decimal.Parse(ck), actState);
                        }
                        _response.Data = Newtonsoft.Json.JsonConvert.SerializeObject(p);
                    break;
                    case "PostExpenseRefoundMonth":
                        int peopleId = int.Parse(values["PeopleId"]);
                        int year = int.Parse(values["Year"]);
                        int month = int.Parse(values["Month"]);
                        DataAccessLayer.DBPerson.ExpensePaymentRefoundRegister(peopleId, year, month);
                        break;
                    case "PostExpenseRefound":
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