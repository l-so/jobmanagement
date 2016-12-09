using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Job.WebMvc.Controllers.api
{
    [Authorize]
    public class TravelExpenseSvcController : ApiController
    {

        // POST api/<controller>
        public Code.MyApiStandardResponse Post(object jsonData)
        {
            string travelExpenseCode = null;
            string jsonSerialized = null;
            EFDataModel.TravelExpenses teResult = null;
            Code.MyApiStandardResponse _response = new Code.MyApiStandardResponse();
            _response.ResultStatus = "OK";
            try { 
                Dictionary<string, string> values = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData.ToString());
                string op = values["Operation"];
                switch (op)
                {
                    case "Filter":
                        int month = int.Parse(values["FilterMonth"]);
                        int year = int.Parse(values["FilterYear"]);
                        int status = int.Parse(values["FilterStatus"]);
                        int peopleId = int.Parse(values["FilterPeopleId"]);
                        var r = DataAccessLayer.DBTravelExpense.GetTravelExpenseInMonth(peopleId,month,year,status);
                        jsonSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(r);
                        _response.Data = jsonSerialized;
                        break;
                    case "Update":
                        travelExpenseCode = values["TravelExpenseCode"];
                        int tePeopleId = int.Parse(values["PeopleId"]);
                        string teTypeId = values["TypeId"];
                        string teDescription = values["Description"];
                        DateTime teDate = DateTime.Parse( values["Date"]);
                        teResult = DataAccessLayer.DBTravelExpense.Update(travelExpenseCode, tePeopleId, teTypeId, teDate, teDescription);
                        if (teResult != null)
                        {
                            _response.Data = Newtonsoft.Json.JsonConvert.SerializeObject(teResult);
                        }
                        else
                        {
                            _response.ResultStatus = "KO";
                            _response.Error = "Errore mio ignoto!";
                            _response.ErrorMessage = "Non sono riuscito a leggere le modifiche/creazione!";
                        }
                        break;
                    case "RetrieveLines":
                        travelExpenseCode = values["TravelExpenseCode"];
                        List<EFDataModel.TravelExpensesLines> lines = DataAccessLayer.DBTravelExpense.getLines(travelExpenseCode);
                        _response.Data = Newtonsoft.Json.JsonConvert.SerializeObject(lines);
                        break;
                    case "TravelExpenseUpdateHeader":
                        travelExpenseCode = values["TravelExpenseCode"];
                        string note = values["Note"];
                        decimal invAmount = string.IsNullOrWhiteSpace(values["InvoiceAmount"]) ? decimal.Zero : decimal.Parse(values["InvoiceAmount"]);
                        DataAccessLayer.DBTravelExpense.UpdateHeader(travelExpenseCode, note, invAmount);
                        break;
                    case "GetTravelExpenseRegisterConfirmData":
                        travelExpenseCode = values["TravelExpenseCode"];
                        string workIdList = values["WorkIdList"];
                        string[] js = workIdList.Split('#');
                        List<string> j = new List<string>();
                        bool e = true;
                        foreach(var a in js)
                        {
                            foreach(var aa in j)
                            {
                                if (aa == a)
                                {
                                    e = false;
                                }
                            }
                            if (e)
                            {
                                j.Add(a);
                            } else
                            {
                                e = true;
                            }
                        }
                        Job.Code.RegisterGetConfirmDataResult rrr = DataAccessLayer.DBTravelExpense.RegisterGetConfirmData(travelExpenseCode, j);
                        _response.Data = Newtonsoft.Json.JsonConvert.SerializeObject(rrr);
                        break;
                    case "TravelExpenseRegisterConfirm":
                        travelExpenseCode = values["TravelExpenseCode"];
                        string registerData = values["RegisterData"];
                        _response.Data = DataAccessLayer.DBTravelExpense.Register(registerData);
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
    }
}