using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JobManagement.WebMvc.Controllers.api
{
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
                        int peopleId = int.Parse(values["FilterPeopleId"]);
                        var r = DataAccessLayer.DBTravelExpense.GetTravelExpenseInMonth(peopleId,month,year);
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
                    case "AssignJob":
                        travelExpenseCode = values["TravelExpenseCode"];
                        long teJobJobId = long.Parse(values["JobsId"]);
                        decimal teJobAmount = decimal.Parse(values["TotalPercent"]);
                        string jobLines = DataAccessLayer.DBTravelExpense.AssignJob(travelExpenseCode,teJobJobId,teJobAmount);
                        _response.Data = jobLines;
                        break;
                    case "LoadJobs":
                        travelExpenseCode = values["TravelExpenseCode"];
                        string js = DataAccessLayer.DBTravelExpense.LoadTravelExpensJobs(travelExpenseCode);
                        _response.Data = js;
                        break;
                    case "RemoveJob":
                        travelExpenseCode = values["TravelExpenseCode"];
                        long jobsId = long.Parse(values["JobsId"]);
                        DataAccessLayer.DBTravelExpense.RemoveJobs(travelExpenseCode,jobsId);
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