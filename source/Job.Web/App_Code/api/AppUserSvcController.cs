using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Job.WebMvc.Controllers.api
{
    [Authorize(Roles = "ADMIN")]
    public class AppUserSvcController : ApiController
    {
        [AcceptVerbs("GET")]
        public Code.MyApiStandardResponse GET(long id)
        {
            string jsonSerialized = null;
            Code.MyApiStandardResponse _response = new Code.MyApiStandardResponse();
            _response.ResultStatus = "OK";
            try
            {
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

        [AcceptVerbs("POST")]
        public Code.MyApiStandardResponse POST(object jsonData)
        {
            string _userId = null;
            string _userName = null;
            string _userEmail = null;
            string _userPwd = null;
            string _userPwdConfirm = null;
            string _userRoleId = null;
            Microsoft.AspNet.Identity.IdentityResult r = null; 
            Code.MyApiStandardResponse _response = new Code.MyApiStandardResponse();
            _response.ResultStatus = "OK";
            _response.Error = null;
            _response.ErrorMessage = null;
            try
            {
                Dictionary<string, string> values = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData.ToString());
                string op = values["Operation"];
                if (values.ContainsKey("UserId"))
                {
                    _userId = values["UserId"];
                }
                if (values.ContainsKey("UserName"))
                {
                    _userName = values["UserName"];
                }
                if (values.ContainsKey("Email"))
                {
                    _userEmail = values["Email"];
                }
                if (values.ContainsKey("Passwd"))
                {
                    _userPwd = values["Passwd"];
                }
                if (values.ContainsKey("PasswdConfirm"))
                {
                    _userPwdConfirm = values["PasswdConfirm"];
                }
                if (values.ContainsKey("UserRole"))
                {
                    _userRoleId = values["UserRole"];
                }
                switch (op)
                {
                    case "Edit":
                        
                        if (string.IsNullOrWhiteSpace(_userId))
                        {
                             r = Identity.IdentityHelper.AppUserCreate(_userName, _userEmail, _userPwd, _userRoleId);
                        }
                        if (!r.Succeeded)
                        {
                            _response.ResultStatus = "KO";
                            _response.Error = "Identity creation error";
                            foreach (string s in r.Errors)
                            {
                                _response.ErrorMessage = s + Environment.NewLine;
                            }
                        }
                        break;
                    case "ResetPassword":
                        r = Identity.IdentityHelper.ResetUserPassword(_userId, _userPwd);
                        if (!r.Succeeded)
                        {
                            _response.ResultStatus = "KO";
                            _response.Error = "Identity creation error";
                            foreach (string s in r.Errors)
                            {
                                _response.ErrorMessage = s + Environment.NewLine;
                            }
                        }
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