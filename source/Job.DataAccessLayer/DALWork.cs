using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Job.DataAccessLayer
{
    public static class DALWork
    {
        public static List<Code.WorkedPeopleDay> getMonthWorkedHourByPeople(int peopleId, int month, int year)
        {
            List<Code.WorkedPeopleDay> _result = new List<Code.WorkedPeopleDay>();
            string cnnString = WebConfigurationManager.ConnectionStrings["JobSQLConnectionString"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cnnString))
            {
                try
                {
                    cnn.Open();
                    string sqlCmdString = "SELECT [Date], SUM([WorkedHours]) as [WorkedHours] FROM [Job].[WorksJournal] WHERE DATEPART(MONTH,[Date]) = @Month AND DATEPART(YEAR,[Date]) = @Year AND [PeopleId] = @PeopleId GROUP BY [Date] ORDER BY [Date];";
                    SqlCommand sqlCmd = new SqlCommand(sqlCmdString, cnn);
                    sqlCmd.CommandType = System.Data.CommandType.Text;
                    sqlCmd.Parameters.Add("@Month", System.Data.SqlDbType.Int);
                    sqlCmd.Parameters["@Month"].Value = month;
                    sqlCmd.Parameters.Add("@Year", System.Data.SqlDbType.Int);
                    sqlCmd.Parameters["@Year"].Value = year;
                    sqlCmd.Parameters.Add("@PeopleId", System.Data.SqlDbType.Int);
                    sqlCmd.Parameters["@PeopleId"].Value = peopleId;
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    while (reader.Read())
                    {
                        _result.Add(new Code.WorkedPeopleDay()
                        {   
                            Date = reader.GetDateTime(0),
                            Hours = reader.GetDecimal(1)
                        });
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
                }
            }

            return _result;
        }
    }
}
