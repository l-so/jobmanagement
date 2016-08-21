using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JobManagement.WebMvc.Controllers.api
{
    public class TravelExpenseLineSvcController : ApiController
    {
        [AcceptVerbs("GET")]
        public Code.MyApiStandardResponse GET(long id)
        {
            Code.MyApiStandardResponse _response = new Code.MyApiStandardResponse();
            _response.ResultStatus = "OK";
            _response.Data = null;
            try
            {
                EFDataModel.TravelExpensesLines linea = DataAccessLayer.DBTravelExpense.LineGet(id);
                string s = Newtonsoft.Json.JsonConvert.SerializeObject(linea);
                _response.Data = s;
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
            return _response;
        }
        public Code.MyApiStandardResponse Post(object jsonData)
        {
            Code.MyApiStandardResponse _response = new Code.MyApiStandardResponse();
            _response.ResultStatus = "OK";
            _response.Data = null;
            try {
                EFDataModel.TravelExpensesLines tel = new EFDataModel.TravelExpensesLines(); 
                Dictionary<string, string> values = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData.ToString());
                string ts = "";
                tel.TravelExpenseLineId = long.Parse(values["TravelExpenseLineId"]);
                tel.TravelExpenseCode = values["TravelExpenseCode"];
                ts = values["Date"];
                tel.Date = DateTime.Parse(ts);
                tel.TravelExpenseLineCategoryId = int.Parse(values["CategoryId"]);
                tel.Amount = (string.IsNullOrWhiteSpace(values["Amount"]) ? decimal.Zero : decimal.Parse(values["Amount"])); 
                tel.CarPlate = values["CarPlate"];
                tel.CarDescription = values["CarDescription"];
                tel.CarKmCost = (string.IsNullOrWhiteSpace(values["CarKmCost"]) ? decimal.Zero : decimal.Parse(values["CarKmCost"]));
                tel.CarKm = (string.IsNullOrWhiteSpace(values["CarKm"]) ? 0 : int.Parse(values["CarKm"]));
                tel.Description = values["Description"];
                tel.Note = values["Note"];
                DataAccessLayer.DBTravelExpenseLineUpdateResult r = DataAccessLayer.DBTravelExpense.LineUpdate(tel);
                string s = Newtonsoft.Json.JsonConvert.SerializeObject(r);
                _response.Data = s;
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
            catch (System.FormatException e)
            {
                _response.ResultStatus = "KO";
                _response.Error = "System.FormatException";
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

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}