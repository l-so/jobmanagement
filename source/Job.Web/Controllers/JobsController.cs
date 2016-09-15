using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Job.WebMvc.Identity;

namespace Job.WebMvc.Controllers
{
    [Authorize]
    public class JobsController : Controller
    {
        // GET: Jobs
        public ActionResult Index(long? filterCustomerId, short? filterStatusOfferta, short? filterStatusOperativa, short? filterStatusChiusa, short? filterStatusArchiviata, short? filterStatusInterna)
        {
            Models.JobIndexModel model = new Models.JobIndexModel();
            model.filterStatusArchiviata = -1;
            model.filterStatusChiusa = -1;
            model.filterStatusInterna = -1;
            model.filterStatusOfferta = -1;
            model.filterStatusOperativa = -1;
            List<short> _filterStatus = new List<short>();
            if (filterStatusOperativa.HasValue || filterStatusArchiviata.HasValue || filterStatusChiusa.HasValue || filterStatusInterna.HasValue || filterStatusOfferta.HasValue)
            {
                if (filterStatusOperativa.HasValue) { 
                    _filterStatus.Add(filterStatusOperativa.Value);
                    model.filterStatusOperativa = 1;
                 }
                if (filterStatusArchiviata.HasValue) { _filterStatus.Add(filterStatusArchiviata.Value); 
                    model.filterStatusArchiviata = 1;
                }
                if (filterStatusChiusa.HasValue) { _filterStatus.Add(filterStatusChiusa.Value);
                    model.filterStatusChiusa = 1;
                }
                if (filterStatusOfferta.HasValue) { _filterStatus.Add(filterStatusOfferta.Value);
                    model.filterStatusOfferta = 1;
                }
                if (filterStatusInterna.HasValue) { _filterStatus.Add(filterStatusInterna.Value);
                model.filterStatusInterna = 1;
                 }
            }
            else
            {
                filterStatusOperativa = 10;
                model.filterStatusOperativa = 1;
                _filterStatus.Add(filterStatusOperativa.Value); 
            }
            
            model.LoadModelData((filterCustomerId.HasValue ? filterCustomerId.Value : -1), _filterStatus.ToArray<short>());
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit (long id)
        {
            Models.Jobs.JobsEditModel model = new Models.Jobs.JobsEditModel();
            return View(model);
        }

        public ActionResult JobsWorkJournal(int? filterPeopleId, long? filterCustomerId, DateTime? filterBeginDate, DateTime? filterEndDate)
        {
            Models.Jobs.JobsWorkJournalModel model = new Models.Jobs.JobsWorkJournalModel();
            EFDataModel.Person p;
            if (filterPeopleId.HasValue)
            {
                if (filterPeopleId.Value == -1)
                {
                    p = null;
                }
                else
                {
                    p = DataAccessLayer.DBPerson.getOne(filterPeopleId.Value);
                }
            }
            else
            {
                p = this.User.Identity.GetPeople();
            }
            model.LoadModelData(p,filterCustomerId,filterBeginDate,filterEndDate);
            return View(model);
        }

        [HttpGet]
        public JsonResult GetJsonWorkJournal(long id)
        {
            EFDataModel.WorksJournal result = DataAccessLayer.DBJobs.getWorksJournalById(id);
            return new JsonResult() { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet}; 
        }
        public ActionResult WorkLogReportList(long? filterCustomerId ,int? filterWorkReportState)
        {
            Models.WorkLogReportListModel model = new Models.WorkLogReportListModel();
            model.LoadModelData(filterCustomerId,filterWorkReportState);
            return View(model);
        }

        [HttpGet]
        [OutputCache(Duration = 0, VaryByParam = "none", NoStore = true)]
        public ActionResult ModalEditJobWorkJournal(long? id, long? jobId)
        {
            if (id.HasValue)
            {
                if (id.Value == -1)
                {
                    id = null;
                }
            }
            Models.ModalEditJobWorkJournalModel model = new Models.ModalEditJobWorkJournalModel();
            model.LoadModelData(id, User.Identity.GetPeople().PeopleId, jobId);
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult ModalEditJobWorkJournal(int jobWorkJournalId, int jobId, int peopleId, DateTime date, string jobTaskId, string workedHours, string taskWhere, string annotation)
        {
            JsonResult _result = null;
            EFDataModel.WorksJournal jwj = new EFDataModel.WorksJournal();
            jwj.WorkJournalId =  jobWorkJournalId;
            jwj.JobId = jobId;
            jwj.PeopleId = peopleId;
            jwj.Date = date;
            if (string.IsNullOrWhiteSpace(taskWhere))
            {
                jwj.TaskWhere = null;
            }
            else
            {
                jwj.TaskWhere = taskWhere;
            }
            if (string.IsNullOrWhiteSpace(annotation))
            {
                jwj.Annotation = null;
            }
            else { 
                jwj.Annotation = annotation;
            }
            jwj.JobTaskId = jobTaskId;
            decimal wh = decimal.Zero;
            decimal.TryParse(workedHours, out wh);
            if (wh > 0)
            {
                jwj.WorkedHours = wh;
                _result = updateJobWorkJournalLine(jwj);
            }
            else
            {
                if (workedHours.ToUpper().EndsWith("G") || workedHours.ToUpper().EndsWith("D"))
                {
                    try { 
                        int d = int.Parse(workedHours.Substring(0, workedHours.Length - 1));
                        jwj.WorkedHours = 8;
                        EFDataModel.Jobs j = DataAccessLayer.DBJobs.getJobById(jobId);
                        if (d > 0)
                        {
                            for (int i = 1; i <= d; i++) 
                            {
                                
                                _result = updateJobWorkJournalLine(jwj);
                                jwj.WorkJournalId = -1;
                                jwj.Date = jwj.Date.AddDays(1);
                            }
                        }
                        else
                        {
                            d = -1 * d;
                            for (int i = 1; i <= d; i++) 
                            {

                                _result = updateJobWorkJournalLine(jwj);
                                jwj.WorkJournalId = -1;
                                jwj.Date = jwj.Date.AddDays(-1);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _result = new JsonResult() { Data = new { ErrorResult = "KO", ErrorMessage = e.Message } };
                    }
                }
                else
                {
                    _result = new JsonResult() { Data = new { ErrorResult = "KO", ErrorMessage = "Non capisco le ore lavorate!" } };
                }
            }
            //, string workedHours
            return _result;
        }
        internal JsonResult updateJobWorkJournalLine(EFDataModel.WorksJournal jwj)
        {
            JsonResult _result = null;
            try
            {
                DataAccessLayer.DBJobs.UpdateJobWorkLog(jwj);
                _result = new JsonResult() { Data = new { ErrorResult = "OK", ErrorMessage = "" } };
            }

            catch (System.Data.SqlClient.SqlException e)
            {
                _result = new JsonResult() { Data = new { ErrorResult = "KO", ErrorMessage = e.Message } };
            }
            catch (Exception e)
            {
                _result = new JsonResult() { Data = new { ErrorResult = "KO", ErrorMessage = e.Message } };
            }
            return _result;
        }
        [HttpPost]
        public JsonResult DeleteJobWorkJournal(int jobWorkJournalId)
        {
            JsonResult _result = null;
            try
            {
                _result = DataAccessLayer.DBJobs.WorksJournalDelete(jobWorkJournalId);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
            {
                _result = new JsonResult() { Data = new { ErrorResult = "KO", ErrorMessage = e.Message } };
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e) 
            {
                _result = new JsonResult() { Data = new { ErrorResult = "KO", ErrorMessage = e.Message } };
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                _result = new JsonResult() { Data = new { ErrorResult = "KO", ErrorMessage = e.Message } };
            }
            catch (Exception e)
            {
                _result = new JsonResult() { Data = new { ErrorResult = "KO", ErrorMessage = e.Message } };
            }
            return _result;
        }
        [HttpGet]
        [OutputCache(Duration = 0, VaryByParam = "none", NoStore = true)]
        public ActionResult ModalEditJob(long? id)
        {
            Models.ModalEditJobModel model = new Models.ModalEditJobModel();
            model.LoadModelData(id);
            return PartialView(model);
        }
        [HttpPost]
        public JsonResult ModalEditJob(EFDataModel.Jobs job)
        {
            try
            {

                DataAccessLayer.DBJobs.Update(job);
                return new JsonResult() { Data = new { ErrorResult = "OK", ErrorMessage = "" } };
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return new JsonResult() { Data = new { ErrorResult = "KO", ErrorMessage = e.Message } };
            }
            catch (Exception e)
            {
                return new JsonResult() { Data = new { ErrorResult = "KO", ErrorMessage = e.Message } };
            }

        }
        
        [HttpGet]
        [OutputCache(Duration = 0, VaryByParam = "none", NoStore = true)]
        public JsonResult WorkLogLine(int peopleId, DateTime fromDate, DateTime toDate)
        {
            
            try
            {
                List<EFDataModel.WorksJournal> res = DataAccessLayer.DBJobs.getJobWorkLog(peopleId, fromDate, toDate);
                return Json(new { ErrorResult = "OK", ErrorMessage = "", Results = res }, JsonRequestBehavior.AllowGet);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return Json(new { ErrorResult = "KO", ErrorMessage = e.Message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { ErrorResult = "KO", ErrorMessage = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}   
