using StudyCircleManagementSystem.Entities;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace StudyCircleManagementSystem.DataAccess
{
    public class LoginDAO
    {
        public StudyCircleManagementSystem.Web.Models.LoginDetail GetDetails(string userName)
        {
            StudyCircleManagementSystem.Web.Models.LoginDetail details = new StudyCircleManagementSystem.Web.Models.LoginDetail();
            string connectionString = ConfigurationManager.ConnectionStrings["connectDB"].ToString();

            SqlConnection connection = null;
            
            connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            connection.Open();

            SqlCommand command = new SqlCommand("dbo.LoginDetails", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@userName", SqlDbType.NVarChar));
            command.Parameters["@userName"].Value = userName;

            command.ExecuteNonQuery();
      
            SqlDataReader detailDataReader = command.ExecuteReader();
            while (detailDataReader.Read())
            {                
                details.UserName=  detailDataReader["userName"].ToString();
                details.Password=detailDataReader["passworddetails"].ToString();
                details.Designation = detailDataReader["designation"].ToString();
                
            }
            connection.Close();
            return details;
        }
    }
}
