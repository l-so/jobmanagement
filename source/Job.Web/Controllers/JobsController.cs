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
        public ActionResult Index(long? filterCustomerId, byte? filterStatusOfferta, byte? filterStatusOperativa, byte? filterStatusChiusa, byte? filterStatusArchiviata, byte? filterStatusInterna)
        {
            Models.JobIndexModel model = new Models.JobIndexModel();
            model.filterStatusArchiviata = 0;
            model.filterStatusChiusa = 0;
            model.filterStatusInterna = 0;
            model.filterStatusOfferta = 0;
            model.filterStatusOperativa = 0;
            List<byte> _filterStatus = new List<byte>();
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
                filterStatusOperativa = 100;
                model.filterStatusOperativa = 1;
                _filterStatus.Add(filterStatusOperativa.Value); 
            }
            
            model.LoadModelData((filterCustomerId.HasValue ? filterCustomerId.Value : -1), _filterStatus.ToArray<byte>());
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit (long id)
        {
            Models.Jobs.JobsEditModel model = new Models.Jobs.JobsEditModel();
            model.loadData(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(string jobId, string jobCode, string jobCustomerId, string jobDescription, string jobStatus, string jobExpectedWorkHours, string jobExpectedCost, string jobExpectedIncome)
        {
            EFDataModel.Jobs _job = new EFDataModel.Jobs();
            _job.JobId = long.Parse(jobId);
            _job.CustomerId = long.Parse(jobCustomerId);
            _job.Status = byte.Parse(jobStatus);
            _job.Code = jobCode;
            _job.Description = jobDescription;
            DataAccessLayer.DBJobs.Update(_job);
            Models.Jobs.JobsEditModel model = new Models.Jobs.JobsEditModel();
            model.loadData(_job.JobId);
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
                    decimal d = 0;
                    int h = 0;
                    decimal.TryParse(workedHours.Substring(0, workedHours.Length - 1), out d);
                    if (d >= 1 || d <= -1) 
                    {
                        try { 
                            jwj.WorkedHours = 8;
                            //EFDataModel.Jobs j = DataAccessLayer.DBJobs.getJobById(jobId);
                            _result = updateJobWorkJournalLine(jwj);
                            if (d > 1)
                            {
                                for (int i = 2; i <= d; i++) 
                                {
                                    jwj.WorkJournalId = -1;
                                    jwj.Date = jwj.Date.AddDays(1);
                                    _result = updateJobWorkJournalLine(jwj);
                                    h = i;
                                }
                                jwj.Date = jwj.Date.AddDays(1);
                            }
                            if (d < -1) {
                                d = Math.Abs(d);
                                for (int i = 2; i <= d; i++)
                                {
                                    jwj.WorkJournalId = -1;
                                    jwj.Date = jwj.Date.AddDays(-1);
                                    _result = updateJobWorkJournalLine(jwj);
                                    h = i;
                                }
                                jwj.Date = jwj.Date.AddDays(-1);
                            }
                            if ((d - h) > 0)
                            {
                                d = d-h;
                            }
                        }
                        catch (Exception e)
                        {
                            _result = new JsonResult() { Data = new { ErrorResult = "KO", ErrorMessage = e.Message } };
                        }
                    }
                    if (Math.Abs(d) > 0 && Math.Abs(d) < 1)
                    {
                        try {
                            switch (Math.Abs(d).ToString().Substring(0, 3))
                            {
                                case "0.1": //0.125
                                    jwj.WorkedHours = 1;
                                break;
                                case "0.2": //0.25
                                    jwj.WorkedHours = 2;
                                break;
                                case "0.3": //0.375
                                    jwj.WorkedHours = 3;
                                break;
                                case "0.5":
                                    jwj.WorkedHours = 4;
                                break;
                                case "0.6": // 0.625
                                    jwj.WorkedHours = 5;
                                break;
                                case "0.7": // 0.75
                                    jwj.WorkedHours = 6;
                                break;
                                case "0.8": // 0.875
                                    jwj.WorkedHours = 7;
                                break;
                            }
                            _result = updateJobWorkJournalLine(jwj);
                        }
                        catch (Exception e)
                        {
                            _result = new JsonResult() { Data = new { ErrorResult = "KO", ErrorMessage = e.Message } };
                        }
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
                DataAccessLayer.DALJob.UpdateWorksLine(jwj);
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
                if (job.JobId < 1)
                {
                    DataAccessLayer.DBJobs.Create(job.Year, job.CustomerId, job.Description, job.Status);
                }
                else
                {
                    DataAccessLayer.DBJobs.Update(job);
                }
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

        public ActionResult EditDialogJobTask(string jobId, string taskId)
        {
            Models.Jobs.EditDialogJobTaskModel model = new Models.Jobs.EditDialogJobTaskModel();
            if (string.IsNullOrWhiteSpace(jobId))
            {
                RedirectToAction("NotifyError", "Notify");
            }
            model.LoadData(long.Parse(jobId), taskId);
            return PartialView(model);
        }

        public ActionResult EditDialogWorks(long? id, long? jobId)
        {
            Models.Jobs.EditDialogWorksModel model = new Models.Jobs.EditDialogWorksModel();
            model.LoadModelData(id, User.Identity.GetPeople().PeopleId, jobId);
            return PartialView(model);
        }
    }
}   
