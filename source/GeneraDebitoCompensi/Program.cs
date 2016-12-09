using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace GeneraDebitoCompensi
{
    class Program
    {
        public const string SOCIO_PersonBusinessAccount = "SOCIO";
        static void Main(string[] args)
        {
            // Leggo l'elenco soci
            string _desc = "Compenso " + Job.Code.UtiliMix.getMonthName(DateTime.Now.Month) + " " + DateTime.Now.Year.ToString();
            List<Classi.Socio> soci = getElencoSoci();
            foreach (var s in soci) {
                Console.WriteLine(s.FirstName + " " + s.LastName + " " + System.DateTime.Now.ToString("d"));
                RegisterStipendio(s, _desc);
            }
            // Genero lo stipendio per tutti i soci
            // Lo leggo dal APP Config
        }

        private static List<Classi.Socio> getElencoSoci ()
        {
            List<Classi.Socio> _result = new List<Classi.Socio>();
            Classi.Socio _tempSocio = null;
            string cnnString = WebConfigurationManager.ConnectionStrings["JobSQLConnectionString"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cnnString))
            {
                SqlCommand getElencoSoci = new SqlCommand("SELECT P.[PeopleId],P.[FirstName],P.[LastName],P.[CompensoMensile],P.[PersonBusinessAccountId],B.[CompensoAccountCode],B.[DebitAccountCode] FROM [Job].[Person] P INNER JOIN [Job].[PersonBusinessAccount] B ON P.PersonBusinessAccountId = B.Code WHERE P.PersonBusinessAccountId = '" + SOCIO_PersonBusinessAccount + "';", cnn);
                getElencoSoci.CommandType = System.Data.CommandType.Text;
                getElencoSoci.Connection.Open();
                using (SqlDataReader rdr = getElencoSoci.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        _tempSocio = new Classi.Socio();
                        _tempSocio.PeopleId = rdr.GetInt32(0);
                        _tempSocio.FirstName = rdr.GetString(1);
                        _tempSocio.LastName = rdr.GetString(2);
                        _tempSocio.Compenso = rdr.GetDecimal(3);
                        _tempSocio.PersonBusinessAccountId = rdr.GetString(4);
                        _tempSocio.CompensoAccountCode = rdr.GetString(5);
                        _tempSocio.DebitAccountCode = rdr.GetString(6);
                        _result.Add(_tempSocio);
                    }
                }
                getElencoSoci.Connection.Close();
            }
            return _result;
        }
        private static void RegisterStipendio(Classi.Socio socio, string description)
        {
            string cnnString = WebConfigurationManager.ConnectionStrings["JobSQLConnectionString"].ConnectionString;
            DateTime postDate = System.DateTime.Now;
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
                    getId.Parameters["@Element"].Value = "GLAccountEntries.LineNumber";
                    getId.Parameters.Add(new SqlParameter("@Year", System.Data.SqlDbType.Int));
                    getId.Parameters["@Year"].Value = postDate.Year;
                    getId.Parameters.Add(new SqlParameter("@ResultId", System.Data.SqlDbType.NVarChar, 20));
                    getId.Parameters["@ResultId"].Direction = System.Data.ParameterDirection.Output;
                    int r = getId.ExecuteNonQuery();
                    string lineNr = Convert.ToString(getId.Parameters["@ResultId"].Value);
                    if (string.IsNullOrWhiteSpace(lineNr))
                    {
                        trn.Rollback();
                    }
                    string sqlCmd = "INSERT INTO [Job].[GeneralJournalLines] ([Date],[LineNumber],[Description],[DocumentReference],[Type]) VALUES (@PostDate,@PostLine,@Desc,NULL,'S');SELECT SCOPE_IDENTITY();";
                    SqlCommand createLine = new SqlCommand(sqlCmd, cnn);
                    createLine.CommandType = System.Data.CommandType.Text;
                    createLine.Transaction = trn;
                    createLine.Parameters.Add(new SqlParameter("@PostDate", System.Data.SqlDbType.Date));
                    createLine.Parameters["@PostDate"].Value = postDate;
                    createLine.Parameters.Add(new SqlParameter("@PostLine", System.Data.SqlDbType.BigInt));
                    createLine.Parameters["@PostLine"].Value = long.Parse(lineNr);
                    createLine.Parameters.Add(new SqlParameter("@Desc", System.Data.SqlDbType.NVarChar, 256));
                    createLine.Parameters["@Desc"].Value = description;
                    object resCreateLine = createLine.ExecuteScalar();
                    long ln = 0;
                    if (resCreateLine == null)
                    {
                        throw new Exception("GeneralJournalLines: numero riga risulta null!");
                    }
                    else
                    {
                        ln = Convert.ToInt64(resCreateLine);
                    }
                    sqlCmd = "INSERT INTO[Job].[GeneralJournalLineEntries] ([GenerlaJournalLineId],[Date],[Position],[GLAccountCode],[Amount],[DebitCredit],[Type]) ";
                    sqlCmd += "VALUES (@GeneralJournalLineId, @PostDate, 1, @PostPeopleAccountCode, @Total,'A','S');";
                    SqlCommand regStep12 = new SqlCommand(sqlCmd, cnn);
                    regStep12.CommandType = System.Data.CommandType.Text;
                    regStep12.Transaction = trn;
                    regStep12.Parameters.Add(new SqlParameter("@GeneralJournalLineId", System.Data.SqlDbType.Int));
                    regStep12.Parameters["@GeneralJournalLineId"].Value = ln;
                    regStep12.Parameters.Add(new SqlParameter("@PostDate", System.Data.SqlDbType.Date));
                    regStep12.Parameters["@PostDate"].Value = postDate;
                    regStep12.Parameters.Add(new SqlParameter("@PostPeopleAccountCode", System.Data.SqlDbType.NVarChar));
                    regStep12.Parameters["@PostPeopleAccountCode"].Value = socio.DebitAccountCode + "." + socio.RegisterCode;
                    regStep12.Parameters.Add(new SqlParameter("@Total", System.Data.SqlDbType.Decimal));
                    regStep12.Parameters["@Total"].Precision = 18;
                    regStep12.Parameters["@Total"].Scale = 2;
                    regStep12.Parameters["@Total"].Value = socio.Compenso;
                    r = regStep12.ExecuteNonQuery();
                    sqlCmd = "INSERT INTO[Job].[GeneralJournalLineEntries] ([GenerlaJournalLineId],[Date],[Position],[GLAccountCode],[Amount],[DebitCredit],[Type]) ";
                    sqlCmd += "VALUES (@GeneralJournalLineId, @PostDate, 2, @TravelExpensePostAccountCode, @Total,'D','S');";
                    SqlCommand regStep13 = new SqlCommand(sqlCmd, cnn);
                    regStep13.CommandType = System.Data.CommandType.Text;
                    regStep13.Transaction = trn;
                    regStep13.Parameters.Add(new SqlParameter("@GeneralJournalLineId", System.Data.SqlDbType.Int));
                    regStep13.Parameters["@GeneralJournalLineId"].Value = ln;
                    regStep13.Parameters.Add(new SqlParameter("@PostDate", System.Data.SqlDbType.Date));
                    regStep13.Parameters["@PostDate"].Value = postDate;
                    regStep13.Parameters.Add(new SqlParameter("@TravelExpensePostAccountCode", System.Data.SqlDbType.NVarChar));
                    regStep13.Parameters["@TravelExpensePostAccountCode"].Value = socio.CompensoAccountCode + "." + socio.RegisterCode;
                    regStep13.Parameters.Add(new SqlParameter("@Total", System.Data.SqlDbType.Decimal));
                    regStep13.Parameters["@Total"].Precision = 18;
                    regStep13.Parameters["@Total"].Scale = 2;
                    regStep13.Parameters["@Total"].Value = socio.Compenso;
                    r = regStep13.ExecuteNonQuery();
                    trn.Commit();
                    cnn.Close();
                } catch (Exception)
                {
                    trn.Rollback();
                    throw;
                }
            }
        }
    }
}
