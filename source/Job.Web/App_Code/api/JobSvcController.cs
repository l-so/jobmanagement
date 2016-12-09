using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Job.WebMvc.App_Code.api
{
    public class JobSvcController : ApiController
    {
        public Code.MyApiStandardResponse Post(object jsonData)
        {
            long jobId = -1;
            decimal tempDecimal = decimal.Zero;
            int tempInt = 0;
            long tempLong = 0;
            EFDataModel.JobTasks task = new EFDataModel.JobTasks();
            Code.MyApiStandardResponse _response = new Code.MyApiStandardResponse();
            _response.ResultStatus = "OK";
            try
            {
                Dictionary<string, string> values = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData.ToString());
                string op = values["Operation"];
                switch (op)
                {
                    case "GetJobTask":
                        if (long.TryParse(values["JobId"], out jobId))
                        {
                            var jobTasks = DataAccessLayer.DALJob.getJobTasks(jobId);
                            _response.Data = Newtonsoft.Json.JsonConvert.SerializeObject(jobTasks);
                        }
                        else
                        {
                            _response.ResultStatus = "KO";
                            _response.Error = "TryParse - Paramentro mancante";
                            _response.ErrorMessage = "Valore JobId non trovato!";
                        }
                        break;
                    case "UpdateJobTask":
                        if (!long.TryParse(values["JobId"], out jobId))
                        {
                            _response.ResultStatus = "KO";
                            _response.Error = "TryParse - Paramentro mancante";
                            _response.ErrorMessage = "Valore JobId non trovato!";
                            return _response;
                        }
                        task.JobId = jobId;
                        task.JobTaskId = values["TaskCode"];
                        task.Description = values["TaskDescription"];
                        if (!string.IsNullOrWhiteSpace(values["TaskExpectedIncome"]))
                        {
                            decimal.TryParse(values["TaskExpectedIncome"], out tempDecimal);
                            task.ExpectedInvoice = tempDecimal;
                        } 
                        if (!string.IsNullOrWhiteSpace(values["TaskExpectedHourIncome"]))
                        {
                            decimal.TryParse(values["TaskExpectedHourIncome"], out tempDecimal);
                            task.IncomePerHour = tempDecimal;
                        }
                        if (!string.IsNullOrWhiteSpace(values["TaskExpectedCost"]))
                        {
                            decimal.TryParse(values["TaskExpectedCost"], out tempDecimal);
                            task.ExpectedCost = tempDecimal;
                        }
                        if (!string.IsNullOrWhiteSpace(values["TaskExpectedWorks"]))
                        {
                            int.TryParse(values["TaskExpectedWorks"], out tempInt);
                            task.ExpectedHoursOfWork = tempInt;
                        }
                        var taskUpdated = DataAccessLayer.DALJob.UpdateTask(task);
                        _response.Data = Newtonsoft.Json.JsonConvert.SerializeObject(taskUpdated);
                        break;
                    case "UpdateWorksLine":
                        EFDataModel.WorksJournal wj = new EFDataModel.WorksJournal();
                        if (!string.IsNullOrWhiteSpace(values["WorkJournalId"]))
                        {
                            long.TryParse(values["WorkJournalId"], out tempLong);
                            wj.WorkJournalId = tempLong;
                        }
                        if (!long.TryParse(values["JobId"], out jobId))
                        {
                            _response.ResultStatus = "KO";
                            _response.Error = "TryParse - Paramentro mancante";
                            _response.ErrorMessage = "Valore JobId non trovato!";
                            return _response;
                        }
                        wj.JobId = jobId;
                        wj.PeopleId = int.Parse(values["PeopleId"]);
                        wj.JobTaskId = values["TaskId"];
                        wj.Date = DateTime.Parse(values["Date"]);
                        wj.TaskWhere = values["Where"];
                        wj.Annotation = values["Note"];
                        if (!((values["Hours"].ToUpper().Last() == 'G') || (values["Hours"].ToUpper().Last() == 'D')))
                        {
                            wj.WorkedHours = decimal.Parse(values["Hours"]);
                            var r = DataAccessLayer.DALJob.UpdateWorksLine(wj);
                            _response.Data = Newtonsoft.Json.JsonConvert.SerializeObject(r);
                        } else
                        {
                            Job.Logic.Work.updateWorks(wj.JobId, wj.PeopleId, wj.JobTaskId, wj.Date, values["Hours"], wj.TaskWhere, wj.Annotation);
                        }
                        break;
                    case "DeleteWorksLine":
                        if (!long.TryParse(values["WorkJournalId"], out tempLong))
                        {
                            _response.ResultStatus = "KO";
                            _response.Error = "TryParse - Paramentro mancante";
                            _response.ErrorMessage = "Valore WorkJournalId non trovato!";
                            return _response;
                        }
                        DataAccessLayer.DALJob.DeleteWorksLine(tempLong);
                        break;


                } // switch
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