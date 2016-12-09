using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;
using Job.Code;

namespace Job.DataAccessLayer
{
    public class DBTravelExpense
    {
        public static List<EFDataModel.WorksJournal> getPeopleWork(int peopleId, DateTime fromDate, DateTime toDate)
        {
            List<EFDataModel.WorksJournal> _result = null;
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    _result = ctx.WorksJournal.Include("Jobs").Where(w => w.PeopleId == peopleId && w.Date >= fromDate && w.Date <= toDate).OrderBy(w => w.Date).ToList();
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return _result;
        }
        public static object GetTravelExpenseInMonth(int peopleId, int m, int y, int status)
        {
            DateTime fromDate;
            DateTime toDate;
            if (m == 99)
            {
                fromDate = new DateTime(y, 1, 1);
                toDate = new DateTime(y, 12, 31);
            }
            else
            {
                fromDate = new DateTime(y, m, 1);
                toDate = new DateTime(y, m, DateTime.DaysInMonth(y, m));
            }
            List<EFDataModel.TravelExpenseList> _result = new List<EFDataModel.TravelExpenseList>();
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    if (status > 900)
                    {
                        _result = ctx.TravelExpenseList.Where(t => t.PeopleId == peopleId && t.Date >= fromDate && t.Date <= toDate).ToList<EFDataModel.TravelExpenseList>();
                    } else
                    {
                        _result = ctx.TravelExpenseList.Where(t => t.PeopleId == peopleId && t.Status == status && t.Date >= fromDate && t.Date <= toDate).ToList<EFDataModel.TravelExpenseList>();
                    }
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return _result;
        }

        public static EFDataModel.TravelExpenses getOne(string travelExpenseCode)
        {
            EFDataModel.TravelExpenses _result = null;
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    _result = ctx.TravelExpenses.Find(travelExpenseCode);
                    _result.Person = ctx.Person.Find(_result.PeopleId);
                    _result.Person.TravelExpenses.Clear();
                    _result.Person.PersonBusinessAccount = ctx.PersonBusinessAccount.Where( a => a.Code ==_result.Person.PersonBusinessAccountId).FirstOrDefault();
                    _result.Person.PersonBusinessAccount.Person = null;
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return _result;
        }

        public static RegisterGetConfirmDataResult RegisterGetConfirmData(string travelExpenseCode, List<string> workIdList)
        {
            RegisterGetConfirmDataResult _result = new RegisterGetConfirmDataResult();
            _result.Jobs = new List<RegisterGetConfirmDataResultJob>();
            string cnnString = WebConfigurationManager.ConnectionStrings["JobSQLConnectionString"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cnnString))
            {
                cnn.Open();
                try
                {
                    // Command Objects for the transaction
                    SqlCommand cmd1 = new SqlCommand("SELECT [TravelExpenseCode],[Date],[Annotation],[Status],[PeopleId],[FirstName],[LastName],[Code],[BeginDate],[EndDate],[Total],[InvoiceAmount] FROM [Job].[TravelExpenseList]  WHERE [TravelExpenseCode] = @TravelExpenseCode;", cnn);
                    cmd1.CommandType = System.Data.CommandType.Text;
                    cmd1.Parameters.Add(new SqlParameter("@TravelExpenseCode", System.Data.SqlDbType.NVarChar, 50));
                    cmd1.Parameters["@TravelExpenseCode"].Value = travelExpenseCode;
                    using(System.Data.SqlClient.SqlDataReader rdr = cmd1.ExecuteReader(System.Data.CommandBehavior.SingleRow))
                    {
                        while(rdr.Read())
                        {
                            _result.TravelExpenseCode = rdr.GetString(0);
                            _result.TravelExpenseFromDate = rdr.GetDateTime(8);
                            _result.TravelExpenseToDate = rdr.GetDateTime(9);
                            _result.PeopleId = rdr.GetInt32(4);
                            _result.PeopleFullName = rdr.GetString(5) + " " + rdr.GetString(6);
                            _result.TravelExpenseTotal = rdr.GetDecimal(10);
                            _result.TravelExpenseInvoiceAmount = rdr.GetDecimal(11);
                        }
                    }
                    string t = string.Empty;
                    string sqlCmd = "SELECT W.[JobId], J.[Code], J.[Description], SUM(W.[WorkedHours]) as [Hours] FROM [Job].[WorksJournal] W LEFT JOIN [Job].[Jobs] J ON W.[JobId] = J.[JobId] WHERE W.[PeopleId] = @PeopleId AND ";
                    if (workIdList.Count > 1)
                    {
                        foreach (var i in workIdList)
                        {
                            t += i + ',';
                        }
                        sqlCmd += "W.[WorkJournalId] IN (" + t.Substring(0, t.Length - 1) + ")";
                    }
                    else
                    {
                        sqlCmd += "W.[WorkJournalId] = " + workIdList[0];
                    }
                    sqlCmd += " GROUP BY W.[JobId], J.[Code], J.[Description];";
                    SqlCommand cmd2 = new SqlCommand(sqlCmd, cnn);
                    cmd2.CommandType = System.Data.CommandType.Text;
                    cmd2.Parameters.Add(new SqlParameter("@PeopleId", System.Data.SqlDbType.Int));
                    cmd2.Parameters["@PeopleId"].Value = _result.PeopleId;

                    decimal totOre = 0;
                    using (SqlDataReader rdr = cmd2.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            _result.Jobs.Add(new Code.RegisterGetConfirmDataResultJob()
                            {
                                JobId = rdr.GetInt64(0),
                                Code = rdr.GetString(1),
                                Description = rdr.GetString(2),
                                Hours = rdr.GetDecimal(3)
                            });
                            totOre += rdr.GetDecimal(3);
                        }
                    }
                    decimal tot = _result.TravelExpenseInvoiceAmount + _result.TravelExpenseTotal;
                    foreach(var jj in _result.Jobs)
                    {
                        jj.Amount = tot * (jj.Hours / totOre);
                    }
                    
                }
                catch (SqlException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    cnn.Close();
                    cnn.Dispose();
                }
            }
            return _result;
        }

   
        public static void UpdateHeader(string travelExpenseCode, string note, decimal invoiceAmount)
        {
            string cnnString = WebConfigurationManager.ConnectionStrings["JobSQLConnectionString"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cnnString))
            {
                cnn.Open();
                try
                {
                    string sqlCmd = "UPDATE [Job].[TravelExpenses] SET [Annotation] = @Annotation, [InvoiceAmount] = @InvoiceAmount WHERE [TravelExpenseCode] = @TravelExpenseCode;";
                    SqlCommand updateTEHeader = new SqlCommand(sqlCmd, cnn);
                    updateTEHeader.CommandType = System.Data.CommandType.Text;
                    updateTEHeader.Parameters.Add(new SqlParameter("@Annotation", System.Data.SqlDbType.NVarChar));
                    if (string.IsNullOrWhiteSpace(note))
                    {
                        updateTEHeader.Parameters["@Annotation"].Value = DBNull.Value;
                    }
                    else
                    {
                        updateTEHeader.Parameters["@Annotation"].Value = note;
                    }
                    updateTEHeader.Parameters.Add(new SqlParameter("@InvoiceAmount", System.Data.SqlDbType.Decimal));
                    updateTEHeader.Parameters["@InvoiceAmount"].Precision = 18;
                    updateTEHeader.Parameters["@InvoiceAmount"].Scale = 2;
                    updateTEHeader.Parameters["@InvoiceAmount"].Value = invoiceAmount;
                    updateTEHeader.Parameters.Add(new SqlParameter("@TravelExpenseCode", System.Data.SqlDbType.NVarChar, 20));
                    updateTEHeader.Parameters["@TravelExpenseCode"].Value = travelExpenseCode;
                    updateTEHeader.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    cnn.Close();
                    cnn.Dispose();
                }
            }
        }

        public static EFDataModel.TravelExpenseList getOneFromList(string travelExpenseCode)
        {
            EFDataModel.TravelExpenseList _result = null;
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    _result = ctx.TravelExpenseList.Where(t => t.TravelExpenseCode == travelExpenseCode).FirstOrDefault<EFDataModel.TravelExpenseList>();
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException)
            {
                throw;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                throw;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return _result;
        }


        public static List<EFDataModel.TravelExpensesLines> getLines(string travelExpenseCode)
        {
            List<EFDataModel.TravelExpensesLines> _result = new List<EFDataModel.TravelExpensesLines>();
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    _result = ctx.TravelExpensesLines.Include("TravelExpenseLineCategories").Where(tel => tel.TravelExpenseCode == travelExpenseCode).ToList<EFDataModel.TravelExpensesLines>();
                    foreach (var l in _result)
                    {
                        if (l.TravelExpenseLineCategories != null)
                        {
                            if (l.TravelExpenseLineCategories.TravelExpensesLines != null)
                            {
                                if (l.TravelExpenseLineCategories.TravelExpensesLines.Count != 0)
                                {
                                    l.TravelExpenseLineCategories.TravelExpensesLines.Clear();
                                }
                            }
                        }
                    }
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException)
            {
                throw;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                throw;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                throw;
            }
            catch (System.NotSupportedException)
            {
                throw;
            }
            catch (System.ObjectDisposedException)
            {
                throw;
            }
            catch (System.InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return _result;

        }

 
        public static EFDataModel.TravelExpensesLines LineGet(long id)
        {
            EFDataModel.TravelExpensesLines _result = new EFDataModel.TravelExpensesLines();
            try
            {
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    ctx.Configuration.ProxyCreationEnabled = false;
                    _result = ctx.TravelExpensesLines.Find(id);
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException)
            {
                throw;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                throw;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                throw;
            }
            catch (System.NotSupportedException)
            {
                throw;
            }
            catch (System.ObjectDisposedException)
            {
                throw;
            }
            catch (System.InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return _result;
        }

        public static void LineDelete()
        {

        }

        public static List<System.Web.Mvc.SelectListItem> getLineCategory()
        {
            List<System.Web.Mvc.SelectListItem> list = new List<System.Web.Mvc.SelectListItem>();
            try
            {
                List<EFDataModel.TravelExpenseLineCategories> lineCategories = null;
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
                {
                    lineCategories = db.TravelExpenseLineCategories.ToList<EFDataModel.TravelExpenseLineCategories>();
                }
                if (lineCategories != null)
                {
                    foreach (var t in lineCategories)
                    {
                        var item = new System.Web.Mvc.SelectListItem()
                        {
                            Value = t.TravelExpenseLineCategoryId.ToString(),
                            Text = t.Description
                        };
                        list.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return list;
        }

        public static EFDataModel.TravelExpenseLineCategories getCarLineCategory()
        {
            EFDataModel.TravelExpenseLineCategories result = null;
            try
            {
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
                {
                    result = db.TravelExpenseLineCategories.Where(c => c.UsePersonalCar == true).FirstOrDefault<EFDataModel.TravelExpenseLineCategories>();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        public static DBTravelExpenseLineUpdateResult LineUpdate(EFDataModel.TravelExpensesLines tel)
        {
            DBTravelExpenseLineUpdateResult _res = new DBTravelExpenseLineUpdateResult();
            try
            {
                using (EFDataModel.JobEntities db = new EFDataModel.JobEntities())
                {
                    if (tel.TravelExpenseLineId > 0)
                    {
                        db.Entry(tel).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(tel).State = System.Data.Entity.EntityState.Added;
                    }
                    db.SaveChanges();
                    _res.Rows = db.TravelExpensesLines.Include("TravelExpenseLineCategories").Where(t => t.TravelExpenseCode == tel.TravelExpenseCode).OrderBy(t => t.Date).ToList();
                    _res.Total = 0;
                    foreach (EFDataModel.TravelExpensesLines t in _res.Rows)
                    {
                        _res.Total += t.Amount;
                    }

                }

                //
                string cnnString = WebConfigurationManager.ConnectionStrings["JobSQLConnectionString"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(cnnString))
                {
                    cnn.Open();
                    SqlCommand c = new SqlCommand("UPDATE [Job].[TravelExpenses] SET [Amount] = @Amount WHERE [TravelExpenseCode] = @TravelExpenseCode;", cnn);
                    c.Parameters.Add(new SqlParameter("@Amount", System.Data.SqlDbType.Decimal));
                    c.Parameters["@Amount"].Precision = 18;
                    c.Parameters["@Amount"].Scale = 2;
                    c.Parameters["@Amount"].Value = _res.Total;
                    c.Parameters.Add(new SqlParameter("@TravelExpenseCode", System.Data.SqlDbType.NVarChar,20));
                    c.Parameters["@TravelExpenseCode"].Value = tel.TravelExpenseCode;
                    int r = c.ExecuteNonQuery();
                    cnn.Close();
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return _res;
        }

        public static EFDataModel.TravelExpenses Update(string teCode, int tePeopleId, string teTypeId, DateTime teDate, string teDescription)
        {

            EFDataModel.TravelExpenses te = null;
            try
            {
                te = new EFDataModel.TravelExpenses();
                using (EFDataModel.JobEntities ctx = new EFDataModel.JobEntities())
                {
                    if (string.IsNullOrWhiteSpace(teCode))
                    {
                        string r = Create(tePeopleId, teTypeId, teDate, teDescription);
                        te = getOne(r);
                        te.Person.TravelExpenses.Clear();
                    }
                    else
                    {
                        te.TravelExpenseCode = teCode;
                        te.PeopleId = tePeopleId;
                        te.Date = teDate;
                        te.Annotation = teDescription;
                        ctx.Entry(te).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                        if (te.Person == null)
                        {
                            te.Person = DataAccessLayer.DBPerson.getOne(te.PeopleId);
                        }
                    }


                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException)
            {
                throw;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                throw;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                throw;
            }
            catch (System.NotSupportedException)
            {
                throw;
            }
            catch (System.ObjectDisposedException)
            {
                throw;
            }
            catch (System.InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return te;
        }

        public static string Create(int tePeopleId, string teTypeId, DateTime teDate, string teDescription)
        {
            string resCode = null;
            string cnnString = WebConfigurationManager.ConnectionStrings["JobSQLConnectionString"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cnnString))
            {
                SqlTransaction trn;

                cnn.Open();
                trn = cnn.BeginTransaction();

                try
                {

                    // Command Objects for the transaction
                    SqlCommand getId = new SqlCommand("[Job].[upGetElementNumber]", cnn);


                    getId.CommandType = System.Data.CommandType.StoredProcedure;
                    getId.Transaction = trn;
                    getId.Parameters.Add(new SqlParameter("@Element", System.Data.SqlDbType.NVarChar, 50));
                    getId.Parameters["@Element"].Value = "TravelExpense.Code";
                    getId.Parameters.Add(new SqlParameter("@Year", System.Data.SqlDbType.Int));
                    getId.Parameters["@Year"].Value = teDate.Year;
                    getId.Parameters.Add(new SqlParameter("@ResultId", System.Data.SqlDbType.NVarChar, 20));
                    getId.Parameters["@ResultId"].Direction = System.Data.ParameterDirection.Output;
                    int r = getId.ExecuteNonQuery();
                    resCode =  Convert.ToString(getId.Parameters["@ResultId"].Value);
                    if (string.IsNullOrWhiteSpace(resCode))
                    {
                        throw new Exception("Il codice risulta null!");
                    }
                    string sqlCmd = "INSERT INTO [Job].[TravelExpenses] ([TravelExpenseCode],[Date],[Annotation],[Status],[PeopleId],[PostDate],[InvoiceAmount],[FromDate],[ToDate],[Amount]) ";
                    sqlCmd += "VALUES (@TravelExpenseCode,@Date,@Annotation,@Status,@PeopleId,@PostDate,@InvoiceAmount,NULL,NULL,0);";
                    SqlCommand createTE = new SqlCommand(sqlCmd, cnn);
                    createTE.CommandType = System.Data.CommandType.Text;
                    createTE.Transaction = trn;

                    createTE.Parameters.Add(new SqlParameter("@TravelExpenseCode", System.Data.SqlDbType.NVarChar, 20));
                    createTE.Parameters["@TravelExpenseCode"].Value = resCode;

                    createTE.Parameters.Add(new SqlParameter("@Date", System.Data.SqlDbType.Date));
                    createTE.Parameters["@Date"].Value = teDate.Date;

                    createTE.Parameters.Add(new SqlParameter("@Annotation", System.Data.SqlDbType.NVarChar));
                    createTE.Parameters["@Annotation"].Value = teDescription;

                    createTE.Parameters.Add(new SqlParameter("@Status", System.Data.SqlDbType.TinyInt));
                    createTE.Parameters["@Status"].Value = EFDataModel.TravelExpenses.STATUS_BOZZA;

                    createTE.Parameters.Add(new SqlParameter("@PeopleId", System.Data.SqlDbType.Int));
                    createTE.Parameters["@PeopleId"].Value = tePeopleId;

                    createTE.Parameters.Add(new SqlParameter("@PostDate", System.Data.SqlDbType.Date));
                    createTE.Parameters["@PostDate"].Value = DBNull.Value;

                    createTE.Parameters.Add(new SqlParameter("@InvoiceAmount", System.Data.SqlDbType.Decimal));
                    createTE.Parameters["@InvoiceAmount"].Precision = 18;
                    createTE.Parameters["@InvoiceAmount"].Scale = 2;
                    createTE.Parameters["@InvoiceAmount"].Value = decimal.Zero;

                    createTE.ExecuteNonQuery();
                    trn.Commit();
                }
                catch (SqlException)
                {
                    trn.Rollback();
                    throw;
                }
                catch (Exception)
                {
                    trn.Rollback();
                    throw;
                }
                finally
                {
                    cnn.Close();
                    cnn.Dispose();
                }
            }
            return resCode;
        }
        
        public static string Register(string registerData)
        {
            string resCode = null;
            string teCode = string.Empty;
            Code.RegisterGetConfirmDataResult regObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Code.RegisterGetConfirmDataResult>(registerData);
            teCode = regObject.TravelExpenseCode;
            string cnnString = WebConfigurationManager.ConnectionStrings["JobSQLConnectionString"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cnnString))
            {
                SqlTransaction trn;
                cnn.Open();
                trn = cnn.BeginTransaction();
                try
                {
                    EFDataModel.TravelExpenses te = getOne(teCode);
                    SqlCommand getId = new SqlCommand("[Job].[upGetElementNumber]", cnn);
                    getId.CommandType = System.Data.CommandType.StoredProcedure;
                    getId.Transaction = trn;
                    getId.Parameters.Add(new SqlParameter("@Element", System.Data.SqlDbType.NVarChar, 50));
                    getId.Parameters["@Element"].Value = "GLAccountEntries.LineNumber";
                    getId.Parameters.Add(new SqlParameter("@Year", System.Data.SqlDbType.Int));
                    getId.Parameters["@Year"].Value = te.Date.Year;
                    getId.Parameters.Add(new SqlParameter("@ResultId", System.Data.SqlDbType.NVarChar, 20));
                    getId.Parameters["@ResultId"].Direction = System.Data.ParameterDirection.Output;
                    int r = getId.ExecuteNonQuery();
                    resCode = Convert.ToString(getId.Parameters["@ResultId"].Value);
                    if (string.IsNullOrWhiteSpace(resCode))
                    {
                        throw new Exception("Il codice risulta null!");
                    }
                    // Registro la nota spese
                    string s = "INSERT INTO [Job].[GeneralJournalLines] ([Date],[LineNumber],[Description],[Type],[EntryDocCode],[EntryDocType]) ";
                    s += "VALUES (@Date, @LineNr, @Description,'S',@EntryDocCode,1);SELECT SCOPE_IDENTITY();";
                    SqlCommand regStep1 = new SqlCommand(s, cnn);
                    regStep1.CommandType = System.Data.CommandType.Text;
                    regStep1.Transaction = trn;
                    regStep1.Parameters.Add(new SqlParameter("@Date", System.Data.SqlDbType.Date));
                    regStep1.Parameters["@Date"].Value = te.Date;
                    regStep1.Parameters.Add(new SqlParameter("@LineNr", System.Data.SqlDbType.Int));
                    regStep1.Parameters["@LineNr"].Value = int.Parse(resCode);
                    regStep1.Parameters.Add(new SqlParameter("@Description", System.Data.SqlDbType.NVarChar));
                    regStep1.Parameters["@Description"].Value = "REG Spese trasferta " + te.TravelExpenseCode + " di " + te.Person.FullName;
                    regStep1.Parameters.Add(new SqlParameter("@EntryDocCode", System.Data.SqlDbType.NVarChar));
                    regStep1.Parameters["@EntryDocCode"].Value = teCode;
                    object res = regStep1.ExecuteScalar();
                    long ln = 0;
                    if (res == null)
                    {
                        throw new Exception("GeneralJournalLines: numero riga risulta null!");
                    }
                    else
                    {
                        ln = Convert.ToInt64(res);
                    }
                    s = "INSERT INTO [Job].[GeneralJournalLineEntries] ([GenerlaJournalLineId],[Date],[Position],[GLAccountCode],[Amount],[DebitCredit],[Type]) ";
                    s += "VALUES (@GeneralJournalLineId, @PostDate, 1, @PostPeopleAccountCode, @Total,'A','S');";
                    SqlCommand regStep2 = new SqlCommand(s, cnn);
                    regStep2.CommandType = System.Data.CommandType.Text;
                    regStep2.Transaction = trn;
                    regStep2.Parameters.Add(new SqlParameter("@GeneralJournalLineId", System.Data.SqlDbType.Int));
                    regStep2.Parameters["@GeneralJournalLineId"].Value = ln;
                    regStep2.Parameters.Add(new SqlParameter("@PostDate", System.Data.SqlDbType.Date));
                    regStep2.Parameters["@PostDate"].Value = te.Date;
                    regStep2.Parameters.Add(new SqlParameter("@PostPeopleAccountCode", System.Data.SqlDbType.NVarChar));
                    regStep2.Parameters["@PostPeopleAccountCode"].Value = te.Person.PersonBusinessAccount.DebitAccountCode + "." + te.Person.RegisterCode;
                    regStep2.Parameters.Add(new SqlParameter("@Total", System.Data.SqlDbType.Decimal));
                    regStep2.Parameters["@Total"].Precision = 18;
                    regStep2.Parameters["@Total"].Scale = 2;
                    regStep2.Parameters["@Total"].Value = te.Amount;
                    r = regStep2.ExecuteNonQuery();
                    s = "INSERT INTO [Job].[GeneralJournalLineEntries] ([GenerlaJournalLineId],[Date],[Position],[GLAccountCode],[Amount],[DebitCredit],[Type]) ";
                    s += "VALUES (@GeneralJournalLineId, @PostDate, 2, @TravelExpensePostAccountCode, @Total,'D','S');";
                    SqlCommand regStep3 = new SqlCommand(s, cnn);
                    regStep3.CommandType = System.Data.CommandType.Text;
                    regStep3.Transaction = trn;
                    regStep3.Parameters.Add(new SqlParameter("@GeneralJournalLineId", System.Data.SqlDbType.Int));
                    regStep3.Parameters["@GeneralJournalLineId"].Value = ln;
                    regStep3.Parameters.Add(new SqlParameter("@PostDate", System.Data.SqlDbType.Date));
                    regStep3.Parameters["@PostDate"].Value = te.Date;
                    regStep3.Parameters.Add(new SqlParameter("@TravelExpensePostAccountCode", System.Data.SqlDbType.NVarChar));
                    regStep3.Parameters["@TravelExpensePostAccountCode"].Value = te.Person.PersonBusinessAccount.TravelExpenseAccountCode + "." + te.Person.RegisterCode;
                    regStep3.Parameters.Add(new SqlParameter("@Total", System.Data.SqlDbType.Decimal));
                    regStep3.Parameters["@Total"].Precision = 18;
                    regStep3.Parameters["@Total"].Scale = 2;
                    regStep3.Parameters["@Total"].Value = te.Amount;
                    r = regStep3.ExecuteNonQuery();
                    // Aggiorno il bilancio di commessa
                    s = "INSERT INTO[Job].[JobBalance] ([JobId],[Date],[GLAccountCode],[Amount],[DocumentCode],[DocumentType]) ";
                    s += "VALUES(@JobId, @Date, @GLAccountCode, @Amount, @DocumentCode, 1)";
                    SqlCommand rsCmdBalance1 = new SqlCommand(s, cnn);
                    rsCmdBalance1.CommandType = System.Data.CommandType.Text;
                    rsCmdBalance1.Transaction = trn;
                    rsCmdBalance1.Parameters.Add(new SqlParameter("@JobId", System.Data.SqlDbType.BigInt));
                    rsCmdBalance1.Parameters.Add(new SqlParameter("@Date", System.Data.SqlDbType.Date));
                    rsCmdBalance1.Parameters.Add(new SqlParameter("@GLAccountCode", System.Data.SqlDbType.NVarChar, 50));
                    rsCmdBalance1.Parameters.Add(new SqlParameter("@DocumentCode", System.Data.SqlDbType.NVarChar));
                    rsCmdBalance1.Parameters.Add(new SqlParameter("@Amount", System.Data.SqlDbType.Decimal));
                    rsCmdBalance1.Parameters["@Amount"].Precision = 18;
                    rsCmdBalance1.Parameters["@Amount"].Scale = 2;
                    foreach (var j in regObject.Jobs)
                    {
                        rsCmdBalance1.Parameters["@JobId"].Value = j.JobId;
                        rsCmdBalance1.Parameters["@Date"].Value = te.Date;
                        rsCmdBalance1.Parameters["@GLAccountCode"].Value = te.Person.PersonBusinessAccount.TravelExpenseAccountCode + "." + te.Person.RegisterCode;
                        rsCmdBalance1.Parameters["@DocumentCode"].Value = teCode;
                        rsCmdBalance1.Parameters["@Amount"].Value = j.Amount;
                        r = rsCmdBalance1.ExecuteNonQuery();
                    }
                    // Cambio lo status
                    s = "UPDATE [Job].TravelExpenses SET Status = @Status, PostDate = @Date WHERE [TravelExpenseCode] = @TravelExpenseCode;";
                    SqlCommand regStep4 = new SqlCommand(s, cnn);
                    regStep4.CommandType = System.Data.CommandType.Text;
                    regStep4.Transaction = trn;
                    regStep4.Parameters.Add(new SqlParameter("@Status", System.Data.SqlDbType.TinyInt));
                    regStep4.Parameters["@Status"].Value = EFDataModel.TravelExpenses.STATUS_REGISTRATA;
                    regStep4.Parameters.Add(new SqlParameter("@Date", System.Data.SqlDbType.Date));
                    regStep4.Parameters["@Date"].Value = te.Date;
                    regStep4.Parameters.Add(new SqlParameter("@TravelExpenseCode", System.Data.SqlDbType.NVarChar, 20));
                    regStep4.Parameters["@TravelExpenseCode"].Value = te.TravelExpenseCode;
                    r = regStep4.ExecuteNonQuery();
                    if (te.InvoiceAmount.Value > 0)
                    {
                        // Qui devo registrare la parte fatture!
                        // Salvo la riga di rimborso
                        s = "INSERT INTO [Job].[PrePaymentRefound] ([Date],[GLAccountCode],[PeopleId],[Amount],[Note],[Status]) ";
                        s += "VALUES (@Date, @GLAccountCode,@PeopleId,@Amount,NULL,1);SELECT SCOPE_IDENTITY();";
                        SqlCommand regStep10 = new SqlCommand(s, cnn);
                        regStep10.CommandType = System.Data.CommandType.Text;
                        regStep10.Transaction = trn;
                        regStep10.Parameters.Add(new SqlParameter("@Date", System.Data.SqlDbType.Date));
                        regStep10.Parameters["@Date"].Value = te.Date;
                        regStep10.Parameters.Add(new SqlParameter("@GLAccountCode", System.Data.SqlDbType.NVarChar, 20));
                        regStep10.Parameters["@GLAccountCode"].Value = te.Person.PersonBusinessAccount.TravelExpenseInvoiceAccountCode + "." + te.Person.RegisterCode;
                        regStep10.Parameters.Add(new SqlParameter("@PeopleId", System.Data.SqlDbType.Int));
                        regStep10.Parameters["@PeopleId"].Value = te.PeopleId;
                        regStep10.Parameters.Add(new SqlParameter("@Amount", System.Data.SqlDbType.Decimal));
                        regStep10.Parameters["@Amount"].Precision = 18;
                        regStep10.Parameters["@Amount"].Scale = 2;
                        regStep10.Parameters["@Amount"].Value = te.InvoiceAmount;
                        object res10 = regStep10.ExecuteScalar();
                        long refountId = 0;
                        if (res == null)
                        {
                            throw new Exception("GeneralJournalLines: numero riga risulta null!");
                        }
                        else
                        {
                            refountId = Convert.ToInt64(res10);
                        }
                        SqlCommand getId1 = new SqlCommand("[Job].[upGetElementNumber]", cnn);
                        getId1.CommandType = System.Data.CommandType.StoredProcedure;
                        getId1.Transaction = trn;
                        getId1.Parameters.Add(new SqlParameter("@Element", System.Data.SqlDbType.NVarChar, 50));
                        getId1.Parameters["@Element"].Value = "GLAccountEntries.LineNumber";
                        getId1.Parameters.Add(new SqlParameter("@Year", System.Data.SqlDbType.Int));
                        getId1.Parameters["@Year"].Value = te.Date.Year;
                        getId1.Parameters.Add(new SqlParameter("@ResultId", System.Data.SqlDbType.NVarChar, 20));
                        getId1.Parameters["@ResultId"].Direction = System.Data.ParameterDirection.Output;
                        r = getId1.ExecuteNonQuery();
                        resCode = Convert.ToString(getId.Parameters["@ResultId"].Value);
                        if (string.IsNullOrWhiteSpace(resCode))
                        {
                            throw new Exception("Il codice risulta null!");
                        }
                        s = "INSERT INTO [Job].[GeneralJournalLines] ([Date],[LineNumber],[Description],[Type],[EntryDocCode],[EntryDocType]) ";
                        s += "VALUES (@Date, @LineNr, @Description,'S',@EntryDocCode,2);SELECT SCOPE_IDENTITY();";
                        SqlCommand regStep11 = new SqlCommand(s, cnn);
                        regStep11.CommandType = System.Data.CommandType.Text;
                        regStep11.Transaction = trn;
                        regStep11.Parameters.Add(new SqlParameter("@Date", System.Data.SqlDbType.Date));
                        regStep11.Parameters["@Date"].Value = te.Date;
                        regStep11.Parameters.Add(new SqlParameter("@LineNr", System.Data.SqlDbType.Int));
                        regStep11.Parameters["@LineNr"].Value = int.Parse(resCode);
                        regStep11.Parameters.Add(new SqlParameter("@Description", System.Data.SqlDbType.NVarChar));
                        regStep11.Parameters["@Description"].Value = "REG Fatture spese trasferta " + te.TravelExpenseCode + " di " + te.Person.FullName;
                        regStep11.Parameters.Add(new SqlParameter("@EntryDocCode", System.Data.SqlDbType.NVarChar));
                        regStep11.Parameters["@EntryDocCode"].Value = refountId.ToString();
                        object res11 = regStep11.ExecuteScalar();
                        ln = 0;
                        if (res11 == null)
                        {
                            throw new Exception("GeneralJournalLines: numero riga risulta null!");
                        }
                        else
                        {
                            ln = Convert.ToInt64(res11);
                        }
                        s = "INSERT INTO [Job].[GeneralJournalLineEntries] ([GenerlaJournalLineId],[Date],[Position],[GLAccountCode],[Amount],[DebitCredit],[Type]) ";
                        s += "VALUES (@GeneralJournalLineId, @PostDate, 1, @PostPeopleAccountCode, @Total,'A','S');";
                        SqlCommand regStep12 = new SqlCommand(s, cnn);
                        regStep12.CommandType = System.Data.CommandType.Text;
                        regStep12.Transaction = trn;
                        regStep12.Parameters.Add(new SqlParameter("@GeneralJournalLineId", System.Data.SqlDbType.Int));
                        regStep12.Parameters["@GeneralJournalLineId"].Value = ln;
                        regStep12.Parameters.Add(new SqlParameter("@PostDate", System.Data.SqlDbType.Date));
                        regStep12.Parameters["@PostDate"].Value = te.Date;
                        regStep12.Parameters.Add(new SqlParameter("@PostPeopleAccountCode", System.Data.SqlDbType.NVarChar));
                        regStep12.Parameters["@PostPeopleAccountCode"].Value = te.Person.PersonBusinessAccount.DebitAccountCode + "." + te.Person.RegisterCode;
                        regStep12.Parameters.Add(new SqlParameter("@Total", System.Data.SqlDbType.Decimal));
                        regStep12.Parameters["@Total"].Precision = 18;
                        regStep12.Parameters["@Total"].Scale = 2;
                        regStep12.Parameters["@Total"].Value = te.InvoiceAmount;
                        r = regStep12.ExecuteNonQuery();
                        s = "INSERT INTO [Job].[GeneralJournalLineEntries] ([GenerlaJournalLineId],[Date],[Position],[GLAccountCode],[Amount],[DebitCredit],[Type]) ";
                        s += "VALUES (@GeneralJournalLineId, @PostDate, 2, @TravelExpensePostAccountCode, @Total,'D','S');";
                        SqlCommand regStep13 = new SqlCommand(s, cnn);
                        regStep13.CommandType = System.Data.CommandType.Text;
                        regStep13.Transaction = trn;
                        regStep13.Parameters.Add(new SqlParameter("@GeneralJournalLineId", System.Data.SqlDbType.Int));
                        regStep13.Parameters["@GeneralJournalLineId"].Value = ln;
                        regStep13.Parameters.Add(new SqlParameter("@PostDate", System.Data.SqlDbType.Date));
                        regStep13.Parameters["@PostDate"].Value = te.Date;
                        regStep13.Parameters.Add(new SqlParameter("@TravelExpensePostAccountCode", System.Data.SqlDbType.NVarChar));
                        regStep13.Parameters["@TravelExpensePostAccountCode"].Value = te.Person.PersonBusinessAccount.TravelExpenseInvoiceAccountCode + "." + te.Person.RegisterCode;
                        regStep13.Parameters.Add(new SqlParameter("@Total", System.Data.SqlDbType.Decimal));
                        regStep13.Parameters["@Total"].Precision = 18;
                        regStep13.Parameters["@Total"].Scale = 2;
                        regStep13.Parameters["@Total"].Value = te.InvoiceAmount;
                        r = regStep13.ExecuteNonQuery();
                    }
                    trn.Commit();
                }
                catch (SqlException)
                {
                    trn.Rollback();
                    throw;
                }
                catch (Exception)
                {
                    trn.Rollback();
                    throw;
                }
                finally
                {
                    cnn.Close();
                    cnn.Dispose();
                }
            }
            return resCode;
        }
    }
}
